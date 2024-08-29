
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IOrderService
    {

        Task<GetOrderDetailDTO> GetOrderById(int OrderId);

        Task<List<GetOrderAllDTO>> GetOrderAll(bool? IsApproved);
        Task<List<GetOrderAllDTO>> GetOrderAlUser(int userId);


        Task<int> CreateOrder(CreateOrderDTO Inpute,int serviceId);

        Task<string> UpdateOrder(UpdateOrderDTO Inpute);
        Task<string> DeleteOrder(int OrderId);


        Task UpdateOrderApprovment(int Id, bool value);


        Task UpdateOrderActivation(int Id, bool value);

        Task<string> Rating(RatingDTO Inpute);

    }
}
