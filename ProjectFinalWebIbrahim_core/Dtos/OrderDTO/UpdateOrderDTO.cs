﻿
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.OrderDTO
{
    public class UpdateOrderDTO
    {

        public int OrderId { get; set; }

        public OrderStatus Status { get; set; }
        public int Rate { get; set; }

       
        public DateTime? ModifiedDate { get; set; }=DateTime.Now;

        public bool IsِActive { get; set; }
        public int? UsersId { get; set; }
    }
}
