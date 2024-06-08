
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.OrderDTO
{
    public class GetOrderAllDTO
    {

        public int                  OrderId                                                  { get; set; }
        public DateTime             DateOrder                                                           { get; set; }
        public string               Title                                                             { get; set; }
        public OrderStatus              Status                                       { get; set; }
        public int                   Rate                                                     { get; set; }

        public bool                 IsِActive                                            { get; set; }
        public int?                 UsersId                                                     { get; set; }
    }
}
