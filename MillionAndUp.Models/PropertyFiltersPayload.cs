namespace MillionAndUp.Models
{
    public class PropertyFiltersPayload
    {
        public string CodeInternal { get; set; }
        public string Address { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
