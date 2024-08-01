using Microsoft.AspNetCore.Mvc;
using aula30.Models;
using aula30.Database;

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
    }
}
