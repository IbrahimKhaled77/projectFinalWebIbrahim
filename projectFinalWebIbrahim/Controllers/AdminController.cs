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


        #region Service

        #region  HttpGet GetAllService
        /// <response code="200">Returns  Get All Service Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>    
        ///<summary>
        /// I will retrieve all the Service present on the application.
        /// </summary>
        /// <returns>List of Service </returns>


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllService()
        {
            try
            {

                return StatusCode(200, await _ServiceService.GetServiceAll());

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

        #endregion

        #region  HttpDelete DeleteService
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteService
        ///     {     
        ///        "ServiceId": "Enter your Service  ID whose information you want to Delete",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Delete Service Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Delete a  Service from the database.
        /// </summary>
        /// <param name="ServiceId">The ID of the Service to Delete (Required).</param>
        /// <returns>A message indicating the success of the operation </returns>
        [HttpDelete]
        [Route("[action]/{ServiceId}")]
        public async Task<IActionResult> DeleteService([FromRoute] int ServiceId)
        {
            try
            {
                return StatusCode(200, await _ServiceService.DeleteService(ServiceId));

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

        #endregion

        #endregion

        #region Problem
        #region  HttpGet GetAllproblem
        /// <response code="200">Returns  Get All problem Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>    
        ///<summary>
        /// I will retrieve all the problem present on the application.
        /// </summary>
        /// <returns>List of problem </returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllproblem()
        {
            try
            {

                return StatusCode(200, await _IProblemService.GetProblemAll());

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
        #endregion

        #region  HttpDelete Deleteproblem
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/Deleteproblem
        ///     {     
        ///        "problemId": "Enter your problem  ID whose information you want to Delete",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Delete problem Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Delete a  problem from the database.
        /// </summary>
        /// <param name="problemId">The ID of the problem to Delete (Required).</param>
        /// <returns>A message indicating the success of the operation </returns>
        [HttpDelete]
        [Route("[action]/{problemId}")]
        public async Task<IActionResult> Deleteproblem([FromRoute] int problemId)
        {
            try
            {
                return StatusCode(200, await _IProblemService.DeleteProblem(problemId));

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
        #endregion

        #endregion

        #region Category

        #region  HttpPost CreateCategory
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/CreateCategory
        ///     {        
        ///        "Title": "Enter the category title (Required)",
        ///        "Description": "Enter the category description",
        ///        "ImageTitleCategory": "Enter the URL of the category title image (Optional)",
        ///        "CreationDate": "Enter the creation date (Optional, auto-set to current date if not provided)",
        ///        "IsActive": "Indicate if the category is active (Required)"
        ///      
        ///     }
        /// </remarks>
        /// <response code="201">Returns   Create Category  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Adds a new Category to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>
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
        #endregion

        #region  HttpPut UpdateCategory
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateCategory
        ///     {     
        ///        "CategoryId": "Enter the ID of the category to update",
        ///        "Title": "Enter the category title (Required)",
        ///        "Description": "Enter the category description",
        ///        "ImageTitleCategory": "Enter the URL of the category title image (Optional)",
        ///        "ModifiedDate": "Enter the modified date (Optional, auto-set to current date if not provided)",
        ///        "IsActive": "Indicate if the category is active (Required)"
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Update Category Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update a  Category to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>
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
        #endregion

        #region  HttpDelete DeleteCategory
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteCategory
        ///     {     
        ///        "CategoryId": "Enter your Category  ID whose information you want to Delete",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Delete Category Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Delete a  Category from the database.
        /// </summary>
        /// <param name="OrderId">The ID of the Category to Delete (Required).</param>
        /// <returns>A message indicating the success of the operation </returns>
        [HttpDelete]
        [Route("[action]/{CategoryId}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int CategoryId)
        {
            try
            {
                return StatusCode(200, await _ICategoryService.DeleteCategory(CategoryId));

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

        #endregion

      


        #endregion

        #region Order

        #region  HttpDelete DeleteOrder

        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteOrder
        ///     {     
        ///        "OrderId": "Enter your Order  ID whose information you want to Delete",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Delete Order Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Delete a  Order from the database.
        /// </summary>
        /// <param name="OrderId">The ID of the Order to Delete (Required).</param>
        /// <returns>A message indicating the success of the operation </returns>
        [HttpDelete]
        [Route("[action]/{OrderId}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int OrderId)
        {
            try
            {
                return StatusCode(200, await _IOrderService.DeleteOrder(OrderId));

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

        #endregion

        #endregion
    }
}
