

using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IServiceService
    {

        Task<string> CreateService(CreateServiceDTO Inpute);

        Task<string> DeleteService(int ServiceId);

        Task<string> UpdateService(UpdateServiceDTO Inpute);


        Task<GetServiceDetailDTO> GetServiceById(int ServiceId);

        Task<List<GetServiceAllDTO>> GetServiceAll();

    }
}
