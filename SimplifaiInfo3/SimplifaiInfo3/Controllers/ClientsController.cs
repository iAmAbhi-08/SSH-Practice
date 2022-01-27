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
    [Route("/Product/{id}/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ClientsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetClientList(int id)
        {
            // var obj = new List<Clients> { _db.ClientsTable.Find(id) };
            //var obj = _db.ClientsTable.Join(
            //    _db.ClientsTable,
            //    product => product.productId,
            //    client => client.products.productId,
            //    (product, client) => new
            //    {
            //        clientId = client.clientId,
            //        productID = client.productId,
            //        productName = client.products.productName,
            //        priceOfPurchase = client.priceOfPurchase
            //    });

            //var a = 1;
            var obj = _db.ClientsTable.Join(
                _db.ClientsTable,
                pro => pro.productId,
                cli => cli.productId,
                (pro, cli) => new
                {
                    clientsId = cli.clientId,
                    clientsName = cli.clientName,
                    productsID = cli.productId,
                    productsName = pro.products,
                    purchasePrice = cli.priceOfPurchase
                });

            

            //var obj = _db.ClientsTable.Where(x => x.productId == id).ToList();

            return Ok(obj.Where(x => x.productsID == id));
        }
    }
}
