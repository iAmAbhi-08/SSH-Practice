using SF.VA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.VA.BLL.Interface
{
    public interface IProductRepositoryService
    {
        public Task<List<ProductDTO>> GetAll();

        public Task<ProductDTO> GetSingle(int id);

        public ProductDTO GetSingle(string name);

        public Task<ProductDTO> PostProduct(string product, double cost);

        public Task<ProductDTO> UpdateProduct(int id, string product, double cost);

        public ProductDTO UpdateProduct(string name, double cost);

        public void DeleteProduct(int id);
    }
}
