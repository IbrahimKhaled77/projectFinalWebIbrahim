using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.paymentMethodDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class paymentMethodService : IPaymentMethodService
    {

        private readonly IOrderRepository _IOrderRepository;
        private readonly IUserRepository _IUserRepository;
        private readonly IPaymentMethodRepository _IPaymentMethodRepository;

        public paymentMethodService(IOrderRepository IOrderRepository, IUserRepository IUserRepository, IPaymentMethodRepository iPaymentMethodRepository)
        {

            _IOrderRepository = IOrderRepository;
            _IUserRepository = IUserRepository;
            _IPaymentMethodRepository = iPaymentMethodRepository;
        }
        public async Task<string> CreatepaymentMethod(CreatepaymentMethodDTO Inpute)
        {

            try
            {

                Log.Information("paymentMethod Is strating CreatepaymentMethod");

                var user = await _IUserRepository.GetUserById(Inpute.UsersId);

                var paymentMethod = new PaymentMethod
                {
                    
                    ExpireDate = Inpute.ExpireDate,
                    Code = Inpute.Code,
                    CardNumber = Inpute.CardNumber,
                    CardHolder = Inpute.CardHolder,
                    Balance = Inpute.Balance,
                    UsersId = user.UserId,
                

                };

                if (paymentMethod != null)
                {

                    await _IPaymentMethodRepository.CreatePaymentMethod(paymentMethod);

                    Log.Information("paymentMethod Is CreatePaymentMethod");
                    Log.Debug($"Debugging Get Category By Id Has been Finised Successfully With paymentMethod ID  = {paymentMethod.PaymentMethodId}");

                    return "AddpaymentMethod Has been Finised Successfully ";
                }
                else
                {
                    Log.Error($"paymentMethod Not Found");
                    throw new ArgumentNullException("paymentMethod", "Not Found paymentMethod");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Category Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }
        }


        public async Task<string> UpdatePaymentMethod(UpdatePaymentMethodDTo Inpute)
        {
            try
            {

                Log.Information("PaymentMethod Is strating UpdatePaymentMethod");

                var user = await _IUserRepository.GetUserById(Inpute.UsersId);
                var PaymentMethod = await _IPaymentMethodRepository.GetPaymentMethodById(Inpute.PaymentMethodId);
                if ( user != null  && PaymentMethod !=null)
                {
                    PaymentMethod.ExpireDate = Inpute.ExpireDate;
                    PaymentMethod.CardNumber = Inpute.CardNumber;
                    PaymentMethod.Code = Inpute.Code;
                    PaymentMethod.Balance = Inpute.Balance;
                    PaymentMethod.CardHolder= Inpute.CardHolder;






                    await _IPaymentMethodRepository.UpdatePaymentMethod(PaymentMethod);


                    Log.Information("PaymentMethod Is Updated");
                    Log.Debug($"Debugging Get Order By Id Has been Finised Successfully With Order ID  = {PaymentMethod.PaymentMethodId}");

                    return "UpdatePaymentMethod success";

                }
                else
                {
                    Log.Error($"PaymentMethod Not Found");
                    throw new ArgumentNullException("PaymentMethod", "Not Found PaymentMethod");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Order Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }
        }

    }
}
