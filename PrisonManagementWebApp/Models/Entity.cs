namespace PrisonManagementWebApp.Models
{
    public class Entity
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
    }
}