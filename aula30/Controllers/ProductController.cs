using Microsoft.AspNetCore.Mvc;
using aula30.Models;
using aula30.Database;
using System.Reflection.Metadata.Ecma335;

namespace aula30.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(product product)
        { 
           ProductDB productDB = new ProductDB();
            bool response = productDB.Add(product);

            if (response)
            {
                return new JsonResult(new { success = true, data = "Cadastrado" });
            }
            else
            {
                return new JsonResult(new { success = false, data = "Erro" });
            }
        }

        [HttpGet]
        [Route("get")]
        public JsonResult Get(int id) 
        {
            ProductDB productDB = new ProductDB();
            product product = productDB.get(id);

            if (product != null && product.Id > 0)
                return new JsonResult(new { success = true, data = product });

            else
                return new JsonResult(new { success = false, data = "erro" });
             
            
            
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        { 
           ProductDB ProductDB = new ProductDB();
            List<product> products = ProductDB.GetAll();

            if (products.Count > 0)
                return new JsonResult(new { success = true, data = products });
            else return new JsonResult(new { success = false, data = products });
        }

        [HttpPut]
        [Route("update")]

        public JsonResult update([FromBody] product product) 
            {
            ProductDB productDB = new ProductDB();
            bool success = productDB.Update(product);

            if (success)
                return new JsonResult(new { success = true, data = "ALTERADO" });
            else 
                return new JsonResult(new { success = false, data = "erro" });
        }

        [HttpDelete]
        [Route("Delete")]

        public JsonResult Delete(int id) 
        {
           ProductDB productDB= new ProductDB();

            bool success = productDB.Delete(id);

            if (success)
                return new JsonResult(new { success = true, data = "Excluido" });
            else
                return new JsonResult(new { success = false, data = "erro" });
        }


    }

}
