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
            productRepository.Add(new ProductA { Id = 1, Name = "Product 1", Price = 10.0m });
            productRepository.Add(new ProductA { Id = 2, Name = "Product 2", Price = 12.0m });
            var allProducts = productRepository.GetAll();
            foreach (var product in allProducts)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
            }
        }
    }
    public class ProductA
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

    public class ProductRepository : IRepository<ProductA>
    {
        List<ProductA> products = new List<ProductA>();

        public void Add(ProductA Entity)
        {
            products.Add(Entity);
        }

        public void Delete(ProductA Entity)
        {
            products.Remove(Entity);
        }

        public IEnumerable<ProductA> GetAll()
        {
            return products;
        }

        public ProductA GetById(int id)
        {
            return products.FirstOrDefault(c => c.Id == id);
        }

        public void Update(ProductA Entity)
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