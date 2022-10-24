namespace PrisonManagementWebApp.Models
{
    public class Meeting : Entity
    {
        public virtual Cell Prison { get; set; }
        public virtual Visitor Visitor { get; set; }
        public DateTime MeetingTime { get; set; }
    }
}