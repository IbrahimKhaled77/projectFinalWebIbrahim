

namespace ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO
{
    public class UpdateOrderServiceDTO
    {
        public int OrderServiceId { get; set; }

        public int? OrderId { get; set; }

        public int? ServiceId { get; set; }


        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        public bool IsِActive { get; set; }
    }
}
