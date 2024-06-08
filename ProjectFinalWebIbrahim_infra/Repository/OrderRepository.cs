



using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_infra.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ProjectWebFinalDbContext _context;


        public OrderRepository(ProjectWebFinalDbContext context) { 
        
            _context = context;
        
        }


        public async Task CreateOrder(Order Inpute)
        {
            _context.Order.Add(Inpute);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(Order Inpute)
        {
            _context.Order.Remove(Inpute);
            await _context.SaveChangesAsync();
        }

        public async  Task<List<GetOrderAllDTO>> GetOrderAll()
        {
            try
            {

                var Ordera = from p in _context.Order
                            join x in _context.User
                               on p.UsersId equals x.UserId
                               orderby p.DateOrder descending
                               select new GetOrderAllDTO
                               {

                                   OrderId=p.OrderId,
                                   UsersId=p.UsersId,
                                   Rate=p.Rate,
                                   Status=p.Status,
                                   Title=p.Title,
                                   DateOrder=p.DateOrder,
                                 IsِActive=p.IsِActive,

                               };


                var Orders = await Ordera.ToListAsync();

                if (Orders != null)
                {

                    return Orders;
                }
                else
                {

                    throw new ArgumentNullException("Order", "Not Found Order");

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

        public async Task<Order> GetOrderById(int OrderId)
        {
            var Order = await _context.Order.FindAsync(OrderId);

            return Order;
        }


        public async Task<GetOrderDetailDTO> GetOrderByIdServ(int OrderId)
        {
            try
            {

                var Orders = from p in _context.Order
                             where p.OrderId == OrderId
                             join x in _context.User
                               on p.UsersId equals x.UserId
                               //QA
                               join G in _context.OrderService
                            on p.OrderId equals G.OrderId
                               orderby p.CreationDate descending
                               select new GetOrderDetailDTO
                               {

                                   ModifiedDate = p.ModifiedDate,
                                   CreationDate = p.CreationDate,
                                   DateOrder = p.DateOrder,
                                   OrderId = p.OrderId,
                                   UsersId = p.UsersId,
                                   Title = p.Title,
                                   Status = p.Status,
                                   ClientName=x.FirstName,
                                   Rate = p.Rate,
                                   PaymentMethod = p.PaymentMethod,
                                   Note = p.Note,
                                   IsِActive = p.IsِActive,

                               };

                var qu = await Orders.LastOrDefaultAsync();
                if (qu != null)
                {

                    return qu;
                }
                else
                {

                    throw new ArgumentNullException("Orders", "Not Found Orders");

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



        public async Task UpdateOrder(Order Inpute)
        {
            _context.Order.Update(Inpute);
            await _context.SaveChangesAsync();
        }
    }
}
