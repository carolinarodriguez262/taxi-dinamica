namespace TaxiDinamica.Services.Data.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TaxiDinamica.Web.ViewModels.Parameters;

    public interface IParametersService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();


    }
}
