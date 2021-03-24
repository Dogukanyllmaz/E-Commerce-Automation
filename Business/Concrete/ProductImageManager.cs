using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        [SecuredOperation("productImage.add,admin")]
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.Id));
            if (result != null)
            {
                return result;
            }

            productImage.ImagePath = FileHelper.Add(file);
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IProductImageService.Get")]
        [SecuredOperation("productImage.delete,admin")]
        public IResult Delete(ProductImage productImage)
        {
            FileHelper.Delete(productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        [SecuredOperation("productImage.update,admin")]
        [CacheRemoveAspect("IProductImageService.Get")]
        public IResult Update(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.Id));
            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _productImageDal.Get(p => p.Id == productImage.Id).ImagePath;

            productImage.ImagePath = FileHelper.Update(oldPath, file);
            productImage.Date = DateTime.Now;
            _productImageDal.Update(productImage);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<ProductImage> GetById(int Id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == Id));
        }

        [CacheAspect]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<ProductImage>> GetImagesByProductId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<ProductImage>>(result.Message);
            }

            return new SuccessDataResult<List<ProductImage>>(CheckIfProductImageNull(id).Data);
        }

        private IResult CheckImageLimitExceeded(int Id)
        {
            var productImageCount = _productImageDal.GetAll(p => p.Id == Id).Count;
            if (productImageCount >= 5)
            {
                return new ErrorResult(Messages.ProductImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private IDataResult<List<ProductImage>> CheckIfProductImageNull(int id)
        {
            try
            {
                string path = @"\uploads\default.jpg";

                var result = _productImageDal.GetAll(p => p.ProductId == id).Any();

                if (!result)
                {
                    List<ProductImage> productImage = new List<ProductImage>();

                    productImage.Add(new ProductImage { ProductId = id, ImagePath = path, Date = DateTime.Now });

                    return new SuccessDataResult<List<ProductImage>>(productImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<ProductImage>>(exception.Message);
            }

            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(c => c.ProductId == id));
        }
    }
}



