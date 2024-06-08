using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;


namespace ProjectFinalWebIbrahim_core.IRepository
{
    //t
    public interface IOrderRepository
    {
        Task CreateOrder(Order Inpute);

        Task DeleteOrder(Order Inpute);

        Task UpdateOrder(Order Inpute);


        Task<Order> GetOrderById(int OrderId);

        Task<List<GetOrderAllDTO>> GetOrderAll();

        Task<GetOrderDetailDTO> GetOrderByIdServ(int OrderId);
    }
}
