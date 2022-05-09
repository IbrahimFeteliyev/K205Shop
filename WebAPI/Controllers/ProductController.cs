using Buisness.Abstract;
using Buisness.Constans;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAllProduct()
        {
            var products = _productManager.GetAllProducts();

            if (products.Count == 0)
                return Ok(new { status = 200, message = "Hec bir mehsul tapilmadi." });

            return Ok(new { status = 200, message = products });
        }

        [HttpGet("productlist")]
        public IActionResult ProductList()
        {
            var productList = _productManager.GetAllProductList();

            return Ok(new { status = 200, message = productList });
        }


        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productManager.GetProductById(id);

            return Ok(new {status = 200, message = product});
        }
        [HttpPost("add")]
        public IActionResult Add(AddProductDTO product)
        {
            try
            {
                _productManager.Add(product);
            }
            catch(Exception e)
            {
                return Ok(new { status = 400, message = e });
            }
            
            return Ok(new { status = 200, message = "Mehsul elave olundu." });
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct(Product product)
        {
            _productManager.Update(product);
            return Ok(new { status = 200, message = product });
        }

        [HttpDelete("remove")]
        public IActionResult DeleteCategory(Product product)
        {
            _productManager.Remove(product);
            return Ok("Melumat ugurla silindi.");
        }
    }
}
