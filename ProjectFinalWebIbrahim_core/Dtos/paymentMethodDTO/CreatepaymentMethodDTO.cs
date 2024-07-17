

namespace ProjectFinalWebIbrahim_core.Dtos.paymentMethodDTO
{
    public class CreatepaymentMethodDTO
    {

        public string CardNumber { get; set; }
        public string Code { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal? Balance { get; set; }

        public int? UsersId { get; set; }
    }
}
