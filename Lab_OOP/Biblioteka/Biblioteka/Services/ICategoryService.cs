using Biblioteka.Models;

namespace Biblioteka.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int categoryId);
        Category GetCategoryById(int categoryId);
        List<Category> GetCategories();
    }
}
