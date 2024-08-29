



using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_infra.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ProjectWebFinalDbContext _context;


        public OrderRepository(ProjectWebFinalDbContext context) { 
        
            _context = context;
        
        }


        public async Task<List<GetOrderAllDTO>> GetOrderAllUser(int userId)
        {
               try
                {
                    Log.Information("Order Is starting GetOrderAll");

                    var Ordera = from p in _context.Order
                                 join x in _context.User
                                    on p.UsersId equals x.UserId
                                    where p.UsersId == userId
                                    join s in _context.Services
                                    on p.ServiceId equals s.ServiceId
                                 where p.IsActive == true
                                 orderby p.DateOrder descending
                                 select new GetOrderAllDTO
                                 {

                                     OrderId = p.OrderId,
                                     UsersId = p.UsersId,
                                     Rate = (int)p.Rate,
                                     Status = p.Status,
                                     Title = p.Title,
                                     DateOrder = p.DateOrder,
                                     isactive = p.IsActive,
                                     priceFinal2 = (decimal)p.priceFinal2,
                                     IsApproved = p.IsApproved,
                                     Quantity=p.Quantity,
                                     ImageService=s.imagetitleservice,

                                 };


                    var Orders = await Ordera.ToListAsync();

                    if (Orders != null)
                    {
                        Log.Information("Order Is GetOrderAll");
                        Log.Debug($"Debugging Get Order By Id Has been Finised Successfully ");
                        return Orders;
                    }
                    else
                    {
                        Log.Error($"Order Not Found");
                        throw new ArgumentNullException("Order", "Not Found Order");

                    }



                }
                catch (ArgumentNullException ex)
                {
                    Log.Error($"Order Not Found: {ex.Message}");
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



        public async Task<List<GetOrderAllDTO>> GetOrderAll(bool? IsApproved)
        {
            if (IsApproved == false)
            {
                try
                {
                    Log.Information("Order Is starting GetOrderAll");

                    var Ordera = from p in _context.Order
                                 join x in _context.User
                                    on p.UsersId equals x.UserId
                                 where p.Status == OrderStatus.Cancelled
                                 && p.IsActive == true
                                 orderby p.DateOrder descending
                                 select new GetOrderAllDTO
                                 {

                                     OrderId = p.OrderId,
                                     UsersId = p.UsersId,
                                     Rate = (int)p.Rate,
                                     Status = p.Status,
                                     Title = p.Title,
                                     DateOrder = p.DateOrder,
                                     isactive = p.IsActive,
                                     priceFinal2 = (decimal)p.priceFinal2,
                                     IsApproved=p.IsApproved,

                                 };


                    var Orders = await Ordera.ToListAsync();

                    if (Orders != null)
                    {
                        Log.Information("Order Is GetOrderAll");
                        Log.Debug($"Debugging Get Order By Id Has been Finised Successfully ");
                        return Orders;
                    }
                    else
                    {
                        Log.Error($"Order Not Found");
                        throw new ArgumentNullException("Order", "Not Found Order");

                    }



                }
                catch (ArgumentNullException ex)
                {
                    Log.Error($"Order Not Found: {ex.Message}");
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
            else if (IsApproved == true)
            {
                try
                {
                
                    Log.Information("Order Is starting GetOrderAll");

                    var Ordera = from p in _context.Order
                                 join x in _context.User
                                    on p.UsersId equals x.UserId
                                 where p.Status == OrderStatus.Shipped || p.Status == OrderStatus.Delivered
                                 && p.IsActive == true
                                 orderby p.DateOrder descending
                                 select new GetOrderAllDTO
                                 {

                                     OrderId = p.OrderId,
                                     UsersId = p.UsersId,
                                     Rate = (int)p.Rate,
                                     Status = p.Status,
                                     Title = p.Title,
                                     DateOrder = p.DateOrder,
                                     isactive = p.IsActive,
                                     priceFinal2 = (decimal)p.priceFinal2,
                                     IsApproved = p.IsApproved,

                                 };


                    var Orders = await Ordera.ToListAsync();

                    if (Orders != null)
                    {
                        Log.Information("Order Is GetOrderAll");
                        Log.Debug($"Debugging Get Order By Id Has been Finised Successfully ");
                        return Orders;
                    }
                    else
                    {
                        Log.Error($"Order Not Found");
                        throw new ArgumentNullException("Order", "Not Found Order");

                    }



                }
                catch (ArgumentNullException ex)
                {
                    Log.Error($"Order Not Found: {ex.Message}");
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
            else {

                try
                {
                    Log.Information("Order Is starting GetOrderAll");

                    var Ordera = from p in _context.Order
                                 join x in _context.User
                                    on p.UsersId equals x.UserId
                                 where p.Status == OrderStatus.Pending
                                 && p.IsActive == true
                                 orderby p.DateOrder descending
                                 select new GetOrderAllDTO
                                 {

                                     OrderId = p.OrderId,
                                     UsersId = p.UsersId,
                                     Rate = (int)p.Rate,
                                     Status = p.Status,
                                     Title = p.Title,
                                     DateOrder = p.DateOrder,
                                     isactive = p.IsActive,
                                     priceFinal2 = (decimal)p.priceFinal2,
                                     IsApproved = p.IsApproved,

                                 };


                    var Orders = await Ordera.ToListAsync();

                    if (Orders != null)
                    {
                        Log.Information("Order Is GetOrderAll");
                        Log.Debug($"Debugging Get Order By Id Has been Finised Successfully ");
                        return Orders;
                    }
                    else
                    {
                        Log.Error($"Order Not Found");
                        throw new ArgumentNullException("Order", "Not Found Order");

                    }



                }
                catch (ArgumentNullException ex)
                {
                    Log.Error($"Order Not Found: {ex.Message}");
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


        public async Task<Order> GetOrderById(int OrderId)
        {
            var Order = await _context.Order.FindAsync(OrderId);

            return Order;
        }


        public async Task<GetOrderDetailDTO> GetOrderByIdServ(int OrderId)
        {
            try
            {

                Log.Information("Order Is starting GetOrderByIdServ");

                var Orders = from p in _context.Order
                             where p.OrderId == OrderId
                             join x in _context.User
                               on p.UsersId equals x.UserId
                             join S in _context.Services
                                on p.ServiceId equals S.ServiceId
                             //QA
                             //join G in _context.OrderService
                             //on p.OrderId equals G.OrderId
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
                                 ClientName = x.FirstName,
                                 Rate = (int)p.Rate, 
                                 Note = p.Note,
                                 isactive = p.IsActive,
                                 priceFinal2= (decimal)p.priceFinal2,
                                 Address1 = p.Address1,
                                 Address2 = p.Address2,
                                 city= p.city,
                                 NameService = S.Name,
                                 PhoneUser=x.Phone,
                                 Quantity = p.Quantity,
                                 serviceId = p.ServiceId,
                             };

                var qu = await Orders.LastOrDefaultAsync();
                if (qu != null)
                {
                    Log.Information("Order Is GetOrderByIdServ");
                    Log.Debug($"Debugging Get Order By Id Has been Finised Successfully With Order ID  = {qu.OrderId}");
                    return qu;
                }
                else
                {
                    Log.Error($"Order Not Found");
                    throw new ArgumentNullException("Order", "Not Found Order");

                }
            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Order Not Found: {ex.Message}");
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
        public async Task<int> CreateOrder(Order Inpute)
        {
            _context.Order.Add(Inpute);
            await _context.SaveChangesAsync();
            return Inpute.OrderId;
        }

        public async Task UpdateOrder(Order Inpute)
        {
            _context.Order.Update(Inpute);
            await _context.SaveChangesAsync();
        }


        public async Task UpdatePaymentMethod(PaymentMethod Inpute)
        {
            _context.PaymentMethod.Update(Inpute);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(Order Inpute)
        {
            _context.Order.Remove(Inpute);
            await _context.SaveChangesAsync();
        }


        public async Task<PaymentMethod> IsValidPayment(string code, string cardNumber, string cardHolder, decimal Price)
        {
            var payment = await _context.PaymentMethod.FirstOrDefaultAsync
                (x => x.Balance >= Price && x.CardHolder.Equals(cardHolder)
                && x.CardNumber.Equals(cardNumber) && x.Code.Equals(code));
            return payment;
        }

        public async Task<PaymentMethod> GetPaymentMethodById(int PaymentMethodId)
        {
            var PaymentMethod = await _context.PaymentMethod.FindAsync(PaymentMethodId);

            return PaymentMethod;
        }

      

    }
}
