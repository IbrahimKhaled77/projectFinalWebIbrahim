

namespace ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO
{
    public class CreateOrderServiceDTO
    {
      

        public int? OrderId         { get; set; }

        public int? ServiceId { get; set; }


        public DateTime? CreationDate { get; set; }= DateTime.Now;


        public bool IsِActive { get; set; }
    }
}
