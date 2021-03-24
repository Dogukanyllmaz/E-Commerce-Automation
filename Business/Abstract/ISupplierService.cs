using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ISupplierService : IGenericService<Supplier>
    {
        IDataResult<Supplier> GetById(int supplierId);
    }
}
