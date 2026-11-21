using Microsoft.AspNetCore.Mvc;
using Session_1___MVC.Filters;
using Session_1___MVC.Models;

namespace Session_1___MVC
{
    public class ProductController : Controller
    {
        #region Actions

        [NonAction]
        public ContentResult TestAction()
        {
            return Content("hello");
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = new List<Product>()
            { new Product {id = 10 , Name = "Lap"},
            new Product {id = 11 , Name = "Mobile" } };

            return Json(products);
        }

        public IActionResult GetProductById(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Index));
            else if (id < 10)
                return NotFound();
            else
                return Json(new Product() { id = id, Name = "Iphone" });

        }
        #endregion

        #region Routing

        [HttpGet("Json")]
        public IActionResult JsonAction()
        {
            return Json("Hello from json Action");
        }
        #endregion

        #region Model Binding

        public IActionResult Search(ProductFilter filter)
        {
            return View();
        }

        public IActionResult GetById([FromQuery] int id, [FromQuery(Name = "Id02")] int otherId)
        {
            return Json("");
        }
        #endregion 
    }
}
