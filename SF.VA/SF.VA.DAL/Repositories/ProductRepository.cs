using SF.VA.DAL.EF;
using SF.VA.DAL.Interface;
using SF.VA.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SF.VA.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _db;

        public ProductRepository(ProductDbContext db)
        {
            _db = db;
        }

        public async Task<List<Products>> GetAllAsync()
        {
            var obj = await _db.ProductTable.ToListAsync();
            return obj;
        }

        public async Task<Products> GetSingle(int id)
        {
            var returnObj = await _db.ProductTable.FindAsync(id);
            return returnObj;
        }

        public Products GetSingle(string product)
        {
            var returnObj = _db.ProductTable.Where(x => x.ProductName == product).FirstOrDefault();
            return returnObj;
        }

        public async Task<Products> PostProduct(Products product)
        {
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();

            return await _db.ProductTable.OrderBy(x => x.ProductId)
                .LastAsync();
             
        }

        public void Update(Products product)
        {
            _db.ProductTable.Update(product);
            _db.SaveChanges();
        }

        public async void Delete(Products product)
        {
            _db.ProductTable.Remove(product);
            await _db.SaveChangesAsync();
        }
    }
}
