using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colections
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        string Category { get; set; }
        int Quantity { get; set; }
    }
}
