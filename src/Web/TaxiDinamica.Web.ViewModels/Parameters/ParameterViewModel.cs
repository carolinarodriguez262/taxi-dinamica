namespace TaxiDinamica.Web.ViewModels.Parameters
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class ParameterViewModel : IMapFrom<Parameters>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Indentity { get; set; }

        public bool Active { get; set; }

        public string DateAdmission { get; set; }

        public string Tipe { get; set; }

        public int Frequency { get; set; }
    }
}
