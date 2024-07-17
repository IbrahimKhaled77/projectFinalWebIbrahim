using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalWebIbrahim_core.Model.Entity
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; } 
        public string CardNumber { get; set; }
        public string Code { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal? Balance { get; set; }

        public int? UsersId { get; set; }
    }
}
