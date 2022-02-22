using AutoMapper;
using SF.VA.Models.DTO;
using SF.VA.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.VA.BLL.AutoMapperProfiles
{
    public class ProductAutoMapperProfile : Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<Products, ProductDTO>();
        }
    }
}
