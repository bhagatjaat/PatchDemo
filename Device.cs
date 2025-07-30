namespace PatchManagementApi.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Hostname { get; set; } = string.Empty;
        public string OS { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
    }
}
