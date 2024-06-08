
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IOrderService
    {
        Task<string> CreateOrder(CreateOrderDTO Inpute);

        Task<string> DeleteOrder(int OrderId);

        Task<string> UpdateOrder(UpdateOrderDTO Inpute);


        Task<GetOrderDetailDTO> GetOrderById(int OrderId);

        Task<List<GetOrderAllDTO>> GetOrderAll();


    }
}
