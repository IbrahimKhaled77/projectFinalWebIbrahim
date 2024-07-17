

using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.OrderDTO
{
    public class CreateOrderDTO
    {
       
        public DateTime         DateOrder                   { get; set; }
        public string           Title                         { get; set; }
        public string           Note                          { get; set; }
      //  public PaymentMethod    PaymentMethod          { get; set; }
        public OrderStatus      Status                   { get; set; }
        public int              Rate                             { get; set; }

        public DateTime?        CreationDate               { get; set; } = DateTime.Now;



        public bool             IsِActive                        { get; set; }
        public int?             UsersId                          { get; set; }
    }
}
