using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SF.VA.API.Models
{
    public class UriResponseModel
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
