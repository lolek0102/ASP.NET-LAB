using System.Collections.Generic;

namespace Labolatorium_3_8.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
