
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.ServiceDTO
{
    public class UpdateServiceDTO
    {


        public int ServiceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }

        public decimal? PriceAfterDiscount { get; set; }

        public QuantityUnitType? QuantityUnit { get; set; }
        public bool? IsHaveDiscount { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string? DiscountType { get; set; }


        public DateTime? ModifiedDate { get; set; }=DateTime.Now;

        public bool? IsِActive { get; set; }

       // public int? CategoryId { get; set; }

       // public int? UserId { get; set; }
    }
}
