namespace PrisonManagementWebApp.Models
{
    public class CameraLive : Entity
    {
        public string CamNumber { get; set; }
        public string LiveUrl { get; set; } = "https://www.youtube.com/watch?v=jfKfPfyJRdk";
    }
}