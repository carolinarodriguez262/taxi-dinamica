namespace TaxiDinamica.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Common.Models;

    public class Parameters : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Indentity { get; set; }

        public bool Active { get; set; }

        public DateTime DateAdmission { get; set; }

        public string Tipe { get; set; }

        public int Frequency { get; set; }
    }
}
