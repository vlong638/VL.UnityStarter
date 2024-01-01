using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 仓储模式
    /// </summary>
    public class Sample_Repository
    {
        public void Test()
        {
            var productRepository = new ProductRepository();
            productRepository.Add(new Product { Id = 1, Name = "Product 1", Price = 10.0m });
            productRepository.Add(new Product { Id = 2, Name = "Product 2", Price = 12.0m });
            var allProducts = productRepository.GetAll();
            foreach (var product in allProducts)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
            }
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }

    public class ProductRepository : IRepository<Product>
    {
        List<Product> products = new List<Product>();

        public void Add(Product Entity)
        {
            products.Add(Entity);
        }

        public void Delete(Product Entity)
        {
            products.Remove(Entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Product Entity)
        {
            var existingProduct = GetById(Entity.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = Entity.Name;
                existingProduct.Price = Entity.Price;
                //ORM.Mapping
            }
        }
    }


}