using Domain;

namespace Persistence.IRepository;


public interface IProductRepository
{
     Task<List<Product>> getAllProduct();
     Task<Product> getProduct(Guid slug);
}
