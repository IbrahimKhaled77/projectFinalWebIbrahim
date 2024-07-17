
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IOrderService
    {

        Task<GetOrderDetailDTO> GetOrderById(int OrderId);

        Task<List<GetOrderAllDTO>> GetOrderAll();

        Task<string> CreateOrder(CreateOrderDTO Inpute);

        Task<string> UpdateOrder(UpdateOrderDTO Inpute);
        Task<string> DeleteOrder(int OrderId);


        Task UpdateOrderApprovment(int Id, bool value);


        Task UpdateOrderActivation(int Id, bool value);

    }
}
