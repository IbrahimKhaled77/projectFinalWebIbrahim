using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.Dtos.LoginDTO;
using ProjectFinalWebIbrahim_core.Dtos.paymentMethodDTO;
using ProjectFinalWebIbrahim_core.Dtos.UserDTO;
using ProjectFinalWebIbrahim_core.Helper;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_infra.Services;


namespace projectFinalWebIbrahim.Controllers
{
    public class SharedController : ControllerBase
    {

        private readonly IUserService _userService;

        private readonly ILoginService _LoginService;
        private readonly ICategoryService _ICategoryService;
        private readonly IServiceService _ServiceService;
        private readonly IOrderService _IOrderService;
      
        public SharedController(IOrderService OrderService,  IUserService userService, ICategoryService categoryService , ILoginService loginService, IServiceService serviceService)
        {
            _userService = userService;
            _LoginService = loginService;
            _ServiceService = serviceService;
            _ICategoryService = categoryService;
            _IOrderService = OrderService;
            
        }

        #region User
        #region  HttpGet GetAllUsers
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/GetAllUsers
        ///     {        
        ///        "UserId": "Enter Your UserId Here (Required)",
        ///        
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Get All Users Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>    
        ///<summary>
        /// I will retrieve all the Users present on the application.
        /// </summary>
        /// <param name="UserId">The UserId of the  Customer to Get All Users (Required).</param>
        /// <returns>List of Users </returns>
        [HttpGet]
        [Route("[action]/{UserId}")]
        public async Task<IActionResult> GetAllUsers([FromRoute] int UserId)
        {
            try
            {

                return StatusCode(200, await _userService.GetUserAll(UserId));

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

        #region  HttpGet GetUserById
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetUserById
        ///     {        
        ///       "UserId": "Enter Your User ID Here (Required)", 
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Get  User by UserID Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If the error was occured  (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>       
        ///<summary>
        /// Retrieves a User by ID from the application
        /// </summary>
        /// <param name="UserId">The ID of the User to retrieve (Required).</param> 
        /// <returns>The User information. </returns>
        [HttpGet]
        [Route("[action]/{UserId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int UserId)
        {
            try
            {
                return StatusCode(200, await _userService.GetUserById(UserId)); 

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


        #region  HttpPost CreateUser
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/CreateUser
        ///     {        
        ///        "FirstName": "Enter Your First Name Here (Required)",
        ///        "LastName": "Enter Your Last Name Here (Required)",
        ///        "Email": "Enter Your Email Here (Required)",
        ///        "Password": "Enter Your Password Here (Required)",
        ///        "Phone": "Enter Your Phone Number Here (Required)",
        ///        "Gender": "Select Your Gender (Required)",
        ///        "BirthDate": "Enter Your Birth Date Here (Required)",
        ///        "UserType": "Select Your User Type(Admin,Client,Provider) (Required)",
        ///        "IsActive": "Indicate if the account is active (Required)"
        ///      
        ///     }
        /// </remarks>
        /// <response code="201">Returns   Create User  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Adds a new User to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO DTO)
        {
            try
            {
                return StatusCode(201, await _userService.CreateUser(DTO));

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

        #region  HttpPut UpdateUser
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateUser
        ///     {     
        ///        "UserId": "Enter your User ID whose information you want to update",
        ///        "FirstName": "Enter Your First Name Here (Required)",
        ///        "LastName": "Enter Your Last Name Here (Required)",
        ///        "Email": "Enter Your Email Here (Required)",
        ///        "Phone": "Enter Your Phone Number Here (Required)",
        ///        "ImageProfile": "Enter URL of your profile image (Optional)",
        ///        "BirthDate": "Enter Your Birth Date Here (Required)",
        ///        "IsActive": "Indicate if the account is active (Required)"
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Update User Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update a  User to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO updateDTO)
        {
            try
            {
                return StatusCode(201, await _userService.UpdateUser(updateDTO));

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

        #region  HttpDelete Deleteuser
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/Deleteuser
        ///     {     
        ///        "userId": "Enter your user  ID whose information you want to Delete",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Delete user Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Delete a  user from the database.
        /// </summary>
        /// <param name="userId">The ID of the user to Delete (Required).</param>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpDelete]
        [Route("[action]/{userId}")]
        public async Task<IActionResult> Deleteuser([FromRoute] int userId)
        {
            try
            {
                return StatusCode(201, await _userService.DeleteUser(userId));

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


        #region Authantication

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
        public async Task<IActionResult> Login([FromBody] CreateLoginDTO DTO)
        {
            try
            {
                return StatusCode(201, await _LoginService.Login(DTO));

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

        #region HttpPut Logout
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/Logout
        ///     {        
        ///       "UserId": "Enter the  user  UserId (Required)",
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Logout  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Remove a Token User to the database And IsActive.
        /// </summary>
        /// <param name="UserId">The User Id  to Logout (Required).</param>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpPut]
        [Route("Logout/{UserId}")]
        public async Task<IActionResult> Logout([FromRoute]int UserId)
        {
            try
            {
                return StatusCode(200, await _LoginService.Logout(UserId));

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

        #region HttpPut ResetPassword
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/ResetPassword
        ///     {        
        ///       "Email": "Enter the  user  Email ",
        ///       "NewPassword": "Enter the  user  NewPassword ",
        ///     }
        /// </remarks>
        /// <response code="200">Returns  ResetPassword  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Adds a new Password  to customer by Email .
        /// </summary>
        /// <param name="ResetPasswordDTO">The email and new password of the user to reset (Required).</param>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpPut]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody]  ResetPasswordDTO ResetPasswordDTO)
        {
            try
            {
                return StatusCode(200, await _LoginService.ResetPassword(ResetPasswordDTO));

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

        #region Service
        #region HttpGet GetServiceById
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetServiceById
        ///     {        
        ///       "UserId": "Enter Your User ID Here (Required)", 
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Get  User by UserID Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If the error was occured  (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>       
        ///<summary>
        /// Retrieves a User by ID from the application
        /// </summary>
        /// <param name="ServiceId">The ID of the Service to retrieve (Required).</param> 
        /// <returns>The User information. </returns>
        //Service
        [HttpGet]
        [Route("[action]/{ServiceId}")]
        public async Task<IActionResult> GetServiceById([FromRoute] int ServiceId)
        {
            try
            {
                return StatusCode(201, await _ServiceService.GetServiceById(ServiceId));

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

        #region Category
        #region  HttpGet  GetCategoryAll
        /// <response code="200">Returns  Get All Category Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>    
        ///<summary>
        /// I will retrieve all the Category present on the application.
        /// </summary>
        /// <returns>List of Category </returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCategoryAll()
        {
            try
            {

                return StatusCode(201, await _ICategoryService.GetCategoryAll());

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

        /*
        #region  HttpPost CreatePaymentMethod
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/CreatePaymentMethod
        ///     {        
        ///        "CardNumber": "Enter the category CardNumber (Required)",
        ///        "Code": "Enter the Code ",
        ///        "CardHolder": "Enter the URL of the CardHolder title image (Optional)",
        ///        "ExpireDate": "Enter the ExpireDate  ",
        ///        "Balance": "Enter if the Balance  (Required)"
        ///      
        ///     }
        /// </remarks>
        /// <response code="201">Returns   Create PaymentMethod  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Adds a new PaymentMethod to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreatePaymentMethod([FromBody] CreatepaymentMethodDTO DTO)
        {
            try
            {

               
                    return StatusCode(201, await _IPaymentMethodService.CreatepaymentMethod(DTO));
                
               

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

        #region  HttpPut UpdatePaymentMethod
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdatePaymentMethod
        ///     {     
        ///        "PaymentMethodId": "Enter the ID of the PaymentMethod to update",
        ///        "UsersId": "Enter the Users Id ",
        ///        "CardNumber": "Enter the CardNumber ",
        ///        "Code": "Enter  the Code ",
        ///        "CardHolder": "Enter the CardHolder",
        ///        "ExpireDate": "Enter  the ExpireDate ",
        ///           "Balance": "Enter  the Balance "
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Update PaymentMethod Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update a  PaymentMethod to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePaymentMethod([FromBody] UpdatePaymentMethodDTo updateDTO)
        {
            try
            {
         
           

                    return StatusCode(201, await _IPaymentMethodService.UpdatePaymentMethod(updateDTO));
               
             



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


        #region Order
        #region HttpGet GetOrderById
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetOrderById
        ///     {        
        ///       "OrderId": "Enter Your Order ID Here (Required)", 
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Get  Order by OrderID Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If the error was occured  (Internal Server Error OR Database)</response>   
        /// <response code="400">If an exception occurs (Exception)</response>       
        ///<summary>
        /// Retrieves a User by ID from the application
        /// </summary>
        /// <param name="OrderId">The ID of the Order to retrieve (Required).</param> 
        /// <returns>The Order information. </returns>


        //Order
        [HttpGet]
        [Route("[action]/{OrderId}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int OrderId)
        {
            try
            {
                return StatusCode(201, await _IOrderService.GetOrderById(OrderId));

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
