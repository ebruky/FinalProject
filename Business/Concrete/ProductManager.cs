using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
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
        ICategoryService _categoryService;    //Başka bir servis çağırılabilir fakat farklı bir dal çağrılmaz
        public ProductManager(IProductDAL iProductDAL, ICategoryService categoryService)
        {
            _iProductDAL = iProductDAL;
            _categoryService = categoryService;


        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {   
            
           IResult result=  BusinessRules.Run(CheckIfProductCategoryCountCorrect(product.CategoryID), CheckIfProductNameExists(product.ProductName));
            
            if (result!=null)
            {
                return result;
            }

            _iProductDAL.Add(product);
            return new SuccessResult(Messages.Added);

        }
        [CacheAspect]
        [PerformanceAspect(1)]
        public IDataResult<List<Product>> GetAll()
        {//iş kodları
            //koşullar sağlanıyor mu?

            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_iProductDAL.GetAll(),Messages.ListAll);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_iProductDAL.GetAll(p => p.CategoryID == id), Messages.ListOfDesiredFeature);
        }
        [CacheAspect]
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
        [CacheRemoveAspect("IProductService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCategoryCountCorrect(product.CategoryID), CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimit());

            if (result != null)
            {
                return result;
            }

            _iProductDAL.Update(product);
            return new SuccessResult(Messages.Uptated);

            
        }

        private IResult CheckIfProductCategoryCountCorrect(int CategoryId)
        {
            var result = _iProductDAL.GetAll(p => p.CategoryID == CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult();

            }
            return new SuccessResult();
        }


        private IResult CheckIfProductNameExists(string Name)
        {//var result=_iProductDAL.GetAll(p => p.ProductName == Name).Any();                 //bu yapıda eleman var mı?
            var result = _iProductDAL.GetAll();
            foreach (var product in result)
            {
                if (product.ProductName == Name) { return new ErrorResult(); }
                
            }  

            
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimit()
        {
            var result = _categoryService.GetAll().Data.Count;
            
                if (result>=15) { return new ErrorResult(); }

            

            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if (product.UnitPrice < 15)
            {
                throw new Exception("Fiyat 15 ten küçük");
            }
            Add(product);
            return null;
        }
    }
}
