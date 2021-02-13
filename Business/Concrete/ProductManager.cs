using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDAL _iProductDAL;   //Soyut Nesne ile bağlantı kurulacak
        public ProductManager(IProductDAL iProductDAL)
        {
            _iProductDAL = iProductDAL;


        }

        public IResult Add(Product product)
        {if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);

            }
            _iProductDAL.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {//iş kodları
            //koşullar sağlanıyor mu?

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_iProductDAL.GetAll(),Messages.ProductListAll);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_iProductDAL.GetAll(p => p.CategoryID == id), Messages.ProductListOfCategory);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_iProductDAL.Get(p => p.ProductID == id),  Messages.GetProductById);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_iProductDAL.GetAll(p => p.UnitPrice<=max&&p.UnitPrice>=min), Messages.ProductListOfRangePrice);
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>( _iProductDAL.GetProductDetail(), Messages.ProductDetails);
        }

        
    }
}
