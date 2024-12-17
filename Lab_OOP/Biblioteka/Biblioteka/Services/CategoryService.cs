using Biblioteka.Models;

namespace Biblioteka.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _categories = new List<Category>();
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public CategoryService(IEmailService emailService, IUserService userService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        public void AddCategory(Category category)
        {
            category.Id = _categories.Count > 0 ? _categories.Max(c => c.Id) + 1 : 1;
            _categories.Add(category);
        }

        public void EditCategory(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
            }
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.Id == categoryId);
        }

        public List<Category> GetCategories()
        {
            return _categories;
        }
    }
}
