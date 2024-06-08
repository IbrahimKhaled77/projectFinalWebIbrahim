

namespace ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO
{
    public class GetOrderServiceDetailDTO
    {

        public int OrderServiceId { get; set; }

        public int? OrderId { get; set; }

        public int? ServiceId { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool IsِActive { get; set; }
    }
}
