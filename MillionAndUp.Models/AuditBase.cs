namespace MillionAndUp.Models
{
    public class AuditBase
    {
        //public Guid? InsertedByEmployeeId { get; set; }
        //public Guid? UpdatedByEmployeeId { get; set; }
        public DateTime? Inserted { get; set; }
        public DateTime? Updated { get; set; }

    }
}