using Microsoft.AspNetCore.Mvc;
using SF.VA.BLL.Interface;
using SF.VA.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SF.VA.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class InternalApiController : Controller
    {
        private readonly IProductRepositoryService _productRepositoryService;

        public InternalApiController(IProductRepositoryService productRepositoryService)
        {
            _productRepositoryService = productRepositoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var returnObj = await _productRepositoryService.GetAll();
            return Ok(returnObj);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnObj = await _productRepositoryService.GetSingle(id);
            return Ok(returnObj);
        }

        [HttpGet("{ProductName}")]
        public IActionResult GetByName(string ProductName)
        {
            var returnObj = _productRepositoryService.GetSingle(ProductName);
            return Ok(returnObj);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string product, double cost)
        {
            var returnObj = await _productRepositoryService.PostProduct(product, cost);

            return Ok(returnObj);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, double cost, string product = null)
        {
            var returnObj = await _productRepositoryService.UpdateProduct(id, product, cost);

            return Ok(returnObj);
        }

        [HttpPut("{ProductName}")]
        public IActionResult UpdateByName(string ProductName, double cost)
        {
            var returnObj = _productRepositoryService.UpdateProduct(ProductName, cost);
            return Ok(returnObj);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productRepositoryService.DeleteProduct(id);

            return Ok();
        }
    }
}
