

using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IServiceService
    {

        Task<GetServiceDetailDTO> GetServiceById(int ServiceId);

        Task<List<GetServiceAllDTO>> GetServiceAll();

        Task<string> CreateService(CreateServiceDTO Inpute);

        Task<string> UpdateService(UpdateServiceDTO Inpute);
        Task<string> DeleteService(int ServiceId);


        Task UpdateServiceApprovment(int Id, bool value);

        Task UpdateServiceActivation(int Id, bool value);


    }
}
