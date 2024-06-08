using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.Dtos.UserDTO;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using ProjectFinalWebIbrahim_infra.Services;

namespace projectFinalWebIbrahim.Controllers
{
    public class ProviderController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        private readonly IOrderService _IOrderService;
        public ProviderController(IOrderService OrderService,  IServiceService serviceService ) { 
        
            _ServiceService = serviceService;
            _IOrderService = OrderService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceDTO DTO)
        {
            try
            {
                return StatusCode(201, await _ServiceService.CreateService(DTO));

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);

            }
            catch (ArgumentNullException ex)
            {

                return StatusCode(404, ex.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceDTO updateDTO)
        {
            try
            {
                return StatusCode(201, await _ServiceService.UpdateService(updateDTO));

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);

            }
            catch (ArgumentNullException ex)
            {

                return StatusCode(404, ex.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {

                return StatusCode(201, await _IOrderService.GetOrderAll());

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);

            }
            catch (ArgumentNullException ex)
            {

                return StatusCode(404, ex.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]/{ServiceId}")]
        public async Task<IActionResult> DeleteService([FromRoute] int ServiceId)
        {
            try
            {
                return StatusCode(201, await _ServiceService.DeleteService(ServiceId));

            }
            catch (ArgumentNullException ex)
            {

                return StatusCode(404, ex.Message);

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);

            }

            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        
       }


        [HttpDelete]
        [Route("[action]/{OrderId}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int OrderId)
        {
            try
            {
                return StatusCode(201, await _IOrderService.DeleteOrder(OrderId));

            }
            catch (ArgumentNullException ex)
            {

                return StatusCode(404, ex.Message);

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);

            }

            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }



        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDTO updateDTO)
        {
            try
            {
                return StatusCode(201, await _IOrderService.UpdateOrder(updateDTO));

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);

            }
            catch (ArgumentNullException ex)
            {

                return StatusCode(404, ex.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }


    }
}
