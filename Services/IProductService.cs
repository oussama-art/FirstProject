using FirstProject.Models;

namespace FirstProject.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();

        Task<Product> AddProduct(Product product);

        Task<Product?> GetProductById(int id);

        Task<Product?> UpdatedProduct(int id, UpdateProductDTO updateProduct);

        Task<bool> DeleteProduct(int id);
    }
}
