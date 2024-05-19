

namespace ProjectFinalWebIbrahim_core.Model.Entity
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsHaveDiscount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string DiscountType { get; set; }

        public int? CategoryId { get; set; }


    }
}
