using System.ComponentModel.DataAnnotations;

namespace Laba2Empty.Models
{
    public class Developer
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int CountryID { get; set; }
        public string Type { get; set; }
        public string DeveloperName { get; set; }

        public Game Game { get; set; }
        public Country Country { get; set; }       
    }
}

