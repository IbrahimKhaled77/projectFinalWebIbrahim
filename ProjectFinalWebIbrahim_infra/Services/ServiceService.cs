

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;


namespace ProjectFinalWebIbrahim_infra.Services
{
    public class ServiceService : IServiceService
    {

        private readonly IServiceRepository  _IServiceRepository ;
        private readonly IUserRepository _IUserRepository;
        private readonly ICategoryRepository _ICategoryRepository;
        public ServiceService(IServiceRepository IServiceRepository , IUserRepository IUserRepository, ICategoryRepository ICategoryRepository) {

            _IServiceRepository= IServiceRepository;
            _IUserRepository = IUserRepository;
            _ICategoryRepository = ICategoryRepository;


        }

     
        public async Task<List<GetServiceAllDTO>> GetServiceAll()
        {
            return await _IServiceRepository.GetServiceAll();
        }


        public async Task<List<GetServiceAllDTO>> GetServiceCustomerAll(int CategorId)
        {
            return await _IServiceRepository.GetServiceCustomerAll(CategorId);
        }



        public async Task<GetServiceDetailDTO> GetServiceById(int ServiceId)
        {
            return await _IServiceRepository.GetServiceByIdSrev(ServiceId);
        }

        
        public async Task<string> CreateService(CreateServiceDTO Inpute)
        {
            try
            {

                var user = await _IUserRepository.GetUserById((int)Inpute.UserId);
                var Category = await _ICategoryRepository.GetCategoryById(Inpute.CategoryId);

                Log.Information("Service Is starting Create");

                if (user != null && Category !=null) {
                    var Service = new Service();




                    Service.CategoryId = Category.CategoryId;
                       Service.UserId = user.UserId;
                       Service.Name = Inpute.Name;
                       Service.Description = Inpute.Description;
                       Service.DiscountType = Inpute.DiscountType;
                    Service.Price = Inpute.Price;
                       Service.IsHaveDiscount = Inpute.IsHaveDiscount;
                       Service.DiscountPrice = 0;
                      Service.imagetitleservice = Inpute.imagetitleservice;
                      Service.QuantityUnit = Inpute.QuantityUnit;
                    Service.TitleArabic = Inpute.TitleArabic;
                    Service.DescriptionArabic = Inpute.DescriptionArabic;
                    Service.PriceAfterDiscount = 0;
                      Service.ModifiedDate = null;
                      Service.CreationDate = DateTime.Now;
                     Service.IsActive = true;

                    

                    int serviceId = await _IServiceRepository.CreateService(Service);

                    var a = await _IServiceRepository.GetServiceById(serviceId);


                    if (string.IsNullOrEmpty(a.imagetitleservice))
                    {
                        Service.imagetitleservice = "https://www.shutterstock.com/image-vector/concept-blogging-golden-blog-word-260nw-755744683.jpg";
                    }
                    else
                    {
                        Service.imagetitleservice = $"https://localhost:44305/Images/Service/{Inpute.imagetitleservice}";

                    }


                    if (Service != null)
                    {

                  //  var ServiceId=    await _IServiceRepository.CreateService(Service);

                    // var service  = await _IServiceRepository.GetServiceById(ServiceId);

                        if (Inpute.IsHaveDiscount == true)
                        {


                            a.DiscountPrice = Inpute.DiscountPrice;

                            a.PriceAfterDiscount = a.Price - (decimal) Inpute.DiscountPrice;

                        }
                        else {

                            a.PriceAfterDiscount = a.Price;
                        }

                        await _IServiceRepository.UpdateService(a);

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
                else
                {
                    throw new Exception("User Dose not Exisit Or Category Dose not Exisit ");
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



      
        public async Task<string> UpdateService(UpdateServiceDTO Inpute)
        {
            try
            {

                Log.Information("Service Is starting Updated");

                var Service = await _IServiceRepository.GetServiceById(Inpute.ServiceId);

                if (Service != null)
                {

                    if (!string.IsNullOrEmpty(Inpute.Name)) {
                        Service.Name = Inpute.Name;
                    }
                    if (!string.IsNullOrEmpty(Inpute.Description))
                    {
                        Service.Description = Inpute.Description;
                    }
                    if (!string.IsNullOrEmpty(Inpute.imagetitleservice))
                    {
                        Service.imagetitleservice = Inpute.imagetitleservice;
                    }
                    if (Inpute.Price != null)
                    {
                        Service.Price = (decimal) Inpute.Price;
                    }
                    if (Inpute.PriceAfterDiscount != null)
                    {
                        Service.PriceAfterDiscount = (decimal)Inpute.PriceAfterDiscount;
                    }
                    if (Inpute.QuantityUnit != null)
                    {
                        Service.QuantityUnit =  (QuantityUnitType) Inpute.QuantityUnit;
                    }
                    if (Inpute.IsHaveDiscount != null)
                    {

                        Service.IsHaveDiscount = (bool)Inpute.IsHaveDiscount;
                    }

                    if (Inpute.DiscountPrice != null)
                    {
                        Service.DiscountPrice = Inpute.DiscountPrice;
                    }
                    if (!string.IsNullOrEmpty(Inpute.DiscountType))
                    {
                        Service.DiscountType = Inpute.DiscountType;
                    }
                    if (!string.IsNullOrEmpty(Inpute.DescriptionArabic))
                    {
                        Service.DescriptionArabic = Inpute.DescriptionArabic;
                    }



                    if (!string.IsNullOrEmpty(Inpute.TitleArabic))
                    {
                        Service.TitleArabic = Inpute.TitleArabic;
                    }
                    Service.IsActive = true;
                   
                    Service.ModifiedDate = DateTime.Now;
                   


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


        public async Task UpdateServiceApprovment(int Id, bool value)
        {
            var Service = await _IServiceRepository.GetServiceById(Id);
            if (Service != null)
            {
                Service.IsApproved = value;
                await _IServiceRepository.UpdateService(Service);
            }
            else
            {
                throw new Exception("Service Dose not Exisit");
            }
        }



        public async Task UpdateServiceActivation(int Id, bool value)
        {
            var Service = await _IServiceRepository.GetServiceById(Id);
            if (Service != null)
            {
                Service.IsActive = value;
                await _IServiceRepository.UpdateService(Service);
            }
            else
            {
                throw new Exception("Service Dose not Exisit");
            }
        }

    }


}
