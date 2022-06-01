using System.ComponentModel.DataAnnotations;

namespace Laba2Empty.Models
{
    public class Country
    {
        public Country()
        {           
            Developers = new HashSet<Developer>();
        }

        [Key]
        public int ID { get; set; }
        public string CountryName { get; set; }

        public ICollection<Developer> Developers { get; set; }
    }
}
