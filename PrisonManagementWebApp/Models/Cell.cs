namespace PrisonManagementWebApp.Models
{
    public class Cell : Entity
    {
        public int CellNumber { get; set; }
        public virtual List<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
        public virtual List<Guard> Guards { get; set; } = new List<Guard>();
        public virtual List<CameraLive> CameraLives { get; set; } = new List<CameraLive>();
    }
}