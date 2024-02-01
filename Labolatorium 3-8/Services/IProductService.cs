using Labolatorium_3_8.Models;

namespace Labolatorium_3_8.Services
{
    public interface IProductService
    {
        int Add(Product product);
        void Delete(int id);
        List<Product> GetAll();
        Product? GetById(int id);
        void Update(Product product);
        PagingList<Product> FindPage(int page, int size);
        IEnumerable<Product> GetFilteredProducts(ProductFilterModel filterModel);
        void AddSupplier(Supplier supplier);
        void AddShippingCarrier(ShippingCarrier shippingCarrier);
    }

}
