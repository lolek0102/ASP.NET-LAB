using Labolatorium_3_8.Models;
using System.Collections.Generic;
using System.Linq;
using Labolatorium_3_8.Data;
using System;

namespace Labolatorium_3_8.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IDateTimeProvider _timeProvider;

        public ProductService(AppDbContext context, IDateTimeProvider timeProvider)
        {
            _context = context;
            _timeProvider = timeProvider;
        }
        public IEnumerable<Product> GetFilteredProducts(ProductFilterModel filterModel)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filterModel.Name))
            {
                query = query.Where(p => p.Name.Contains(filterModel.Name));
            }
            if (filterModel.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= filterModel.MinPrice.Value);
            }
            if (filterModel.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= filterModel.MaxPrice.Value);
            }

            return query.ToList();
        }

        public PagingList<Product> FindPage(int page, int size)
        {
            var query = _context.Products.AsQueryable();
            var totalItems = query.Count();
            var products = query.Skip((page - 1) * size).Take(size).ToList();
            return new PagingList<Product>(products, totalItems, page, size);
        }

        public int Add(Product product)
        {
            product.ProductionDate = _timeProvider.GetCurrentTime();
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                _context.Entry(existingProduct).CurrentValues.SetValues(product);
                _context.SaveChanges();
            }
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void AddShippingCarrier(ShippingCarrier shippingCarrier)
        {
            _context.ShippingCarriers.Add(shippingCarrier);
            _context.SaveChanges();
        }
    }
}

