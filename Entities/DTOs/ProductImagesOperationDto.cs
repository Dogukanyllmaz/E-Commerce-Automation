using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductImagesOperationDto : IDto
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public List<IFormFile> Images { get; set; }

    }
}
