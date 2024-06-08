using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_infra.Services;

namespace projectFinalWebIbrahim.Controllers
{
    public class AdminController : ControllerBase
    {

        private readonly IServiceService _ServiceService;
        private readonly IProblemService _IProblemService;
        private readonly ICategoryService _ICategoryService;
        private readonly IOrderService _IOrderService;
        public AdminController(IOrderService OrderService,  IServiceService serviceService, IProblemService problemService , ICategoryService categoryService) {

            _ServiceService=serviceService;
            _IProblemService=problemService;
            _ICategoryService=categoryService;
            _IOrderService = OrderService;
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



        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllproblem()
        {
            try
            {

                return StatusCode(201, await _IProblemService.GetProblemAll());

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
        [Route("[action]/{problemId}")]
        public async Task<IActionResult> Deleteproblem([FromRoute] int problemId)
        {
            try
            {
                return StatusCode(201, await _IProblemService.DeleteProblem(problemId));

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


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO DTO)
        {
            try
            {
                return StatusCode(201, await _ICategoryService.CreateCategory(DTO));

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
        [Route("[action]/{CategoryId}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int CategoryId)
        {
            try
            {
                return StatusCode(201, await _ICategoryService.DeleteCategory(CategoryId));

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
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDTO updateDTO)
        {
            try
            {
                return StatusCode(201, await _ICategoryService.UpdateCategory(updateDTO));

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
    }
}
