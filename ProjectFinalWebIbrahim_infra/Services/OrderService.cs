
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
        private readonly IOrderServiceRepository _IOrderServiceRepository;
        public OrderServices(IOrderRepository IOrderRepository , IUserRepository IUserRepository, IOrderServiceRepository iOrderServiceRepository)
        {

            _IOrderRepository = IOrderRepository;
            _IUserRepository = IUserRepository;
            _IOrderServiceRepository = iOrderServiceRepository;
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
                

                var user = await _IUserRepository.GetUserById((int)Inpute.UsersId);

              


                Log.Information("Order Is strating CreateOrder");

                if (user != null) {




                    var Order = new Order
                    {


                        ModifiedDate = null,
                        Title = Inpute.Title,
                        Note = Inpute.Note,
                        DateOrder = Inpute.DateOrder,
                        Status = Inpute.Status,
                        Rate = 0,
                        UsersId = user.UserId,
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



        //Provider
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
                    Order.ModifiedDate = Inpute.ModifiedDate;

                   


                 
                 
                    



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
                Order.IsِActive = value;
                await _IOrderRepository.UpdateOrder(Order);
            }
            else
            {
                throw new Exception("Order Dose not Exisit");
            }
        }



    }
}
