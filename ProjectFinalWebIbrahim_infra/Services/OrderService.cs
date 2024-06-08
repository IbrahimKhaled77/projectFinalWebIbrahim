﻿
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using ProjectFinalWebIbrahim_infra.Repository;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class OrderServices:IOrderService
    {

        private readonly IOrderRepository _IOrderRepository;

        public OrderServices(IOrderRepository IOrderRepository ) {

            _IOrderRepository= IOrderRepository;


        }

        //client
        public async Task<string> CreateOrder(CreateOrderDTO Inpute)
        {
            try
            {

                var Order = new Order
                {


                    ModifiedDate = null,
                     Title = Inpute.Title,
                     Note = Inpute.Note,
                     DateOrder = Inpute.DateOrder,
                     Status = Inpute.Status,
                     Rate = Inpute.Rate,
                     UsersId = Inpute.UsersId,
                     PaymentMethod = Inpute.PaymentMethod,
                     IsِActive = Inpute.IsِActive,
                     CreationDate = DateTime.UtcNow,
            };

                if (Order != null)
                {

                    await _IOrderRepository.CreateOrder(Order);

                    return "AddOrder Has been Finised Successfully ";
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


        //provider and Admin
        public async Task<string> DeleteOrder(int OrderId)
        {
            try
            {

                var Order = await _IOrderRepository.GetOrderById(OrderId);

                if (Order != null)
                {

                    await _IOrderRepository.DeleteOrder(Order);

                    return "DeleteOrder success";

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

        //provider and Client
        public async Task<List<GetOrderAllDTO>> GetOrderAll()
        {
            return await _IOrderRepository.GetOrderAll();
        }

        //Admin and provider and Client 
        public async Task<GetOrderDetailDTO> GetOrderById(int OrderId)
        {
            return await _IOrderRepository.GetOrderByIdServ(OrderId);
        }


        //Provider
        public async  Task<string> UpdateOrder(UpdateOrderDTO Inpute)
        {
            try
            {



                var Order = await _IOrderRepository.GetOrderById(Inpute.OrderId);

                if (Order != null)
                {
                    Order.ModifiedDate = Inpute.ModifiedDate;
                    Order.Rate= Inpute.Rate;
                    Order.Status=Inpute.Status;
                    Order.IsِActive = Inpute.IsِActive;
                    Order.UsersId= Inpute.UsersId;



                    await _IOrderRepository.UpdateOrder(Order);

                    return "UpdateOrder success";

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
    }
}
