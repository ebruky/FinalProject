using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDAL : IProductDAL
    {
        List<Product> _products;
        
        public InMemoryProductDAL()
        {
            _products = new List<Product> {
            new Product{ProductName="Masa",ProductID=1,CategoryID=1, UnitPrice=50, UnitsInStock=8},
            new Product{ProductName="Ahşap Sandalye",ProductID=2,CategoryID=1, UnitPrice=35, UnitsInStock=4},
            new Product{ProductName="Bardak",ProductID=3,CategoryID=2, UnitPrice=5, UnitsInStock=60},
            new Product{ProductName="Ruj",ProductID=4,CategoryID=3, UnitPrice=25, UnitsInStock=10}
            };

        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product DeleteToProduct = null;
            //foreach (var p in _products)
            //{
            //    if (p.ID==product.ID)
            //    {
            //        DeleteToProduct = p;
            //    }
            //}
            //_products.Remove(DeleteToProduct);


            //LINQ = Language Integrated Query  ile liste bazlı yapııları Sql gibi filtreleme işine yarar.

            Product DeleteToProduct = _products.SingleOrDefault(p=> p.ProductID == product.ProductID);
            _products.Remove(DeleteToProduct);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public List<ProductDetailDTO> GetProductDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product UpdateToProduct = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            UpdateToProduct.ProductName = product.ProductName;
            UpdateToProduct.UnitPrice = product.UnitPrice;
            UpdateToProduct.UnitPrice = product.UnitsInStock;
            UpdateToProduct.CategoryID = product.CategoryID;
        }
    }
}
