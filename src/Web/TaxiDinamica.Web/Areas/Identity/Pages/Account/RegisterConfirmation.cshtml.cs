﻿using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using TaxiDinamica.Data.Models;

namespace TaxiDinamica.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailSender sender;

        public RegisterConfirmationModel(UserManager<ApplicationUser> userManager, IEmailSender sender)
        {
            this.userManager = userManager;
            this.sender = sender;
        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            {
                return this.RedirectToPage("/Index");
            }

            var user = await this.userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return this.NotFound($"No se pudo cargar al usuario con el correo electrónico '{email}'.");
            }

            this.Email = email;
            
            // Once you add a real email sender, you should remove this code that lets you confirm the account
            this.DisplayConfirmAccountLink = true;
            if (this.DisplayConfirmAccountLink)
            {
                var userId = await this.userManager.GetUserIdAsync(user);
                var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                this.EmailConfirmationUrl = this.Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code },
                    protocol: this.Request.Scheme);
            }

            return this.Page();
        }
    }
}
