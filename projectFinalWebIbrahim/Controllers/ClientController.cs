using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;

namespace projectFinalWebIbrahim.Controllers
{
    public class ClientController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        private readonly IProblemService _IProblemService;
        private readonly IOrderService _IOrderService;
        public ClientController(IServiceService serviceService ,IProblemService problemService , IOrderService orderService )
        {

            _ServiceService = serviceService;
            _IProblemService = problemService;
            _IOrderService= orderService;

        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllService()
        {
            try
            {

                return StatusCode(201, await _ServiceService.GetServiceAll());

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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProblem([FromBody] CreateProblemDTO DTO)
        {
            try
            {
                return StatusCode(201, await _IProblemService.CreateProblem(DTO));

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
        [Route("[action]/{ProblemId}")]
        public async Task<IActionResult> GetProblemById([FromRoute] int ProblemId)
        {
            try
            {
                return StatusCode(201, await _IProblemService.GetProblemById(ProblemId));

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


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO DTO)
        {
            try
            {
                return StatusCode(201, await _IOrderService.CreateOrder(DTO));

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
