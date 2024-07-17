using ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO;
using ProjectFinalWebIbrahim_core.Dtos.paymentMethodDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IPaymentMethodService
    {

        Task<string> CreatepaymentMethod(CreatepaymentMethodDTO Inpute);
    }
}
