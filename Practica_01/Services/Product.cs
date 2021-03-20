using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [Serializable]
    public class Product
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Nombre del Producto")]
        public string name { get; set; }
        [DisplayName("Código")]
        public string codigo { get; set; }
        [DisplayName("Stock")]
        public string stock { get; set; }
        [DisplayName("Fecha de Vencimiento")]
        public DateTime exDate { get; set; }
        [DisplayName("Descripción")]
        public string description { get; set; }
        [DisplayName("Categoria")]
        public int category { get; set; }
        [DisplayName("Estado")]
        public bool status { get; set; }
    }
}
