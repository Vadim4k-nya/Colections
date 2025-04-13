using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colections
{
    public class Store<T> : IStore<T> where T : IProduct
    {

        private List<T> _products = new List<T>();

        public void Add(T product)
        {
            if (_products.Any(p => p.Id == product.Id))
            {
                throw new ArgumentException($"Товар с Id {product.Id} уже существует.");
            }
            _products.Add(product);
        }

        public void Remove(int id)
        {
            var productToRemove = GetProductById(id);
            if (productToRemove == null)
            {
                throw new InvalidOperationException($"Товар с Id {id} не найден.");
            }
            _products.Remove(productToRemove);
        }

        public T GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePrice(int id, double newPrice)
        {
            var productToUpdate = GetProductById(id);
            if (productToUpdate == null)
            {
                throw new ArgumentException($"Товар с Id {id} не найден.");
            }
            productToUpdate.Price = newPrice;
        }

        public void UpdateQuantity(int id, int newQuantity)
        {
            var productToUpdate = GetProductById(id);
            if (productToUpdate == null)
            {
                throw new ArgumentException($"Товар с Id {id} не найден.");
            }
            productToUpdate.Quantity = newQuantity;
        }

        public List<T> GetProductsByCategory(string category)
        {
            return _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Dictionary<string, List<T>> GroupByCategory()
        {
            return _products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.ToList());
        }

        public void ListAllProducts(bool groupByCategory = false)
        {
            if (groupByCategory)
            {
                var groupedProducts = GroupByCategory();
                foreach (var categoryGroup in groupedProducts)
                {
                    Console.WriteLine($"Категория: {categoryGroup.Key}");
                    foreach (var product in categoryGroup.Value)
                    {
                        Console.WriteLine($"- {product}");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Список всех товаров:");
                foreach (var product in _products)
                {
                    Console.WriteLine($"- {product}");
                }
            }
        }
    }
}
