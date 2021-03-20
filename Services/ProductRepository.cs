using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    
   public sealed class ProductRepository
   {
        public List<Product> Products { get; set; } = new List<Product>();
            public static ProductRepository Instancia { get; } = new ProductRepository();

            private ProductRepository()
            {
                
            }
   }

}

