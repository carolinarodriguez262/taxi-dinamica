namespace TaxiDinamica.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Models;

    public class PartnersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Partners.Any())
            {
                return;
            }

            var partners = new Partner[]
           {
                    // 1.
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "MFR231",
                        CategoryId = 1,
                        CityId = 1,
                        DriverName = "Francisco Herrera",
                        DriverContact = "313353 6753",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl =  GlobalConstants.Images.DemoImg,
                        DocOperacionUrl =  GlobalConstants.Images.DemoImg,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "EWO123",
                        CategoryId = 1,
                        CityId = 1,
                        DriverName = "Aureliano Ferrer",
                        DriverContact = "350 499 5005",
                        ImageUrl = GlobalConstants.Images.Taxi2,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.Taxi2,
                        DocOperacionUrl = GlobalConstants.Images.Taxi2,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "SDF231",
                        CategoryId = 1,
                        CityId = 1,
                        DriverName = "Carmelo Benítez",
                        DriverContact = "350 514 9077",
                        ImageUrl = GlobalConstants.Images.Taxi3,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.Taxi3,
                        DocOperacionUrl = GlobalConstants.Images.Taxi3,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },

                    // 2.
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "WFG232",
                        CategoryId = 2,
                        CityId = 1,
                        DriverName = "Mateo Navarro",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.Taxi4,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.Taxi4,
                        DocOperacionUrl = GlobalConstants.Images.Taxi4,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "ZSD231",
                        CategoryId = 2,
                        CityId = 1,
                        DriverName = "Kamora Madden",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.Taxi3,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.Taxi3,
                        DocOperacionUrl = GlobalConstants.Images.Taxi3,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "XSD234",
                        CategoryId = 2,
                        CityId = 1,
                        DriverName = "Macario Lorenzo",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.Taxi2,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.DemoImg,
                        DocOperacionUrl = GlobalConstants.Images.DemoImg,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },

                    // 3. 
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "XDF534",
                        CategoryId = 3,
                        CityId = 1,
                        DriverName = "Eduvigis Campos",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.DemoImg,
                        DocOperacionUrl = GlobalConstants.Images.DemoImg,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "USD231",
                        CategoryId = 3,
                        CityId = 1,
                        DriverName = "Edgar Marín",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.Taxi2,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.Taxi2,
                        DocOperacionUrl = GlobalConstants.Images.Taxi2,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "SWF687",
                        CategoryId = 3,
                        CityId = 1,
                        DriverName = "Virgilio Cortés",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.Taxi3,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.Taxi2,
                        DocOperacionUrl = GlobalConstants.Images.Taxi2,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },

                    // 4. 
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "YUI098",
                        CategoryId = 4,
                        CityId = 1,
                        DriverName = "Marcelino Montoro",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.Taxi4,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.Taxi4,
                        DocOperacionUrl = GlobalConstants.Images.Taxi4,
                        DocPaseUrl = GlobalConstants.Images.DemoImg,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "CBN456",
                        CategoryId = 4,
                        CityId = 1,
                        DriverName = "Marques Gonzalez",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.Taxi3,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.Taxi3,
                        DocOperacionUrl = GlobalConstants.Images.Taxi3,
                        DocPaseUrl = GlobalConstants.Images.Taxi3,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },
                    new Partner
                    {
                        Id = "amarillo" + Guid.NewGuid().ToString(),
                        Placa = "LUO487",
                        CategoryId = 4,
                        CityId = 1,
                        DriverName = "Pascual Gutiérrez",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.Taxi2,
                        Rating = 0.0,
                        RatersCount = 0,
                        DocLicenciaUrl = GlobalConstants.Images.Taxi2,
                        DocOperacionUrl = GlobalConstants.Images.Taxi2,
                        DocPaseUrl = GlobalConstants.Images.Taxi2,
                        DocSeguroUrl = GlobalConstants.Images.DemoImg,
                        DocSoatUrl = GlobalConstants.Images.DemoImg,
                        DocTarjetonUrl = GlobalConstants.Images.DemoImg,
                        DocTecnoUrl = GlobalConstants.Images.DemoImg,
                    },
           };

            await dbContext.AddRangeAsync(partners);
        }
    }
}
