
namespace ProjectFinalWebIbrahim_core.Model.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime DateOrder { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public int Rate { get; set; }

        public int? UsersId { get; set; }

      
    }
}
