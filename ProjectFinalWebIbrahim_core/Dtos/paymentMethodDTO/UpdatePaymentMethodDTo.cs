using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalWebIbrahim_core.Dtos.paymentMethodDTO
{
    public  class UpdatePaymentMethodDTo
    {
        
         public int? UsersId { get; set; }
        public int PaymentMethodId { get; set; }  
        public string CardNumber { get; set; }
        public string Code { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal? Balance { get; set; }

    }
}
