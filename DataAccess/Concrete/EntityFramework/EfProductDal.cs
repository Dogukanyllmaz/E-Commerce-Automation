using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ETicaretContext>, IProductDal
    {
        public ProductDetailDto GetProductDetail(int productId)
        {
            using(ETicaretContext context = new ETicaretContext())
            {
                var result = from p in context.Products.Where(p => p.ProductId == productId)
                             join c in context.Categories
                                 on p.CategoryId equals c.CategoryId
                             join s in context.Suppliers
                                 on p.SupplierId equals s.SupplierId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 CategoryName = c.CategoryName,
                                 CompanyName = s.CompanyName,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock,
                                 UnitsOnOrder = p.UnitsOnOrder,
                                 UnitPrice = p.UnitPrice
                             };
                return result.SingleOrDefault();
            }
        }

        public List<ProductDetailDto> GetProductsDetail(Expression<Func<Product, bool>> filter = null)
        {
            using(ETicaretContext context = new ETicaretContext())
            {
                var result = from p in filter == null ? context.Products : context.Products.Where(filter)
                             join c in context.Categories
                                 on p.CategoryId equals c.CategoryId
                             join s in context.Suppliers
                                 on p.SupplierId equals s.SupplierId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 CategoryName = c.CategoryName,
                                 CompanyName = s.CompanyName,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock,
                                 UnitsOnOrder = p.UnitsOnOrder,
                                 UnitPrice = p.UnitPrice
                             };
                return result.ToList();
            }
        }
    }
}
