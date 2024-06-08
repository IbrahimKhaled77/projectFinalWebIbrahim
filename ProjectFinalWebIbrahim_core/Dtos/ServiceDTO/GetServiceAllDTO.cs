
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.ServiceDTO
{
    public class GetServiceAllDTO
    {

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }


        public decimal PriceAfterDiscount { get; set; }
       



        public bool IsِActive { get; set; }

        public int? CategoryId { get; set; }

        public int? UserId { get; set; }

        public string ProviderUser { get; set; }
    }
}
