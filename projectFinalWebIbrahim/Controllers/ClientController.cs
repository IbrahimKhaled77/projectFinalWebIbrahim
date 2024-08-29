using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.LoginDTO;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;

using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.Helper;
using ProjectFinalWebIbrahim_core.IServices;

using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace projectFinalWebIbrahim.Controllers
{
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        private readonly IProblemService _IProblemService;
        private readonly IOrderService _IOrderService;
   
        private readonly ILoginService _ILoginService;
        public ClientController(ILoginService LoginService, IServiceService serviceService, IProblemService problemService, IOrderService orderService)
        {

            _ServiceService = serviceService;
            _IProblemService = problemService;
            _IOrderService = orderService;
        
            _ILoginService = LoginService;

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
        public async Task<IActionResult> GetAllService([FromHeader] string token)
        {
            try
            {

                if (TokenHelper.IsValidToken(token) == UserType.Clien)
                {
                    return StatusCode(201, await _ServiceService.GetServiceAll());
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Clien");




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


        #region  HttpGet GetServiceCustomerAll
        /// <response code="200">Returns  Get All Service Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>    
        ///<summary>
        /// I will retrieve all the Service present on the application.
        /// </summary>
        /// <returns>List of Service </returns>

        [HttpGet]
        [Route("[action]/{CategorId}")]
        public async Task<IActionResult> GetServiceCustomerAll( [FromRoute] int CategorId)
        {
            try
            {

               
                
                    return StatusCode(201, await _ServiceService.GetServiceCustomerAll(CategorId));
                
               




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

        #region  HttpGet GetAllOrderUser
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
        public async Task<IActionResult> GetAllOrderUser([FromHeader] string token)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Clien)
                {
                    return StatusCode(201, await _IOrderService.GetOrderAlUser(TokenHelper.IsUserIdToken(token)));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Clien");


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
        [Route("[action]/{serviceId}")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO DTO, [FromHeader] string token, [FromRoute] int serviceId)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Clien || token !=null)
                {
                    return StatusCode(201, await _IOrderService.CreateOrder(DTO, serviceId));
                }
                else
                {
                    return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Clien");
                }
               



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

        #region HttpDelete  Rating
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT api/Rating
        ///     {     
        ///        "OrderId": "Enter the ID of the order to update",
        ///        "Status": "Enter the status of the order",
        ///        "Rate": "Enter the rate of the order",
        ///        "IsActive": "Indicate if the order is active",
        ///        "UsersId": "Enter the ID of the user associated with the order (Optional)"
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Update Rating Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update Rating from the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>


        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Rating([FromBody] RatingDTO DTO)
        {
            try
            {
            
                
                    return StatusCode(200, await _IOrderService.Rating(DTO));
                
              


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
        public async Task<IActionResult> GetProblemById([FromRoute] int ProblemId, [FromHeader] string token)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Clien)
                {
                    return StatusCode(201, await _IProblemService.GetProblemById(ProblemId));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Clien");


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
        public async Task<IActionResult> CreateProblem([FromBody] CreateProblemDTO DTO, [FromHeader] string token)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Clien)
                {
                    return StatusCode(201, await _IProblemService.CreateProblem(DTO));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Clien");


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


        #region  HttpPost Login
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/Login
        ///     {        
        ///        "Email": "Enter Your Email Here (Required)",
        ///        "password": "Enter Your password Here (Required)",
        ///      
        ///     }
        /// </remarks>
        /// <response code="201">Returns  Login  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Adds a new Token customer to the database.
        /// </summary>
        /// <param name="DTO">The Email and Password of the  User to Login (Required).</param>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LoginbyUser([FromBody] CreateLoginDTO DTO)
        {
            try
            {
                return StatusCode(201, await _ILoginService.LoginbyUser(DTO));

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

    }
}








/*

        #region  HttpPost CreateOrderService
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateOrderService
        ///     {     
        ///        "OrderId": "Enter the order Id (Required)",
        ///        "ServiceId": "Enter the Service Id  (Required)",
        ///        "CardNumber": "Enter the CardNumber   (Required)",
        ///         "Code": "Enter the Code   (Required)",
        ///         "CardNumber": "Enter the CardNumber   (Required)",
        ///        "CardHolder": "Enter the CardHolder   (Required)",
        ///        "IsActive": "Indicate if the order is active (Required)",
        ///     }
        /// </remarks>
        /// <response code="201">Returns   Create Order Service  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Adds a new Order Service to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateOrderService([FromBody] CreateOrderServiceDTO DTO, [FromHeader] string token)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Clien)
                {
                    return StatusCode(201, await _IOrderServiceService.CreateOrderService(DTO));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Clien");



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
        */
