namespace PrisonManagementWebApp.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
    }
}