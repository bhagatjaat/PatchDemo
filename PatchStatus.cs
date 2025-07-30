namespace PatchManagementApi.Models
{
    public class PatchStatus
    {
        public int Id { get; set; }

        public int PatchId { get; set; }
        public Patch Patch { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public bool IsApplied { get; set; }
        public DateTime AppliedOn { get; set; }
    }
}
