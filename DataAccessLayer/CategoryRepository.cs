using BusinessObjects;

namespace DataAccessLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;

        public CategoryRepository()
        {
            categories = DataContext.Instance.Categories;
        }

        public IEnumerable<Category> GetAll() => categories;

        public Category? GetById(int id) => categories.FirstOrDefault(c => c.CategoryID == id);

        public void Add(Category category) => categories.Add(category);

        public void Update(Category category)
        {
            var existing = GetById(category.CategoryID);
            if (existing != null)
            {
                existing.CategoryName = category.CategoryName;
                existing.Description = category.Description;
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null) categories.Remove(category);
        }
    }
}