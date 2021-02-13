using Business.Abstract;
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

        public List<Category> GetAll()
        {
            return _icategoryDAL.GetAll();
        }

        public Category GetById(int Id)
        {
            return _icategoryDAL.Get(c => c.CategoryID == Id);
        }
    }
}
