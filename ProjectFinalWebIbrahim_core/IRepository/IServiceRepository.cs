using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IRepository
{ 
    public interface IServiceRepository
    {


        Task<List<GetServiceAllDTO>> GetServiceCustomerAll(int CategorId);
        Task<List<GetServiceAllDTO>> GetServiceAll();

        Task<GetServiceDetailDTO> GetServiceByIdSrev(int ServiceId);

        Task<Service> GetServiceById(int ServiceId);
        Task<int> CreateService(Service Inpute);

        Task UpdateService(Service Inpute);
        Task DeleteService(Service Inpute);




    



    }
}
