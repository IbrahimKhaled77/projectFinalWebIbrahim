

using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using ProjectFinalWebIbrahim_infra.Repository;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class ServiceService : IServiceService
    {

        private readonly IServiceRepository  _IServiceRepository ;

        public ServiceService(IServiceRepository IServiceRepository ) {

            _IServiceRepository= IServiceRepository;


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

        //proverd
        //price and afterprice and quantityunit
        public async Task<string> CreateService(CreateServiceDTO Inpute)
        {
            try
            {
                Log.Information("Service Is starting Create");

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

                    Log.Information("Service Is Created");
                    Log.Debug($"Debugging CreateService Has been Finised Successfully With Service ID  = {Service.ServiceId}");

                    return "AddService Has been Finised Successfully ";
                }
                else
                {
                    Log.Error($"Service Not Found");
                    throw new ArgumentNullException("Service", "Not Found Service");

                }


            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Service Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }

        }



        //provider
        public async Task<string> UpdateService(UpdateServiceDTO Inpute)
        {
            try
            {

                Log.Information("Service Is starting Updated");

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
                    Log.Information("Service Is Updated");
                    Log.Debug($"Debugging UpdateService Has been Finised Successfully With Order ID  = {Service.ServiceId}");

                    return "UpdateService success";

                }
                else
                {
                    Log.Error($"Service Not Found");
                    throw new ArgumentNullException("Service", "Not Found Service");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Service Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }
        }

        //admin // provider
        public async Task<string> DeleteService(int ServiceId)
        {
            try
            {
                Log.Information("Service Is starting Delete");
                var Service = await _IServiceRepository.GetServiceById(ServiceId);

                if (Service != null)
                {

                    await _IServiceRepository.DeleteService(Service);

                    Log.Information("Service Is Deleted");
                    Log.Debug($"Debugging DeleteService Has been Finised Successfully With Service ID  = {Service.ServiceId}");

                    return "DeleteService success";

                }
                else
                {
                    Log.Error($"Service Not Found ");
                    throw new ArgumentNullException("Service", "Not Found Service");

                }


            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Service Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }
        }


 


 


    }


}
