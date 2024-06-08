

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_infra.Repository
{
    public class ServiceRepository : IServiceRepository
    {

        private readonly ProjectWebFinalDbContext _context;
        public ServiceRepository(ProjectWebFinalDbContext context)
        {

            _context = context;


        }


        public async Task CreateService(Service Inpute)
        {
            _context.Services.Add(Inpute);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteService(Service Inpute)
        {
            _context.Services.Remove(Inpute);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetServiceAllDTO>> GetServiceAll()
        {
            try
            {

                var Service = from p in _context.Services
                              join x in _context.User
                              on p.UserId equals x.UserId
                              join G in _context.Categorie
                               on p.CategoryId equals G.CategoryId
                              orderby p.CreationDate descending

                              select new GetServiceAllDTO
                              {

                                  ServiceId = p.ServiceId,
                                  UserId = p.UserId,
                                  //QA
                                  CategoryId = p.CategoryId,

                                  //name provider
                                  NameUser = x.FirstName,
                                  Image = p.Image,
                                  Name = p.Name,
                                  Price = p.Price,

                                  PriceAfterDiscount = p.PriceAfterDiscount,
                                  IsِActive = p.IsِActive,




                              };


                var Services = await Service.ToListAsync();

                if (Services != null)
                {

                    return Services;
                }
                else
                {

                    throw new ArgumentNullException("Services", "Not Found Services");

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

        public async Task<Service> GetServiceById(int ServiceId)
        {
            var Service = await _context.Services.FindAsync(ServiceId);

            return Service;
        }

        public async Task<GetServiceDetailDTO> GetServiceByIdSrev(int ServiceId)
        {
            try
            {

                var Services = from p in _context.Services
                               where p.ServiceId == ServiceId
                               join x in _context.User
                               on p.UserId equals x.UserId
                               join G in _context.Categorie
                            on p.CategoryId equals G.CategoryId
                               orderby p.CreationDate descending
                               select new GetServiceDetailDTO
                               {
                                   ServiceId = p.ServiceId,
                                   Name = p.Name,
                                   Description = p.Description,
                                   Image = p.Image,
                                   Price = p.Price,
                                   PriceAfterDiscount = p.PriceAfterDiscount,
                                   QuantityUnit = p.QuantityUnit,
                                   IsHaveDiscount = p.IsHaveDiscount,
                                   DiscountPrice = p.DiscountPrice,
                                   DiscountType = p.DiscountType,
                                   CreationDate = p.CreationDate,
                                   ModifiedDate = p.ModifiedDate,
                                   IsِActive = p.IsِActive,
                                   CategoryId = p.CategoryId,
                                   UserId = p.UserId,
                                   UserName = x.FirstName,


                               };

                var qu = await Services.LastOrDefaultAsync();
                if (qu != null)
                {

                    return qu;
                }
                else
                {

                    throw new ArgumentNullException("Services", "Not Found Services");

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


    



                          
        public async Task UpdateService(Service Inpute)
        {
            _context.Services.Update(Inpute);
            await _context.SaveChangesAsync();
        }
    }
}
