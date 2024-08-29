


using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Model.Entity
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? imagetitleservice { get; set; }
        public decimal Price { get; set; }
        public string TitleArabic { get; set; }
        public string DescriptionArabic { get; set; }
        public decimal PriceAfterDiscount { get; set; }

        public QuantityUnitType? QuantityUnit { get; set; }
        public bool? IsHaveDiscount { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string? DiscountType { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }

        public bool? IsApproved { get; set; }    
        public int? CategoryId { get; set; }

        public int? UserId{ get; set; }

    }
}
