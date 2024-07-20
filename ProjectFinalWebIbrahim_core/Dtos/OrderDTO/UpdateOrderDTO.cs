
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.OrderDTO
{
    public class UpdateOrderDTO
    {

        public int OrderId { get; set; }

       
        public OrderStatus? Status { get; set; }
    

        public DateTime? ModifiedDate { get; set; }=DateTime.Now;

       
    }
}
