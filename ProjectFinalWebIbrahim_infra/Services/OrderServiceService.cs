





using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using ProjectFinalWebIbrahim_infra.Repository;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class OrderServiceService : IOrderServiceService
    {

        private readonly IOrderServiceRepository _IOrderServiceRepository;

        public OrderServiceService(IOrderServiceRepository IOrderServiceRepository) {

            _IOrderServiceRepository = IOrderServiceRepository;
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
                Log.Information("Order Is In Createing");

                var OrderServices = new OrderService
                {

                    OrderId= Inpute.OrderId,
                    ServiceId= Inpute.ServiceId,
                    CreationDate= Inpute.CreationDate,
                    IsِActive = Inpute.IsِActive
                   
                   



                };

                if (OrderServices != null)
                {

                    await _IOrderServiceRepository.CreateOrderService(OrderServices);

                    Log.Information("OrderService Is Created");
                    Log.Debug($"Debugging Get OrderService By Id Has been Finised Successfully With Order ID  = {OrderServices.OrderServiceId}");

                    return "AddOrderService Has been Finised Successfully ";
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


        public async Task<string> UpdateOrderService(UpdateOrderServiceDTO Inpute)
        {
            try
            {

                Log.Information("Order Is In Updateing");

                var OrderService = await _IOrderServiceRepository.GetOrderServiceById(Inpute.OrderServiceId);

                if (OrderService != null)
                {
                    OrderService.ServiceId = Inpute.OrderServiceId;
                    OrderService.OrderId = Inpute.OrderId;
                    OrderService.ModifiedDate = Inpute.ModifiedDate;
                    OrderService.IsِActive = Inpute.IsِActive;




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

   

    

    }
}
