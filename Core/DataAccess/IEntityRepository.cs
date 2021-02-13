using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {//GENERİC CONSTRAINT => generic kısıt
        //where T:class,IEntity,new()=> verdiğimiz Type hepsini kapsamayacak bizim belirlediğimiz IEntity tipinde newlenebilen classlar referans olarak verilecek.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter); //filtre zorunlu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
