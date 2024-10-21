﻿using HelpStockApp.Domain.Interfaces;
using HelpStockApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using HelpStockApp.Domain.Entities;

namespace HelpStockApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> Create(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(int? id)
        {
            var product = await _productContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productContext.Products.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Product> Update(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
