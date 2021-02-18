using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //ValidationTool.Validate(new ProductValidator(),product);

            _iProductDAL.Add(product);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Product>> GetAll()
        {//iş kodları
            //koşullar sağlanıyor mu?

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_iProductDAL.GetAll(),Messages.ListAll);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_iProductDAL.GetAll(p => p.CategoryID == id), Messages.ListOfDesiredFeature);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_iProductDAL.Get(p => p.ProductID == id),  Messages.GetById);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_iProductDAL.GetAll(p => p.UnitPrice<=max&&p.UnitPrice>=min), Messages.ListOfRangePrice);
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>( _iProductDAL.GetProductDetail(), Messages.Details);
        }

        
    }
}
