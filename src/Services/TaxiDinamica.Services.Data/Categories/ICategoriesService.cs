﻿namespace TaxiDinamica.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<T> GetByIdAsync<T>(int id);

        Task AddAsync(string name, string description);

        Task DeleteAsync(int id);
    }
}
