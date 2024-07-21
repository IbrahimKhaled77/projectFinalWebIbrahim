using ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;


namespace ProjectFinalWebIbrahim_core.IRepository
{
    public interface IOrderServiceRepository
    {

        Task<OrderService> GetOrderServiceById(int OrderServiceId);

        Task<List<GetOrderServiceAllDTO>> GetOrderServiceAll();
        Task CreateOrderService(OrderService Inpute);

        Task UpdateOrderService(OrderService Inpute);
        Task DeleteOrderService(OrderService Inpute);

        



    }
}
