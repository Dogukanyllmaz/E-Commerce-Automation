using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [SecuredOperation("category.add,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category entity)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExists(entity.CategoryName));

            if (result != null)
            {
                return result;
            }
            _categoryDal.Add(entity);
            return new SuccessResult(Messages.TheCategoryHasBeenSuccessfullyAdded);
        }

        [CacheRemoveAspect("ICategoryService.Get")]
        [SecuredOperation("category.delete,admin")]
        public IResult Delete(Category entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult(Messages.TheCategoryHasBeenSuccessfullyDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.TheCategoriesHaveBeenSuccessfullyListed);
        }

        [CacheAspect]
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        [SecuredOperation("category.update,admin")]
        public IResult Update(Category entity)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExists(entity.CategoryName));

            if (result != null)
            {
                return result;
            }

            _categoryDal.Update(entity);
            return new SuccessResult(Messages.TheCategoryHasBeenSuccessfullyUpdated);
        }

        //------------------------------------BusinessRules-------------------------------------

        private IResult CheckIfCategoryNameExists(string categoryName)
        {
            var result = _categoryDal.GetAll(c => c.CategoryName == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
