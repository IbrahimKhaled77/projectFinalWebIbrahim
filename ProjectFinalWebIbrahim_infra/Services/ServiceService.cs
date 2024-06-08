

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using ProjectFinalWebIbrahim_infra.Repository;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class ServiceService : IServiceService
    {

        private readonly IServiceRepository  _IServiceRepository ;

        public ServiceService(IServiceRepository IServiceRepository ) {

            _IServiceRepository= IServiceRepository;


        }


        //proverd
        //price and afterprice and quantityunit
        public async Task<string> CreateService(CreateServiceDTO Inpute)
        {
            try
            {

                var Service = new Service
                {

                    CategoryId = Inpute.CategoryId,
                    UserId = Inpute.UserId,
                    Name = Inpute.Name,
                    Description = Inpute.Description,
                    DiscountType = Inpute.DiscountType,
                    Price = Inpute.Price,
                    IsHaveDiscount = Inpute.IsHaveDiscount,
                    DiscountPrice = Inpute.DiscountPrice,
                    Image= Inpute.Image,
                    QuantityUnit=Inpute.QuantityUnit,
                    //price-disprice
                    PriceAfterDiscount=Inpute.PriceAfterDiscount,
                    ModifiedDate=null,
                    CreationDate = DateTime.UtcNow,
                    IsِActive = Inpute.IsِActive,

                };

                if (Service != null)
                {

                    await _IServiceRepository.CreateService(Service);

                    return "AddService Has been Finised Successfully ";
                }
                else
                {

                    throw new ArgumentNullException("Service", "Not Found Service");

                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }

        //admin // provider
        public async Task<string> DeleteService(int ServiceId)
        {
            try
            {

                var Service = await _IServiceRepository.GetServiceById(ServiceId);

                if (Service != null)
                {

                    await _IServiceRepository.DeleteService(Service);

                    return "DeleteService success";

                }
                else
                {

                    throw new ArgumentNullException("Service", "Not Found Service");

                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }


        //admin and client 
        public async Task<List<GetServiceAllDTO>> GetServiceAll()
        {
            return await _IServiceRepository.GetServiceAll();
        }


        //all user 
        public async Task<GetServiceDetailDTO> GetServiceById(int ServiceId)
        {
            return await _IServiceRepository.GetServiceByIdSrev(ServiceId);
        }


        //provider
        public async  Task<string> UpdateService(UpdateServiceDTO Inpute)
        {
            try
            {



                var Service = await _IServiceRepository.GetServiceById(Inpute.ServiceId);

                if (Service != null)
                {
                    Service.Name = Inpute.Name;
                    Service.Description = Inpute.Description;
                    Service.Image = Inpute.Image;
                    Service.Price = Inpute.Price;
                    Service.PriceAfterDiscount = Inpute.PriceAfterDiscount;
                    Service.QuantityUnit = Inpute.QuantityUnit;
                    Service.IsHaveDiscount = Inpute.IsHaveDiscount;
                    Service.DiscountPrice = Inpute.DiscountPrice;
                    Service.DiscountType = Inpute.DiscountType;
                    Service.ModifiedDate = Inpute.ModifiedDate;
                    Service.IsِActive = Inpute.IsِActive;
                    Service.CategoryId = Inpute.CategoryId;
                    Service.UserId = Inpute.UserId;


                    await _IServiceRepository.UpdateService(Service);

                    return "UpdateService success";

                }
                else
                {

                    throw new ArgumentNullException("Service", "Not Found Service");

                }



            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }


    }


}
