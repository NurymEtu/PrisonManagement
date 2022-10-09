namespace PrisonManagementWebApp.Models
{
    public class Prison : Entity
    {
        public string Name { get; set; }

        public int Number { get; set; }
        public List<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
        public int Capacity { get; set; }
        public Supervisor Supervisor { get; set; }
    }
}