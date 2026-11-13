using FirstProject.Data;
using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Services
{
    public class ProductService : IProductService {

        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products
                .OrderBy(p => p.Id)
                .ToListAsync();
        }


        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product?> UpdatedProduct(int id, UpdateProductDTO updateProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return null;
            }
            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;

            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product !=null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
            
        }
    }
}
