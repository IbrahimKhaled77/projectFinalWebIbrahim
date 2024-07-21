





using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class OrderServiceService : IOrderServiceService
    {

        private readonly IOrderServiceRepository _IOrderServiceRepository;
        private readonly IOrderRepository _IOrderRepository;
        private readonly IServiceRepository _IServiceRepository;
       
        public OrderServiceService(IOrderServiceRepository IOrderServiceRepository, IOrderRepository iOrderRepository, IServiceRepository IServiceRepository)
        {

            _IOrderServiceRepository = IOrderServiceRepository;
            _IOrderRepository = iOrderRepository;
            _IServiceRepository = IServiceRepository;
           
        }
        public async Task<List<GetOrderServiceAllDTO>> GetOrderServiceAll()
        {
            return await _IOrderServiceRepository.GetOrderServiceAll();
        }

        public async Task<GetOrderServiceDetailDTO> GetOrderServiceById(int OrderServiceId)
        {
            try
            {

                Log.Information("Order Is In GetOrdering");

                var OrderService = await _IOrderServiceRepository.GetOrderServiceById(OrderServiceId);

                if (OrderService != null)
                {


                    var OrderServiceDt = new GetOrderServiceDetailDTO()
                    {
                        OrderServiceId = OrderService.OrderServiceId,
                        ServiceId = OrderService.ServiceId,
                        OrderId = OrderService.OrderId,
                        ModifiedDate = OrderService.ModifiedDate,
                        CreationDate = OrderService.CreationDate,
                        IsِActive = OrderService.IsِActive,

                    };

                    Log.Information("OrderService Is Reached");
                    Log.Debug($"Debugging Get OrderService By Id Has been Finised Successfully With Order ID  = {OrderService.OrderServiceId}");
                    return OrderServiceDt;

                }
                else
                {
                    Log.Error($"OrderService Not Found");
                    throw new ArgumentNullException("OrderService", "Not Found OrderService");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"OrderService Not Found: {ex.Message}");
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

        public async Task<string> CreateOrderService(CreateOrderServiceDTO Inpute)
        {
            try
            {


                var Order = await _IOrderRepository.GetOrderById((int)Inpute.OrderId);
                var Service= await _IServiceRepository.GetServiceById((int)Inpute.ServiceId);

                Log.Information("OrderService Is In Createing");


                if (Order != null && Service != null)
                {

                   

                  
                        
                        var OrderServices = new OrderService
                        {

                            OrderId = Order.OrderId,
                            ServiceId = Inpute.ServiceId,
                            CreationDate = Inpute.CreationDate,
                            ModifiedDate = null,
                            IsِActive = Inpute.IsِActive,
                            Quantity = Inpute.Quantity,
                           




                        };
                       
                        if (OrderServices != null)
                        {

                         await _IOrderServiceRepository.CreateOrderService(OrderServices);
                   



                        Order.priceFinal2 = Inpute.Quantity * Service.PriceAfterDiscount;

                            await _IOrderRepository.UpdateOrder(Order);

                        //Payment 
                        var paymentMethods = await _IOrderRepository.IsValidPayment(Inpute.Code, Inpute.CardNumber, Inpute.CardHolder, (decimal)Order.priceFinal2);
                            if (paymentMethods != null)
                            {
                            paymentMethods.Balance -= Order.priceFinal2;
                                await _IOrderRepository.UpdatePaymentMethod(paymentMethods);


                                Log.Information("OrderService Is Created");
                                Log.Debug($"Debugging Get OrderService By Id Has been Finised Successfully With Order ID  = {OrderServices.OrderServiceId}");

                                return "AddOrderService Has been Finised Successfully ";
                            }
                            else {

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

                    throw new Exception("Service  && Order Not Found");
                }

              

            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"OrderService Not Found: {ex.Message}");
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


        public async Task<string> UpdateOrderService(UpdateOrderServiceDTO Inpute)
        {
            try
            {

                Log.Information("OrderService Is In Updateing");

                var OrderService = await _IOrderServiceRepository.GetOrderServiceById(Inpute.OrderServiceId);
                var Order = await _IOrderRepository.GetOrderById((int)Inpute.OrderId);
                var Service = await _IServiceRepository.GetServiceById((int)Inpute.ServiceId);

                if (OrderService != null && Order !=null && Service !=null)
                {

                    if (Inpute.IsِActive !=null) {


                        OrderService.IsِActive = Inpute.IsِActive;

                    }
                   
                        OrderService.OrderId = Order.OrderId;
                        OrderService.ServiceId = Service.ServiceId;
                    OrderService.ModifiedDate = Inpute.ModifiedDate;
                   



                    await _IOrderServiceRepository.UpdateOrderService(OrderService);

                    Log.Information("OrderService Is Updated");
                    Log.Debug($"Debugging Get OrderService By Id Has been Finised Successfully With Order ID  = {OrderService.OrderServiceId}");


                    return "UpdateOrderService success";

                }
                else
                {
                    Log.Error($"OrderService Not Found");
                    throw new ArgumentNullException("OrderService", "Not Found OrderService");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"OrderService Not Found: {ex.Message}");
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


        public async Task<string> DeleteOrderService(int OrderServiceId)
        {
            try
            {

                Log.Information("Order Is In Deleteing");

                var OrderService = await _IOrderServiceRepository.GetOrderServiceById(OrderServiceId);
                if (OrderService != null)
                {

                    await _IOrderServiceRepository.DeleteOrderService(OrderService);

                    Log.Information("OrderService Is Deleted");
                    Log.Debug($"Debugging Get OrderService By Id Has been Finised Successfully With Order ID  = {OrderService.OrderServiceId}");

                    return "DeleteOrderService success";

                }
                else
                {
                    Log.Error($"OrderService Not Found");
                    throw new ArgumentNullException("OrderService", "Not Found OrderService");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"OrderService Not Found: {ex.Message}");
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


        public async Task UpdateOrderServiceActivation(int Id, bool value)
        {
            var OrderService = await _IOrderServiceRepository.GetOrderServiceById(Id);
            if (OrderService != null)
            {
                OrderService.IsِActive = value;
                await _IOrderServiceRepository.UpdateOrderService(OrderService);
            }
            else
            {
                throw new Exception("ProbOrderServicelem Dose not Exisit");
            }
        }


    }
}
