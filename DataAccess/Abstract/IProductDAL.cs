using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDAL:IEntityRepository<Product>
    {//DAL: Data Access Layer
     //DAO: Data Access Object

        // DataAccess katmanına referans olarak Entities ekledir. Sağ tık yapıp add dedikten sonra Project Referans diyoruz.



        //sadece product ı ilgilendiren kodlar
        List<ProductDetailDTO> GetProductDetail();
    }
}
