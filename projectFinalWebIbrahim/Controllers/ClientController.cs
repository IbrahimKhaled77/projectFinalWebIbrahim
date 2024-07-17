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

        #endregion

        #endregion

        #region Order

        #region  HttpGet GetAllOrder
        /// <response code="200">Returns  Get All Order Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>    
        ///<summary>
        /// I will retrieve all the Order present on the application.
        /// </summary>
        /// <returns>List of Order </returns>
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
        #endregion

        #region  HttpPost CreateOrder
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateOrder
        ///     {     
        ///        "DateOrder": "Enter the order date (Required)",
        ///        "Title": "Enter the order title (Required)",
        ///        "Note": "Enter any notes for the order",
        ///        "PaymentMethod": "Select the payment method (Required)",
        ///        "Status": "Enter the status of the order (Required)",
        ///        "Rate": "Enter the rate of the order",
        ///        "IsActive": "Indicate if the order is active (Required)",
        ///        "UsersId": "Enter the ID of the user associated with the order (Optional)"
        ///     }
        /// </remarks>
        /// <response code="201">Returns   Create Order  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Adds a new Order to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>


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

        #endregion

        #endregion

        #region Problem

        #region  HttpGet GetProblemById
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetProblemById
        ///     {        
        ///       "ProblemId": "Enter Your Problem ID Here (Required)", 
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Get  Problem by ProblemID Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If the error was occured  (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>       
        ///<summary>
        /// Retrieves a Problem by ID from the application
        /// </summary>
        /// <param name="ProblemId">The ID of the Problem to retrieve (Required).</param> 
        /// <returns>The Problem information. </returns>
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

        #endregion


        #region HttpPost CreateProblem


        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateProblem
        ///     {     
        ///        "Title": "Enter the problem title (Required)",
        ///        "Purpose": "Enter the purpose of the problem",
        ///        "Description": "Enter a detailed description of the problem",
        ///        "IsActive": "Indicate if the problem is active (Required)",
        ///        "OrderId": "Enter the ID of the order associated with the problem (Optional)"
        ///     }
        /// </remarks>
        /// <response code="201">Returns   Create Problem  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Adds a new Problem to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>

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
        #endregion

        #endregion


    }
}
