

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.Dtos.OrderServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Repository
{
     public class OrderServiceRepository :IOrderServiceRepository
   
    {
        private readonly ProjectWebFinalDbContext _context;
           public OrderServiceRepository(ProjectWebFinalDbContext context) {
        
            _context = context;


                }


        public async Task<List<GetOrderServiceAllDTO>> GetOrderServiceAll()
        {
            try
            {

                var OrderService = from p in _context.OrderService
                                   join x in _context.Order
                               on p.OrderId equals x.OrderId
                                   join v in _context.Services
                                   on p.ServiceId equals v.ServiceId
                                   select new GetOrderServiceAllDTO
                                   {

                                       OrderId = p.OrderId,
                                       CreationDate = p.CreationDate,
                                       IsِActive = p.IsِActive,
                                       ModifiedDate = p.ModifiedDate,
                                       OrderServiceId = p.OrderServiceId,
                                       ServiceId = p.ServiceId,


                                   };


                var OrderServices = await OrderService.ToListAsync();

                if (OrderServices != null)
                {

                    Log.Information("OrderService Is GetOrderServiceAll");
                    Log.Debug($"Debugging Get OrderService By Id Has been Finised Successfully");

                    return OrderServices;
                }
                else
                {
                    Log.Error($"OrderService Not Found");
                    throw new ArgumentNullException("OrderService", "Not Found OrderService");

                }
            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"OrderService Not Found: {ex.Message}");
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

        public async Task<OrderService> GetOrderServiceById(int OrderServiceId)
        {
            var OrderService = await _context.OrderService.FindAsync(OrderServiceId);

            return OrderService;
        }
        public async Task CreateOrderService(OrderService Inpute)
        {
            _context.OrderService.Add(Inpute);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderService(OrderService Inpute)
        {
            _context.OrderService.Update(Inpute);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteOrderService(OrderService Inpute)
        {
            _context.OrderService.Remove(Inpute);
            await _context.SaveChangesAsync();
        }


    
    }
}
