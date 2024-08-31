
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class OrderServices:IOrderService
    {

        private readonly IOrderRepository _IOrderRepository;
        private readonly IUserRepository _IUserRepository;
        private readonly IServiceRepository _IServiceRepository;
        public OrderServices(IServiceRepository IServiceRepository,IOrderRepository IOrderRepository , IUserRepository IUserRepository)
        {

            _IOrderRepository = IOrderRepository;
            _IUserRepository = IUserRepository;
                 _IServiceRepository = IServiceRepository;
        }



        
        public async Task<List<GetOrderAllDTO>> GetOrderAll(bool? IsApproved)
        {
            return await _IOrderRepository.GetOrderAll(IsApproved);
        }

        public async Task<List<GetOrderAllDTO>> GetOrderAlUser(int userId)
        {
            return await _IOrderRepository.GetOrderAllUser(userId);
        }



        public async Task<GetOrderDetailDTO> GetOrderById(int OrderId)
        {
            return await _IOrderRepository.GetOrderByIdServ(OrderId);
        }


        public async Task<int> CreateOrder(CreateOrderDTO Inpute,int serviceId)
        {
            try
            {
                

                var user = await _IUserRepository.GetUserById((int)Inpute.UsersId);

                var Serveic = await _IServiceRepository.GetServiceById((int)serviceId);


                Log.Information("Order Is strating CreateOrder");

                if (user != null && Serveic !=null) {




                    var Order = new Order
                    {


                        ModifiedDate = null,
                        Title = Inpute.Title,
                        Note = Inpute.Note,
                        DateOrder = Inpute.DateOrder,
                        Status = OrderStatus.Pending,
                        Quantity = Inpute.Quantity,
                        ServiceId = Serveic.ServiceId,
                        Rate = 0,
                        UsersId = user.UserId,
                        IsActive = true,
                        CreationDate = DateTime.Now,
                        Address1 = Inpute.Address1,
                        Address2 = Inpute.Address2,
                        city = Inpute.city,
                        IsApproved = false,
                        
                        priceFinal2 = Inpute.Quantity * Serveic.PriceAfterDiscount,
                    };




                    if (Order != null)
                    {
                       


                      var OrderId = await _IOrderRepository.CreateOrder(Order);


                      //  Inpute.OrderId = OrderId;


                     //   await _IOrderRepository.UpdateOrder(Order);


                        //Payment 
                        var paymentMethods = await _IOrderRepository.IsValidPayment(Inpute.Code, Inpute.CardNumber, Inpute.CardHolder, (decimal)Order.priceFinal2);
                        if (paymentMethods != null)
                        {
                            paymentMethods.Balance -= Order.priceFinal2;
                            await _IOrderRepository.UpdatePaymentMethod(paymentMethods);


                            Log.Information("Order Is Created");
                            Log.Debug($"Debugging Get Order By Id Has been Finised Successfully With Order ID  = {Order.OrderId}");

                            return OrderId;
                        }
                        else
                        {

                            paymentMethods.Balance += Order.priceFinal2;
                            await _IOrderRepository.UpdatePaymentMethod(paymentMethods);

                            Log.Error($"OrderService Not Found");
                            throw new ArgumentNullException("OrderService", "Not Found OrderService");
                        }



                    }

                    else
                    {
                        throw new Exception("Invalid Payment Method");
                    }



                   



                    }
                   


               

                else {

                    throw new Exception("User Dose not Exisit");
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




        public async Task<string> UpdateOrder(UpdateOrderDTO Inpute)
        {
            try
            {

                Log.Information("Order Is strating UpdateOrder");

                var Order = await _IOrderRepository.GetOrderById(Inpute.OrderId);
             //   var user = await _IUserRepository.GetUserById((int)Inpute.UsersId);

                if (Order != null )
                {


                    if (Inpute.Status != null)
                    {
                        Order.Status = (OrderStatus)Inpute.Status;

                    }
                    Order.ModifiedDate = DateTime.Now;

                   


                 
                 
                    



                    await _IOrderRepository.UpdateOrder(Order);


                    Log.Information("Order Is Updated");
                    Log.Debug($"Debugging Get Order By Id Has been Finised Successfully With Order ID  = {Order.OrderId}");

                    return "UpdateOrder success";

                }
                else
                {
                    Log.Error($"Order Not Found");
                    throw new ArgumentNullException("Order", "Not Found Order");

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


        public async Task<string> Rating(RatingDTO Inpute) {

            try
            {

                Log.Information("Order Is strating UpdateOrder");

                var Order = await _IOrderRepository.GetOrderById(Inpute.OrderId);
                

                if (Order != null)
                {


                    if (Order.Status == OrderStatus.Delivered) {

                        if (Inpute.Rate != null)
                        {
                            Order.Rate = (int)Inpute.Rate;
                        }
                        Order.ModifiedDate = DateTime.Now;


                    }


                  


                    await _IOrderRepository.UpdateOrder(Order);


                    Log.Information("Order Is Updated Rating");
                    Log.Debug($"Debugging Get Order By Id Has been Finised Successfully With Order ID  = {Order.OrderId}");

                    return "UpdateOrder  Rating success";

                }
                else
                {
                    Log.Error($"Order Not Found");
                    throw new ArgumentNullException("Order", "Not Found Order");

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


        public async Task<string> DeleteOrder(int OrderId)
        {
            try
            {
                Log.Information("Order Is strating DeleteOrder");

                var Order = await _IOrderRepository.GetOrderById(OrderId);

                if (Order != null)
                {

                    await _IOrderRepository.DeleteOrder(Order);


                    Log.Information("Order Is Deleted");
                    Log.Debug($"Debugging Get Order By Id Has been Finised Successfully With Order ID  = {Order.OrderId}");

                    return "Order success";

                }
                else
                {
                    Log.Error($"Order Not Found");
                    throw new ArgumentNullException("Order", "Not Found Order");

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



        public async Task UpdateOrderApprovment(int Id, bool value)
        {
            var Order = await _IOrderRepository.GetOrderById(Id);
            if (Order != null)
            {
                Order.IsApproved = value;
                if (value==true) {
                    Order.Status = OrderStatus.Shipped;

                }
                else {
                    Order.Status = OrderStatus.Cancelled;
                }


                await _IOrderRepository.UpdateOrder(Order);
            }
            else
            {
                throw new Exception("Order Dose not Exisit");
            }
        }


        public async Task UpdateOrderActivation(int Id, bool value)
        {
            var Order = await _IOrderRepository.GetOrderById(Id);
            if (Order != null)
            {
                Order.IsActive = value;
                await _IOrderRepository.UpdateOrder(Order);
            }
            else
            {
                throw new Exception("Order Dose not Exisit");
            }
        }



    }
}
