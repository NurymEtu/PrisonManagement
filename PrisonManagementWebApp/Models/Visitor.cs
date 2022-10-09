using System.ComponentModel.DataAnnotations;

namespace PrisonManagementWebApp.Models
{
    public class Visitor : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genger { get; set; }
        public string Image { get; set; } = "https://media-cldnry.s-nbcnews.com/image/upload/t_nbcnews-fp-1200-630,f_auto,q_auto:best/newscms/2015_09/907176/150226-jail-visitation-video-2.jpg";
    }
}