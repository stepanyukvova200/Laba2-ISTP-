using System.ComponentModel.DataAnnotations;

namespace Laba2Empty.Models
{
    public class Game
    {
        public Game()
        {
            Characters = new HashSet<Character>();
            Developers = new HashSet<Developer>();
        }

        public int ID { get; set; }
        public string GameName { get; set; }
        public string Info { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }
        public ICollection<Developer> Developers { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
