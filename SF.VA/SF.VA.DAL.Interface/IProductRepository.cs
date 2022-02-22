using SF.VA.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.VA.DAL.Interface
{
    public interface IProductRepository
    {
        public Task<List<Products>> GetAllAsync();

        public Task<Products> GetSingle(int id);

        public Products GetSingle(string product);

        public Task<Products> PostProduct(Products product);

        public void Update(Products product);

        public void Delete(Products product);
    }
}
