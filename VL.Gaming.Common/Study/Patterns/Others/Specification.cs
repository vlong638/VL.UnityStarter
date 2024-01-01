using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// 规约模式
    /// </summary>
    public class Sample_Specification
    {
        public void Test()
        {
            // 使用产品仓储和规约
            var productRepository = new ProductBRepository();

            // 添加一些产品
            productRepository.AddProduct(new ProductB { Id = 1, Name = "Product A", Price = 10.0m });
            productRepository.AddProduct(new ProductB { Id = 2, Name = "Product B", Price = 20.0m });

            // 使用规约查找产品
            var priceSpec = new PriceSpecification(15.0m);
            var productsWithPriceAbove15 = productRepository.FindProducts(priceSpec);
            foreach (var product in productsWithPriceAbove15)
            {
                Console.WriteLine($"Product with price above 15: {product.Name}, Price: {product.Price}");
            }

            var nameSpec = new NameSpecification("A");
            var productsWithNameContainingA = productRepository.FindProducts(nameSpec);
            foreach (var product in productsWithNameContainingA)
            {
                Console.WriteLine($"Product with name containing 'A': {product.Name}, Price: {product.Price}");
            }
        }
    }

    public class ProductB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
    public class PriceSpecification : ISpecification<ProductB>
    {
        private readonly decimal _minPrice;

        public PriceSpecification(decimal minPrice)
        {
            _minPrice = minPrice;
        }

        public bool IsSatisfiedBy(ProductB product)
        {
            return product.Price >= _minPrice;
        }
    }
    public class NameSpecification : ISpecification<ProductB>
    {
        private readonly string _name;

        public NameSpecification(string name)
        {
            _name = name;
        }

        public bool IsSatisfiedBy(ProductB product)
        {
            return product.Name.Contains(_name);
        }
    }
    public class ProductBRepository
    {
        private List<ProductB> _products = new List<ProductB>();

        public void AddProduct(ProductB product)
        {
            _products.Add(product);
        }

        public IEnumerable<ProductB> FindProducts(ISpecification<ProductB> specification)
        {
            return _products.Where(specification.IsSatisfiedBy);
        }
    }
}