using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductImageService 
    {
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
        IDataResult<ProductImage> GetById(int Id);
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<List<ProductImage>> GetImagesByProductId(int id);
        //IDataResult<List<ProductImage>> GetAllByProductId(int productId);

    }
}
