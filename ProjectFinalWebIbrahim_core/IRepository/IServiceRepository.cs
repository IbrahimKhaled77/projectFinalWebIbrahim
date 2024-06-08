using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IRepository
{
    //t
    public interface IServiceRepository
    {

        Task CreateService(Service Inpute);

        Task DeleteService(Service Inpute);

        Task UpdateService(Service Inpute);


        Task<Service> GetServiceById(int ServiceId);

        Task<List<GetServiceAllDTO>> GetServiceAll();

         Task<GetServiceDetailDTO> GetServiceByIdSrev(int ServiceId);



    }
}
