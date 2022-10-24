using System.ComponentModel.DataAnnotations;

namespace PrisonManagementWebApp.Models
{
    public class Prisoner : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genger { get; set; }="Мужчина";
        [Required]
        public DateTime Birthday { get; set; } = new DateTime(2000, 1, 1);
        [Required]
        public string Image { get; set; } = "https://i5.walmartimages.com/asr/792b989e-828f-4436-948c-24f346818a2c_1.f5504e1f06fc236de5543e767c987d10.jpeg";
        [Required]
        public string FingetPrint { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Fingerprint_picture.svg/1413px-Fingerprint_picture.svg.png";
        public int PrisonNumber { get; set; }
        public string? ContactName { get; set; }
        public string? ContactRelation { get; set; }
        public string? ContactContact { get; set; }
        [Required]
        public DateTime TimeServeStarts { get; set; }=DateTime.Now;
        [Required]
        public DateTime TimeServeEnds { get; set; } = new DateTime(2040, 1, 1);
        public string CrimeCommitter { get; set; } = "Суд Ахмет Ахметович";
        public string CrimeDetails { get; set; }="Убил";

    }
}