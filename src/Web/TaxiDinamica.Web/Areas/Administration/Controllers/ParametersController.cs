namespace TaxiDinamica.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Data.Parameters;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Web.ViewModels.Parameters;
    using TaxiDinamica.Web.ViewModels.Partners;
    using TaxiDinamica.Web.ViewModels.PartnerServices;

    public class ParametersController : AdministrationController
   {
        private IParametersService parametersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPartnersService partnersService;
        private readonly IPartnerServicesService partnerServicesService;

        public ParametersController(
            IParametersService parametersService, 
            UserManager<ApplicationUser> userManager,
            IPartnersService partnersService,
            IPartnerServicesService partnerServicesService)
        {
            this.parametersService = parametersService;
            this.userManager = userManager;
            this.partnersService = partnersService;
            this.partnerServicesService = partnerServicesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ParametersListViewModel
            {
                Parameters = await this.parametersService.GetAllAsync<ParameterViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> GenerarInformeUsuarios()
        {
            var usuarios = this.userManager.Users.ToList();
            StringBuilder str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`b>");
            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Email</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Nombres</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Apellidos</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Documento</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Fecha creacion</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Rol</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Frecuencia</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Ultima fecha de inicio</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Estado</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Num de servicios</font></b></td>");
            str.Append("</tr>");
            foreach (var user in usuarios)
            {
                var dateDiff = user.LastLogin == null
                    ? (DateTime.Now - user.CreatedOn).TotalDays
                    : (DateTime.Now - (DateTime)user.LastLogin).TotalDays;

                var roles = await this.userManager.GetRolesAsync(user);
                var partners = (await this.partnersService.GetAllByOwnerAsync<PartnerViewModel>(user.Id)).ToList();
                var count = 0;
                foreach(var partner in partners)
                {
                    var services = (await this.partnerServicesService.GetAllByPartnerIdAsync<PartnerServiceDetailsViewModel>(partner.Id)).ToList();
                    count += services.Count();
                }

                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.Email + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.Names + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.LastNames + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.DocumentId + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.CreatedOn + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + roles.FirstOrDefault() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.AmountLogins + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + user.LastLogin + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + (dateDiff < 15 ? "Activo" : "Inactivo") + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + count + "</font></td>");
                str.Append("</tr>");
            }

            str.Append("</table>");
            this.HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Informe Usuarios -" + DateTime.Now.Year.ToString() + ".xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            return this.File(temp, "application/vnd.ms-excel");
        }
    }
}
