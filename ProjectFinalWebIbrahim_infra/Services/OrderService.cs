
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using ProjectFinalWebIbrahim_infra.Repository;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class OrderServices:IOrderService
    {

        private readonly IOrderRepository _IOrderRepository;

        public OrderServices(IOrderRepository IOrderRepository ) {

            _IOrderRepository= IOrderRepository;


        }


        //provider and Client
        public async Task<List<GetOrderAllDTO>> GetOrderAll()
        {
            return await _IOrderRepository.GetOrderAll();
        }

        //Admin and provider and Client 
        public async Task<GetOrderDetailDTO> GetOrderById(int OrderId)
        {
            return await _IOrderRepository.GetOrderByIdServ(OrderId);
        }

        //client
        public async Task<string> CreateOrder(CreateOrderDTO Inpute)
        {
            try
            {
                Log.Information("Order Is strating CreateOrder");
                var Order = new Order
                {


                    ModifiedDate = null,
                     Title = Inpute.Title,
                     Note = Inpute.Note,
                     DateOrder = Inpute.DateOrder,
                     Status = Inpute.Status,
                     Rate = Inpute.Rate,
                     UsersId = Inpute.UsersId,
                     PaymentMethod = Inpute.PaymentMethod,
                     IsِActive = Inpute.IsِActive,
                     CreationDate = DateTime.UtcNow,
            };

                if (Order != null)
                {

                    await _IOrderRepository.CreateOrder(Order);

                    Log.Information("Order Is Created");
                    Log.Debug($"Debugging Get Order By Id Has been Finised Successfully With Order ID  = {Order.OrderId}");

                    return "AddOrder Has been Finised Successfully ";
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



        //Provider
        public async Task<string> UpdateOrder(UpdateOrderDTO Inpute)
        {
            try
            {

                Log.Information("Order Is strating UpdateOrder");

                var Order = await _IOrderRepository.GetOrderById(Inpute.OrderId);

                if (Order != null)
                {
                    Order.ModifiedDate = Inpute.ModifiedDate;
                    Order.Rate = Inpute.Rate;
                    Order.Status = Inpute.Status;
                    Order.IsِActive = Inpute.IsِActive;
                    Order.UsersId = Inpute.UsersId;



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


        //provider and Admin
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




    
    }
}
