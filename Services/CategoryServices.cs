using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices
    {
        public Serializer serializer;
        public string Directory;
        public string FileName;

        public CategoryServices()
        {
            serializer = new Serializer();
            Directory = "Category";
            FileName = "category.dat";

        }
        public bool Add(Category category)
        {
            try
            {
                CategoryRepository.Instancia.Categories.Add(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(int id, Category category)
        {
            try
            {
                CategoryRepository.Instancia.Categories[id - 1] = category;
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
                CategoryRepository.Instancia.Categories.RemoveAt(id - 1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Category> GetAll()
        {
            List<Category> categories = (List<Category>)serializer.Deserialize(Directory, FileName);
            if (categories != null)
            {
                CategoryRepository.Instancia.Categories = categories;
            }
            return CategoryRepository.Instancia.Categories;

        }
        public Category select(int id)
        {
            try
            {
                return CategoryRepository.Instancia.Categories[id - 1];
            }
            catch
            {
                return null;
            }
        }
    }
}
