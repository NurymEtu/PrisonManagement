using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace PrisonManagementWebApp.Models
{
    public class Supervisor : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; } = "https://www.cdcr.ca.gov/mov/wp-content/uploads/sites/200/2021/08/Campbell_Beau_3-768x1024.jpg";
        [Required]
        private int age;
        public int Age { get { return age; } set { age = DateTime.Now.Year - Birthday.Year; } }

        public string Genger { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}