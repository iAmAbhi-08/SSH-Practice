using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplifaiInfo3.Models
{
    public class Clients
    {
        [Key]
        public int clientId { get; set; }

        public string clientName { get; set; }

        public double priceOfPurchase { get; set; }

        public int productId { get; set; }
        public Product products { get; set; }

    }
}
