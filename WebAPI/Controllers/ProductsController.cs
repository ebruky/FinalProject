using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]            //attribute
    public class ProductsController : ControllerBase
    {


        //IoC Container --- Inversion of    Control  ,,  startup ta ConfigureServices metotunu kullan 



        IProductService _productService;

        public ProductsController(IProductService ıproductService)
        {
            _productService = ıproductService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            
            var result =_productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {

            var result = _productService.Add(product);
            if (result.Success)
                {
                    return Ok(result);
                }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {

            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}

