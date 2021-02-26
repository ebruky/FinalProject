using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            EfCategoryDAL cd = new EfCategoryDAL();
            CategoryManager cm = new CategoryManager(cd);
            foreach (var category in cm.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
            Console.WriteLine("------------------------------------");
            Category c = new Category { CategoryName = "İçecek" };
            cd.Add(c);
            foreach (var category in cm.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //ProductManager pm = new ProductManager(new InMemoryProductDAL());
            //foreach (var item in pm.GetAll())
            //{
            //    Console.WriteLine(item.ProductName);
            //}
            ICategoryService categoryService = new CategoryManager(new EfCategoryDAL());
            EfProductDAL pd = new EfProductDAL();
            ProductManager pm1 = new ProductManager(pd, categoryService);



            //foreach (var item in pm1.GetAll())
            //{
            //    Console.WriteLine(item.ProductName);
            //}

            //foreach (var item in pm1.GetAllByCategoryId(2))
            //{
            //    Console.WriteLine(item.ProductName);
            //}

            //foreach (var item in pm1.GetByUnitPrice(50, 100))
            //{
            //    Console.WriteLine(item.ProductName);
            //}
            var result = pm1.GetProductDetail();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName + "     " + item.CategoryName);

                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
