using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {   //Context nesnesi db tabloları ile proje classlarını bağlamak(ilişkilendirmek) için kullanılır 
        //DbContext olarak tanımlamak zorundayız.


        //override dedikten sonra on yazınca aşağıdaki method geliyor olacak. Burası bizim hangi veritabanını ilişkilendireceğimizi belirtmek için kullancağımız yer 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }


        //hangi tablolar hangi classlarla ilişkili olduğunu belirtiyoruz
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
