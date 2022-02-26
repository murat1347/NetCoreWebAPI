﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Murat.API.Data;
using Murat.API.Interfaces;

namespace Murat.API.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking().SingleOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Product> Create(Product product)
        {
          await _context.Products.AddAsync(product);
          await _context.SaveChangesAsync();
          return product;
        }

        public async Task UpdateAsync(Product product)
        {
            var unchangeEntity =await _context.Products.FindAsync(product.Id);
            _context.Entry(unchangeEntity).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            

        }

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(removedEntity);
            _context.SaveChangesAsync();
        }
    }
}
