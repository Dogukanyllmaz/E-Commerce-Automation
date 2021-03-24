using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        [ValidationAspect(typeof(SupplierValidator))]
        [SecuredOperation("supplier.add,admin")]
        public IResult Add(Supplier entity)
        {
            _supplierDal.Add(entity);
            return new SuccessResult(Messages.TheSupplierHasBeenSuccessfullyAdded);
        }

        [SecuredOperation("supplier.delete,admin")]
        [CacheRemoveAspect("ISupplierService.Get")]
        public IResult Delete(Supplier entity)
        {
            _supplierDal.Delete(entity);
            return new SuccessResult(Messages.TheSupplierHasBeenSuccessfullyDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Supplier>> GetAll()
        {
            return new SuccessDataResult<List<Supplier>>(_supplierDal.GetAll(),Messages.TheSuppliersHaveBeenSuccessfullyListed);
        }

        [CacheAspect]
        public IDataResult<Supplier> GetById(int supplierId)
        {
            return new SuccessDataResult<Supplier>(_supplierDal.Get(s => s.SupplierId == supplierId));
        }

        [ValidationAspect(typeof(SupplierValidator))]
        [CacheRemoveAspect("ISupplierService.Get")]
        [SecuredOperation("supplier.update,admin")]
        public IResult Update(Supplier entity)
        {
            _supplierDal.Update(entity);
            return new SuccessResult(Messages.TheSupplierHasBeenSuccessfullyUpdated);
        }
    }
}
