using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalWebIbrahim_infra.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly ProjectWebFinalDbContext _context;
        public PaymentMethodRepository(ProjectWebFinalDbContext context)
        {

            _context = context;


        }

        public async Task<PaymentMethod> IsValidPayment(string code, string cardNumber, string cardHolder, decimal Price)
        {
            var payment = await _context.PaymentMethod.FirstOrDefaultAsync
                (x => x.Balance >= Price && x.CardHolder.Equals(cardHolder)
                && x.CardNumber.Equals(cardNumber) && x.Code.Equals(code));
            return payment;
        }

        public async Task<PaymentMethod> GetPaymentMethodById(int PaymentMethodId)
        {
            var PaymentMethod = await _context.PaymentMethod.FindAsync(PaymentMethodId);

            return PaymentMethod;
        }


        public async Task CreatePaymentMethod(PaymentMethod Inpute)
        {
            _context.PaymentMethod.Add(Inpute);
            await _context.SaveChangesAsync();
        }


        public async Task UpdatePaymentMethod(PaymentMethod Inpute)
        {
            _context.PaymentMethod.Update(Inpute);
            await _context.SaveChangesAsync();
        }

    }
}
