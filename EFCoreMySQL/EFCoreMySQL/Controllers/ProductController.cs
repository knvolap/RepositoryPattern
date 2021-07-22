using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
using EFCoreMySQL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private MyDBContext myDbContext;
        private readonly IProduct iProduct;


        public ProductController(MyDBContext context, IProduct product)
        {
            myDbContext = context;
            this.iProduct = product;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return iProduct.getListProduct();
        }


        [HttpPost]
        public IActionResult addProduct(Product product)
        {
         
            if(product == null)
            {
                return BadRequest();
            }
            iProduct.addProduct(product);
            return Ok();
        }

        [HttpPut]
        public IActionResult editProduct(Product product)
        {

            if (product == null)
            {
                return BadRequest();
            }
            iProduct.editProduct(product);
            return Ok();
        }

        [HttpDelete]
        public IActionResult deleteProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            iProduct.deleteProduct(product.IDProduct);
            return Ok();
        }
    }
}
