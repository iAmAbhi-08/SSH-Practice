using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplifaiInfo3.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Required]
        public string productName { get; set; }

        //[Range(0, double.MaxValue, ErrorMessage = "Enter Valid Cost")]
        public double productCost { get; set; }

        public ICollection<Clients> clients { get; set; }


    }
}
