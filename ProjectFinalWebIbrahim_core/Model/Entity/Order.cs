
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Model.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime DateOrder { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }

        public int Quantity { get; set; }

        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public string city { get; set; }

        public decimal? priceFinal2 { get; set; }
        public OrderStatus Status { get; set; }
        public int? Rate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }

        public bool? IsApproved { get; set; }
        public int? UsersId { get; set; }

        public int? ServiceId { get; set; }



    }
}
