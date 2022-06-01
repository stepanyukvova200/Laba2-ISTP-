using System.ComponentModel.DataAnnotations;

namespace Laba2Empty.Models
{
    public class Category
    {
        public Category()
        {
            Games = new HashSet<Game>();            
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
