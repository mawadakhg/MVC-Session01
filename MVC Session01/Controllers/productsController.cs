
using Microsoft.AspNetCore.Mvc;
using MVC_Session01.Models;

namespace MVC_Session01.Controllers
{
    public class ProductsController : Controller
    {
        // baseUrl/products
        public IActionResult Index()
        {
            // Get all products
            return View();
        }

        #region Get Products

        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = new List<product>()
            {
                new product() { Id = 1, Name = "Product 1" },
                new product() { Id = 2, Name = "Product 2" },
                new product() { Id = 3, Name = "Product 3" },
            };

            return Json(products);
        }

        #endregion

        #region Get Product By ID

        [HttpGet]
        public IActionResult GetProductByID(int ID)
        {
            if (ID < 0)
                return BadRequest();

            else if (ID == 0)
                return RedirectToAction(nameof(Index));

            else
                return Json(new product()
                {
                    Id = ID,
                    Name = "Product " + ID
                });
        }

        #endregion
        [HttpGet]
        public IActionResult redirection()
        {
            return Redirect("https://routeeg.com/assignments/6afe18adb7a79a9ebff07259");
        }

        [HttpGet]
        public IActionResult fileAction()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("wwwroot/files/routeeg.pdf");
            return File(fileBytes, "application/pdf", "routeeg.pdf");
        }


    }
}
