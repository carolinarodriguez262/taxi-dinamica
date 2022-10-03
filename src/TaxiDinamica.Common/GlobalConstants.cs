namespace TaxiDinamica.Common
{
    public static class GlobalConstants
    {
        
        public const string AdministratorRoleName = "Administrador";
        public const string CloudName = "cero-filas";
        public const string PartnerManagerRoleName = "Representante Legal";
        public const string SystemName = "Taxi Dinámica";

        public static class AccountsSeeding
        {
            public const string AdminEmail = "admin@admin.com";
            public const string PartnerManagerEmail = "manager@manager.com";
            public const string Password = "admin12345";
            public const string UserEmail = "user@user.com";
        }

        public static class DataValidations
        {
            public const int AddressMaxLength = 100;
            public const int AddressMinLength = 5;
            public const int ContentMaxLength = 3500;
            public const int DescriptionMaxLength = 700;
            public const int DescriptionMinLength = 50;
            public const int PlacaMinLength = 6;
            public const int PlacaMaxLength = 6;
            public const int NameMaxLength = 40;
            public const int NameMinLength = 2;
            public const int TitleMaxLength = 60;
        }

        public static class DateTimeFormats
        {
            public const string DateFormat = "dd-MM-yyyy";
            public const string TimeFormat = "h:mmtt";
            public const string DateTimeFormat = "dd-MM-yyyy h:mmtt";

        }

        public static class ErrorMessages
        {
            public const string DriverName = "Este campo debe tener entre 5 y 100 caracteres.";
            public const string DateTime = "Por favor selecciona una fecha y hora valida en el selector de fechas a la izquirda.";
            public const string Description = "El texto debe tener entre 50 y 700 caracteres.";
            public const string DescriptionMax = "El texto debe tener máximo 700 caracteres.";
            public const string Image = "Selecciona un archivo JPG, JPEG o PNG imagen con peso menor a 1MB.";
            public const string Document = "Selecciona un archivo PDF o documento con peso menor a 1MB.";
            public const string ReqFile = "Documento obligatorio. Selecciona un archivo.";
            public const string Name = "Debe tener entre 4 y 20 caracteres.";
            public const string Placa = "La placa de tener 6 caracteres sin separar.";
            public const string Required = "Este campo es obligatorio.";
        }

        public static class Images
        {
            public const string DemoImg = "https://res.cloudinary.com/cero-filas/image/upload/v1620858717/images/wpmazrqzgwace1o2qmmy.jpg";
            public const string Taxi2 = "https://res.cloudinary.com/cero-filas/image/upload/v1620882192/images/hnlhrdhb0zrju5uxrphz.jpg";
            public const string Taxi3 = "https://res.cloudinary.com/cero-filas/image/upload/v1620883555/images/r2mjxtfstugaeaaywkw9.jpg";
            public const string Taxi4 = "https://res.cloudinary.com/cero-filas/image/upload/v1622036404/images/xaqqlxeowhbal1lt3r5e.jpg";
        }

        public static class SeededDataCounts
        {
            public const int Appointments = 54;
            public const int Categories = 6;
            public const int Cities = 2;
            public const int Partners = 18;
            public const int Services = 55;
        }
    }
}
