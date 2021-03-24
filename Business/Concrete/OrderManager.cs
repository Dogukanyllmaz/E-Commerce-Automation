using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;   
        }

        [SecuredOperation("order.add,admin")]
        public IResult Add(Order entity)
        {
            IResult result = BusinessRules.Run(CheckIfShipNameAlreadyExists(entity.ShipName));
            if (result != null)
            {
                return result;
            }
            _orderDal.Add(entity);
            return new SuccessResult(Messages.TheOrderHasBeenSuccessfullyAdded);
        }

        [SecuredOperation("order.delete,admin")]
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Delete(Order entity)
        {
            _orderDal.Delete(entity);
            return new SuccessResult(Messages.TheOrderHasBeenSuccessfullyDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(),Messages.TheOrdersHaveBeenSuccessfullyListed);
        }

        [CacheAspect]
        public IDataResult<Order> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.OrderId == orderId));
        }

        [CacheRemoveAspect("IOrderService.Get")]
        [SecuredOperation("order.update,admin")]
        public IResult Update(Order entity)
        {
            IResult result = BusinessRules.Run(CheckIfShipNameAlreadyExists(entity.ShipName));
            if(result != null)
            {
                return result;
            }
            _orderDal.Update(entity);
            return new SuccessResult(Messages.TheOrderHasBeenSuccessfullyUpdated);
        }

        //--------------------------BusinessRules-----------------------------

        private IResult CheckIfShipNameAlreadyExists(string shipName)
        {
            var result = _orderDal.GetAll(o => o.ShipName == shipName).Any();
            if (result)
            {
                return new ErrorResult(Messages.OrderNameAlreadyExists);
            }
            return new SuccessResult();
        }

    }
}
