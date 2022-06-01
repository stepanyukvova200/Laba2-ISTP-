using System.ComponentModel.DataAnnotations;

namespace Laba2Empty.Models
{
    public class Character
    {

        public int ID { get; set; }
        public string CharacterName { get; set; }
        public int GameID { get; set; }

        public Game Game { get; set; }

    }
}
