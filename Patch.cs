namespace PatchManagementApi.Models
{
    public class Patch
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Vendor { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
    }
}

