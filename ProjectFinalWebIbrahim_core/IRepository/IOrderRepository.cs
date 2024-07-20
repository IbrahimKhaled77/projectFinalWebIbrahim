﻿using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;


namespace ProjectFinalWebIbrahim_core.IRepository
{
    //t
    public interface IOrderRepository
    {


        Task<List<GetOrderAllDTO>> GetOrderAll();

        Task<GetOrderDetailDTO> GetOrderByIdServ(int OrderId);

        Task<Order> GetOrderById(int OrderId);
        Task CreateOrder(Order Inpute);

        Task UpdateOrder(Order Inpute);
        Task DeleteOrder(Order Inpute);

        Task<PaymentMethod> IsValidPayment(string code, string cardNumber, string cardHolder, decimal Price);

        Task<PaymentMethod> GetPaymentMethodById(int PaymentMethodId);


        Task UpdatePaymentMethod(PaymentMethod Inpute);

    }
}
