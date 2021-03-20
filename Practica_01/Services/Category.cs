using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [Serializable]
    public class Category
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Nombre")]
        public string name { get; set; }
        [DisplayName("Estado")]
        public bool status { get; set; }

    }
}
