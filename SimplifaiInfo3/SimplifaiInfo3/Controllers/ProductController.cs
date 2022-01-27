using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplifaiInfo3.Data;
using SimplifaiInfo3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplifaiInfo3.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductController : Controller
    {
        AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            if (_db.ProductTable.Count() == 0)
            {
                return BadRequest("No Products Added");
            }

            
            return Ok(await _db.ProductTable.ToListAsync());


        }

        

        [HttpPost]
        public async Task<IActionResult> InsertProduct(string newProductName, double newProductCost)
        {
            var obj = new Product() 
            { 
                productName = newProductName , 
                productCost = newProductCost , 
                productId = 0
            };

            await _db.ProductTable.AddAsync(obj);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingleProduct(int id)
        {
            var obj = new Product();
            obj = await _db.ProductTable.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Product Not Found");
            }

            return Ok(obj);
        }

        //[HttpGet("{name}")]
        //public async Task<IActionResult> GetSingleProduct(string name)
        //{
        //    var obj = new Product();
        //    obj = await _db.ProductTable.FindAsync(name);
        //    if (obj == null)
        //    {
        //        return BadRequest("Product Not Found");
        //    }

        //    return Ok(obj);
        //}



        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, double newProductCost)
        {
            var obj = new Product();
            obj = await _db.ProductTable.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Product Not Found");
            }

            obj.productCost = newProductCost;
            _db.ProductTable.Update(obj);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var obj = await _db.ProductTable.FindAsync(id);
            if(obj == null)
            {
                return BadRequest("Product Not Found");
            }
            _db.ProductTable.Remove(obj);
            await _db.SaveChangesAsync();
            return Ok();
           
        }

    }
}
