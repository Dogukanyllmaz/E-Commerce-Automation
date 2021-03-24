using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailAndImagesDto : IDto
    {
        public ProductDetailDto Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}
