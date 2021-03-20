using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices
    {
        public Serializer serializer;
        public string Directory;
        public string FileName;

        public ProductServices()
        {
            serializer = new Serializer();
            Directory = "Product";
            FileName = "listProducts.dat";

        }
        public bool Add(Product product)
        {
            try
            {
                ProductRepository.Instancia.Products.Add(product);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool Edit(int id, Product product)
        {
            try 
            {
                ProductRepository.Instancia.Products[id - 1] = product;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                ProductRepository.Instancia.Products.RemoveAt(id - 1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Product> GetAll()
        {
            List<Product> product = (List<Product>)serializer.Deserialize(Directory, FileName);
            if(product != null)
            {
                ProductRepository.Instancia.Products = product;
            }
            return ProductRepository.Instancia.Products;

        }
        public Product select(int id)
        {
            try
            {
                return ProductRepository.Instancia.Products[id - 1];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
