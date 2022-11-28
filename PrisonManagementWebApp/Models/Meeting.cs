namespace PrisonManagementWebApp.Models
{
    public class Meeting : Entity
    {
        public Guid PrisonerId { get; set; }
        public Guid VisitorId { get; set; }

        public virtual Prisoner Prisoner { get; set; }
        public virtual Visitor Visitor { get; set; }
        public DateTime MeetingTime { get; set; }
    }
}