using FirstProject.Models;
using FirstProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var products = await _productService.GetProducts();
            return Ok(products);

        }



        //[HttpPost]
        //public ActionResult<Product> CreateProduct(
        //    [FromBody] Product product)
        //{
        //    var newProduct = _productService.AddProduct(product);

        //    return Ok(newProduct);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO productdto)
        {
            Product newProduct = new Product
            {
                Name = productdto.Name,
                Price = productdto.Price
            };

            await _productService.AddProduct(newProduct);

            return Ok(newProduct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Produit n'existe pas");
            }
            return Ok(product); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id,UpdateProductDTO updatedProduct)
        {
            var product = await _productService.UpdatedProduct(id, updatedProduct);
            if (product == null)
            {
                return NotFound("Produit n'existe pas dans la base de donnees");
            }
            return product;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool deletedProduct = await _productService.DeleteProduct(id);
            if (deletedProduct)
            {
                return Content("Porduit supprime");
            }

            return NotFound("Produit n'existe pas");

        }

        
    }
}
