namespace TaxiDinamica.Web.Areas.Identity.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.Extensions.Logging;
    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Data.Parameters;
    using TaxiDinamica.Web.Controllers;
    using TaxiDinamica.Web.ViewModels.Parameters;

    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> logger;
        private readonly IParametersService _parameters;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public LoginModel(
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<ApplicationUser> userManager, IParametersService parametersService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this._parameters = parametersService;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public string StatusMessage { get; private set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                this.ModelState.AddModelError(string.Empty, this.ErrorMessage);
            }

            returnUrl = returnUrl ?? this.Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            this.ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/");

            if (this.ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await this.signInManager.PasswordSignInAsync(this.Input.Email, this.Input.Password, this.Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    this.logger.LogInformation("Usuario loggeado.");
                    var users = this.userManager.Users.ToList();
                    var user = users.FirstOrDefault(x => x.Email == this.Input.Email);
                    user.LastLogin = DateTime.Now;
                    user.AmountLogins = user.AmountLogins == null
                        ? 1
                        : user.AmountLogins + 1;

                    await this.userManager.UpdateAsync(user);
                   // ParameterViewModel parameterViewModel = this._parameters.SaveFrecuency(Input.Email);
                     return this.LocalRedirect(returnUrl);
                }
                else if (result.RequiresTwoFactor)
                {
                    return this.RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = this.Input.RememberMe });
                }
                else if (result.IsLockedOut)
                {
                    this.logger.LogWarning("Cuenta de usuario bloqueada.");
                    return this.RedirectToPage("./Lockout");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Intento fallido.");
                    this.StatusMessage = "Tu contraseña o usuario es incorrecto";
                    return this.Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
            [EmailAddress(ErrorMessage = "Ingresa un correo electrónico válido")]
            [Display(Name = "Correo Electrónico")]
            public string Email { get; set; }

            [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
            [Display(Name = "Contraseña")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Recordarme")]
            public bool RememberMe { get; set; }
        }
    }
}
