
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Model.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime DateOrder { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }

        //??
        // public PaymentMethod PaymentMethod { get; set; }

        //is deafult peding
        public OrderStatus Status { get; set; }
        public int Rate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool IsِActive { get; set; }

        public bool IsApproved { get; set; }
        public int? UsersId { get; set; }

      
    }
}
