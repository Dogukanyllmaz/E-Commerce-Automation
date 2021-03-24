using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetAllByCategoryId(int categoryId);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        //IDataResult<ProductDetailAndImagesDto> GetProductDetailAndImagesDto(int productId);
    }
}
