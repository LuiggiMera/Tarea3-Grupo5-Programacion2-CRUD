using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class CategoryRepository
    {
        public List<Category> Categories {get; set;} = new List<Category>();
        public static CategoryRepository Instancia { get; } = new CategoryRepository();

        private CategoryRepository()
        {

        }
    }
}
