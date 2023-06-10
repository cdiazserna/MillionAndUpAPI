namespace MillionAndUp.Models
{
    public class PropertyTrace : AuditBase
    {
        public DateTime? DateSale { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public decimal? Tax { get; set; }
        public Property? Property { get; set; }
    }
}
