namespace Biblioteka.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Category> FavoriteCategories { get; set; } = new List<Category>();
    }

}
