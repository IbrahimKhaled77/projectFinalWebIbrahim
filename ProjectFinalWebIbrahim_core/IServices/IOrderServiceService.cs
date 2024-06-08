

using ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IOrderServiceService
    {
  
        Task<string> CreateOrderService(CreateOrderServiceDTO Inpute);

        Task<string> DeleteOrderService(int OrderServiceId);
        
        Task<string> UpdateOrderService(UpdateOrderServiceDTO Inpute);


        Task<GetOrderServiceDetailDTO> GetOrderServiceById(int OrderServiceId);

        Task<List<GetOrderServiceAllDTO>> GetOrderServiceAll();

       
    }
}
