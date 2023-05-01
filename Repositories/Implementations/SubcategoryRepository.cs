// <copyright file="SubcategoryRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApi.Repository.Implementation
{
    using Microsoft.EntityFrameworkCore;
    using webApi.Data;
    using webApi.Models;
    using webApi.Repository.Interface;

    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly ContextDb dbContext;

        public SubcategoryRepository(ContextDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Subcategory>> GetAllAsync()
        {
            return await this.dbContext.Subcategories.Include(s => s.Category).ToListAsync();
        }

        public async Task<Subcategory> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await this.dbContext.Subcategories.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == id);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public async Task<int> CreateAsync(Subcategory subcategory)
        {
            this.dbContext.Subcategories.Add(subcategory);
            await this.dbContext.SaveChangesAsync();
            return subcategory.Id;
        }

        public async Task UpdateAsync(Subcategory subcategory)
        {
            this.dbContext.Subcategories.Update(subcategory);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Subcategory subcategory)
        {
            this.dbContext.Subcategories.Remove(subcategory);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
