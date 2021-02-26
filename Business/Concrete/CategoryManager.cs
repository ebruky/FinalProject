using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    { //iş kodları


        ICategoryDAL _icategoryDAL;

        public CategoryManager(ICategoryDAL icategoryDAL)
        {
            _icategoryDAL = icategoryDAL;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_icategoryDAL.GetAll());
        }

        public IDataResult<Category> GetById(int Id)
        {
            return new SuccessDataResult<Category>(_icategoryDAL.Get(c=>c.CategoryID==Id));
        }
    }
}
