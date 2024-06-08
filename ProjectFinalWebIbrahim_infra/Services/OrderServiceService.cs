





using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using ProjectFinalWebIbrahim_infra.Repository;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class OrderServiceService : IOrderServiceService
    {

        private readonly IOrderServiceRepository _IOrderServiceRepository;

        public OrderServiceService(IOrderServiceRepository IOrderServiceRepository) {

            _IOrderServiceRepository = IOrderServiceRepository;
        }

        public async Task<string> CreateOrderService(CreateOrderServiceDTO Inpute)
        {
            try
            {

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

                    return "AddOrderService Has been Finised Successfully ";
                }
                else
                {

                    throw new ArgumentNullException("OrderService", "Not Found OrderService");

                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }

        public async Task<string> DeleteOrderService(int OrderServiceId)
        {
            try
            {
                var OrderService = await _IOrderServiceRepository.GetOrderServiceById(OrderServiceId);
                if (OrderService != null)
                {

                    await _IOrderServiceRepository.DeleteOrderService(OrderService);

                    return "DeleteOrderService success";

                }
                else
                {

                    throw new ArgumentNullException("OrderService", "Not Found OrderService");

                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }

        public async Task<List<GetOrderServiceAllDTO>> GetOrderServiceAll()
        {
            return await _IOrderServiceRepository.GetOrderServiceAll();
        }

        public async Task<GetOrderServiceDetailDTO> GetOrderServiceById(int OrderServiceId)
        {
            try
            {

                var OrderService = await _IOrderServiceRepository.GetOrderServiceById(OrderServiceId);

                if (OrderService != null)
                {


                    var OrderServiceDt = new GetOrderServiceDetailDTO()
                    {
                        OrderServiceId=OrderService.OrderServiceId,
                        ServiceId=OrderService.ServiceId,
                        OrderId=OrderService.OrderId,
                        ModifiedDate = OrderService.ModifiedDate,
                        CreationDate = OrderService.CreationDate,
                   IsِActive = OrderService.IsِActive,

                    };

                    return OrderServiceDt;

                }
                else
                {

                    throw new ArgumentNullException("OrderService", "Not Found OrderService");

                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }

        public async Task<string> UpdateOrderService(UpdateOrderServiceDTO Inpute)
        {
            try
            {



                var OrderService = await _IOrderServiceRepository.GetOrderServiceById(Inpute.OrderServiceId);

                if (OrderService != null)
                {
                    OrderService.ServiceId = Inpute.OrderServiceId;
                    OrderService.OrderId= Inpute.OrderId;
                    OrderService.ModifiedDate = Inpute.ModifiedDate;
                    OrderService.IsِActive = Inpute.IsِActive;




                     await _IOrderServiceRepository.UpdateOrderService(OrderService);

                    return "UpdateOrderService success";

                }
                else
                {

                    throw new ArgumentNullException("OrderService", "Not Found OrderService");

                }



            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }


    }
}
