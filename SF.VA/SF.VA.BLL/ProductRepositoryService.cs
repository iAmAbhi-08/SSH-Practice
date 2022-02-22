using AutoMapper;
using SF.VA.BLL.Interface;
using SF.VA.DAL.Interface;
using SF.VA.Models.DTO;
using SF.VA.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.VA.BLL
{
    public class ProductRepositoryService : IProductRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductRepositoryService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            var productObj = await _productRepository.GetAllAsync();
            List<ProductDTO> productDTObj = _mapper.Map<List<ProductDTO>>(productObj);

            return productDTObj;
        }

        public async Task<ProductDTO> GetSingle(int id)
        {
            var productObj = await _productRepository.GetSingle(id);
            var productDTObj = _mapper.Map<ProductDTO>(productObj);

            return productDTObj;
        }

        public ProductDTO GetSingle(string name)
        {
            var productObj = _productRepository.GetSingle(name);
            var productDTObj = _mapper.Map<ProductDTO>(productObj);

            return productDTObj;
        }



        public async Task<ProductDTO> PostProduct(string product, double cost)
        {
            var productObj = new Products()
            {
                ProductId = 0,
                ProductName = product,
                ProductCost = cost
            };

            productObj = await _productRepository.PostProduct(productObj);

            return _mapper.Map<ProductDTO>(productObj);
            
        }

        public async Task<ProductDTO> UpdateProduct(int id, string product, double cost)
        {
            Products productObj = await _productRepository.GetSingle(id); 

            if(product != null)
            {
                productObj.ProductName = product;
            }

            if (cost != 0)
            {
                productObj.ProductCost = cost;
            }

             _productRepository.Update(productObj);

            return _mapper.Map<ProductDTO>(await _productRepository.GetSingle(id));
        }

        public ProductDTO UpdateProduct(string name, double cost)
        {
            var productObj = _productRepository.GetSingle(name);
            productObj.ProductCost = cost;

            _productRepository.Update(productObj);

            return _mapper.Map<ProductDTO>(_productRepository.GetSingle(name));
        }

        public async void DeleteProduct(int id)
        {
            var toDeleteObj = await _productRepository.GetSingle(id);
            _productRepository.Delete(toDeleteObj);
        }


    }
}
