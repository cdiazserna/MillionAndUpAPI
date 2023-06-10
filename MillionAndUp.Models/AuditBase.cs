using System.ComponentModel.DataAnnotations;

namespace MillionAndUp.Models
{
    public class AuditBase
    {
        [Key]
        public Guid Id { get; set; }
        //public Guid? InsertedByEmployeeId { get; set; }
        //public Guid? UpdatedByEmployeeId { get; set; }
        public DateTime? InsertedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}