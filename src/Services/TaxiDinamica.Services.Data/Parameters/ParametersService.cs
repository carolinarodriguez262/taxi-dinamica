namespace TaxiDinamica.Services.Data.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TaxiDinamica.Data.Common.Repositories;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;
    using TaxiDinamica.Web.ViewModels.Parameters;

    public class ParametersService : IParametersService
    {
        private readonly IDeletableEntityRepository<Parameters> parametersRepository;

        public ParametersService(IDeletableEntityRepository<Parameters> parametersRepository)
        {
            this.parametersRepository = parametersRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var parameters =
              await this.parametersRepository
              .All()
              .OrderBy(x => x.Id)
              .To<T>().ToListAsync();
            return parameters;
        }
    }
}
