using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colections
{
    public interface IStore<T> where T : IProduct
    {
        void Add(T product);
        void Remove(int id);
        T GetProductById(int id);
        void UpdatePrice(int id, double newPrice);
        void UpdateQuantity(int id, int newQuantity);
        List<T> GetProductsByCategory(string category);
        Dictionary<string, List<T>> GroupByCategory();
    }
}
