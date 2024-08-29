
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.Dtos.LoginDTO;
using ProjectFinalWebIbrahim_core.Dtos.OrderDTO;
using ProjectFinalWebIbrahim_core.Dtos.ServiceDTO;
using ProjectFinalWebIbrahim_core.Helper;
using ProjectFinalWebIbrahim_core.IServices;
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace projectFinalWebIbrahim.Controllers
{

    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {

        private readonly IServiceService _ServiceService;
        private readonly IProblemService _IProblemService;
        private readonly ICategoryService _ICategoryService;
        private readonly IOrderService _IOrderService;
        private readonly IUserService _IUserService;
        private readonly ILoginService _ILoginService;
        public AdminController(ILoginService LoginService, IOrderService OrderService, IServiceService serviceService, IProblemService problemService, ICategoryService categoryService, IUserService UserService)
        {

            _ServiceService = serviceService;
            _IProblemService = problemService;
            _ICategoryService = categoryService;
            _IOrderService = OrderService;
            _IUserService = UserService;
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
        public async Task<IActionResult> GetAllService([FromHeader]string token)
        {
            try
            {

                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {
                    return StatusCode(200, await _ServiceService.GetServiceAll());
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


             

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

        #region HttpPost CreateService
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post api/CreateUser
        ///     {        
        ///        "Name": "Enter Product Name Here (Required)",
        ///        "Description": "Enter Product Description Here",
        ///        "Image": "Enter URL of Product Image",
        ///        "Price": "Enter Product Price Here (Required)",
        ///        "PriceAfterDiscount": "Enter Price After Discount",
        ///        "QuantityUnit": "Select Quantity Unit Type",
        ///        "IsHaveDiscount": "Indicate if the product has a discount",
        ///        "DiscountPrice": "Enter Discount Price",
        ///        "DiscountType": "Enter Discount Type",
        ///        "IsActive": "Indicate if the product is active",
        ///        "CategoryId": "Enter Category ID (Optional)",
        ///        "UserId": "Enter User ID (Optional)"
        ///      
        ///     }
        /// </remarks>
        /// <response code="201">Returns   Create Service  Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Adds a new Service to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceDTO DTO, [FromHeader] string token)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {
                    return StatusCode(201, await _ServiceService.CreateService(DTO));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


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


        #region HttpPut UpdateService
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/UpdateService
        ///     {     
        ///        "ServiceId": "Enter your Service ID whose information you want to update",
        ///        "Name": "Enter Service Name Here (Required)",
        ///        "Description": "Enter Service Description Here",
        ///        "Image": "Enter URL of Service Image",
        ///        "Price": "Enter Service Price Here (Required)",
        ///        "PriceAfterDiscount": "Enter Price After Discount",
        ///        "QuantityUnit": "Select Quantity Unit Type",
        ///        "IsHaveDiscount": "Indicate if the service has a discount",
        ///        "DiscountPrice": "Enter Discount Price",
        ///        "DiscountType": "Enter Discount Type",
        ///        "IsActive": "Indicate if the service is active",
        ///        "CategoryId": "Enter Category ID (Optional)",
        ///        "UserId": "Enter User ID (Optional)"
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Update Service Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update Service from the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceDTO updateDTO, [FromHeader] string token)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {
                    return StatusCode(200, await _ServiceService.UpdateService(updateDTO));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


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
        public async Task<IActionResult> DeleteService([FromRoute] int ServiceId, [FromHeader] string token)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {

                    return StatusCode(200, await _ServiceService.DeleteService(ServiceId));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


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


        #region  HttpPut UpdateServiceApprovment
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateUserApprovment
        ///     {     
        ///        "ServiceId": "Enter the ID of the Service to update",
        ///        "value": "Enter the IsApprovment ",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns Service Has Been Update</response>
        /// <response code="503">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update a  ServiceApprovment to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateServiceApprovment([FromQuery] int ServiceId, [FromQuery] bool value, [FromHeader] string token)
        {
            if (ServiceId == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {

                    if (TokenHelper.IsValidToken(token) == UserType.Admin)
                    {

                        await _ServiceService.UpdateServiceApprovment(ServiceId, value);
                        return StatusCode(200, "Service Has Been UpdateServiceApprovment");
                    }
                    return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");



                   
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        #endregion


        #region  HttpPut UpdateServiceActivation
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateServiceActivation
        ///     {     
        ///        "ServiceId": "Enter the ID of the Service to update",
        ///        "value": "Enter the IsActivation ",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns Category Has Been Update</response>
        /// <response code="503">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update a  UpdateServiceActivation to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateServiceActivation([FromQuery] int ServiceId, [FromQuery] bool value, [FromHeader] string token)
        {
            if (ServiceId == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {

                    if (TokenHelper.IsValidToken(token) == UserType.Admin)
                    {

                        await _ServiceService.UpdateServiceActivation(ServiceId, value);
                        return StatusCode(200, "Service Has Been UpdateServiceActivation");
                    }
                    return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


                   
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
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
            public async Task<IActionResult> GetAllproblem([FromHeader] string token)
            {
                try
                {

                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {

                    return StatusCode(200, await _IProblemService.GetProblemAll());
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");
              

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
                if (TokenHelper.IsValidToken(token) == UserType.Admin)
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
            public async Task<IActionResult> Deleteproblem([FromRoute] int problemId, [FromHeader] string token)
            {
                try
                {

                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {

                    return StatusCode(200, await _IProblemService.DeleteProblem(problemId));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");
             

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

        #region  HttpPut UpdateProblemActivation
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateProblemActivation
        ///     {     
        ///        "ProblemId": "Enter the ID of the Problem to update",
        ///        "value": "Enter the IsActivation ",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns Problem Has Been Update</response>
        /// <response code="503">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update a  UpdateProblemActivation to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProblemActivation([FromQuery] int ProblemId, [FromQuery] bool value, [FromHeader] string token)
        {
            if (ProblemId == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    if (TokenHelper.IsValidToken(token) == UserType.Admin)
                    {

                        await _IProblemService.UpdateProblemActivation(ProblemId, value);
                        return StatusCode(200, "Problem Has Been Update");
                    }
                    return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");

                   
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
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
            public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO DTO, [FromHeader] string token)
            {
                try
                {

                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {
                    return StatusCode(201, await _ICategoryService.CreateCategory(DTO));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");

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
            public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDTO updateDTO, [FromHeader] string token)
            {
                try
                {
                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {

                    return StatusCode(201, await _ICategoryService.UpdateCategory(updateDTO));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");

           

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
            public async Task<IActionResult> DeleteCategory([FromRoute] int CategoryId, [FromHeader] string token)
            {
                try
                {

                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {

                    return StatusCode(200, await _ICategoryService.DeleteCategory(CategoryId));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


       

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


            #region  HttpPut UpdateCategoryActivation
            /// <remarks>
            /// Sample request:
            /// 
            ///     Put api/UpdateCategoryActivation
            ///     {     
            ///        "CategoryId": "Enter the ID of the Category to update",
            ///        "value": "Enter the IsActivation ",
            ///      
            ///     }
            /// </remarks>
            /// <response code="200">Returns Category Has Been Update</response>
            /// <response code="503">If the error was occured  (Exception)</response>       
            ///<summary>
            /// Update a  UpdateCategoryActivation to the database.
            /// </summary>
            /// <returns>A message indicating the success of the operation </returns>

            [HttpPut]
            [Route("[action]")]
            public async Task<IActionResult> UpdateCategoryActivation([FromQuery] int CategoryId, [FromQuery] bool value, [FromHeader] string token)
            {
                if (CategoryId == 0)
                {
                    return BadRequest("Please Fill All Data");
                }
                else
                {
                    try
                    {


                    if (TokenHelper.IsValidToken(token) == UserType.Admin)
                    {

                        await _ICategoryService.UpdateCategoryActivation(CategoryId, value);
                        return StatusCode(200, "Category Has Been Update");
                    }
                    return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");

                 
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(503, $"Error Orrued {ex.Message}");
                    }
                }
            }

        #endregion






        #endregion

        #region Order

        #region  HttpGet  GetAllOrder
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
        public async Task<IActionResult> GetAllOrder([FromHeader] string token, [FromQuery]  bool? IsApproved)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {
                    return StatusCode(200, await _IOrderService.GetOrderAll(IsApproved));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");



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



        #region HttpDelete  UpdateOrder
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT api/UpdateOrder
        ///     {     
        ///        "OrderId": "Enter the ID of the order to update",
        ///        "Status": "Enter the status of the order",
        ///        "Rate": "Enter the rate of the order",
        ///        "IsActive": "Indicate if the order is active",
        ///        "UsersId": "Enter the ID of the user associated with the order (Optional)"
        ///     }
        /// </remarks>
        /// <response code="200">Returns  Update Order Successfully</response>
        /// <response code="404">If the error was occured  (Not Found)</response>
        /// <response code="500">If an internal server error or database error occurs (Internal Server Error OR Database)</response>   
        /// <response code="400">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update Order from the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>


        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDTO updateDTO, [FromHeader] string token)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {
                    return StatusCode(200, await _IOrderService.UpdateOrder(updateDTO));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


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



        #region  HttpPut UpdateOrderApprovment
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateOrderApprovment
        ///     {     
        ///        "OrderId": "Enter the ID of the Order to update",
        ///        "value": "Enter the IsApprovment ",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns Order Has Been Update</response>
        /// <response code="503">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update a  OrderApprovment to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateOrderApprovment([FromQuery] int OrderId, [FromQuery] bool value, [FromHeader] string token)
        {
            if (OrderId == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    if (TokenHelper.IsValidToken(token) == UserType.Admin)
                    {
                        await _IOrderService.UpdateOrderApprovment(OrderId, value);
                        return StatusCode(200, "Order Has Been Update");
                    }
                    return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        #endregion


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
            public async Task<IActionResult> DeleteOrder([FromRoute] int OrderId, [FromHeader] string token)
            {
                try
                {


                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {

                    return StatusCode(200, await _IOrderService.DeleteOrder(OrderId));
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");

            

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


            #region  HttpPut UpdateOrderActivation
            /// <remarks>
            /// Sample request:
            /// 
            ///     Put api/UpdateOrderActivation
            ///     {     
            ///        "OrderId": "Enter the ID of the Order to update",
            ///        "value": "Enter the IsActivation ",
            ///      
            ///     }
            /// </remarks>
            /// <response code="200">Returns Order Has Been Update</response>
            /// <response code="503">If the error was occured  (Exception)</response>       
            ///<summary>
            /// Update a  UpdateOrderActivation to the database.
            /// </summary>
            /// <returns>A message indicating the success of the operation </returns>

            [HttpPut]
            [Route("[action]")]
            public async Task<IActionResult> UpdateOrderActivation([FromQuery] int OrderId, [FromQuery] bool value, [FromHeader] string token)
            {
                if (OrderId == 0)
                {
                    return BadRequest("Please Fill All Data");
                }
                else
                {
                    try
                    {
                    if (TokenHelper.IsValidToken(token) == UserType.Admin)
                    {

                        await _IOrderService.UpdateOrderActivation(OrderId, value);
                        return StatusCode(200, "Order Has Been Update");
                    }
                    return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


               
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(503, $"Error Orrued {ex.Message}");
                    }
                }
            }

            #endregion

            #endregion

            #region User
            #region  HttpPut UpdateUserApprovment
            /// <remarks>
            /// Sample request:
            /// 
            ///     Put api/UpdateUserApprovment
            ///     {     
            ///        "UserId": "Enter the ID of the User to update",
            ///        "value": "Enter the IsApprovment ",
            ///      
            ///     }
            /// </remarks>
            /// <response code="200">Returns User Has Been Update</response>
            /// <response code="503">If the error was occured  (Exception)</response>       
            ///<summary>
            /// Update a  UserApprovment to the database.
            /// </summary>
            /// <returns>A message indicating the success of the operation </returns>

            [HttpPut]
            [Route("[action]")]
            public async Task<IActionResult> UpdateUserApprovment([FromQuery] int UserId, [FromQuery] bool value, [FromHeader] string token)
            {
                if (UserId == 0)
                {
                    return BadRequest("Please Fill All Data");
                }
                else
                {
                    try
                    {
                    if (TokenHelper.IsValidToken(token) == UserType.Admin)
                    {

                        await _IUserService.UpdateUserApprovment(UserId, value);
                        return StatusCode(200, "Blog Has Been Update");
                    }
                    return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");

              
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(503, $"Error Orrued {ex.Message}");
                    }
                }
            }

        #endregion

        #region  HttpPut UpdateUserActivation
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put api/UpdateUserActivation
        ///     {     
        ///        "ServiceId": "Enter the ID of the User to update",
        ///        "value": "Enter the IsActivation ",
        ///      
        ///     }
        /// </remarks>
        /// <response code="200">Returns user Has Been Update</response>
        /// <response code="503">If the error was occured  (Exception)</response>       
        ///<summary>
        /// Update a  UpdateUserActivation to the database.
        /// </summary>
        /// <returns>A message indicating the success of the operation </returns>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateeUserActivation([FromQuery] int UserId, [FromQuery] bool value, [FromHeader] string token)
        {
            if (UserId == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    if (TokenHelper.IsValidToken(token) == UserType.Admin)
                    {

                        await _IUserService.UpdateeUserActivation(UserId, value);
                        return StatusCode(200, "User Has Been UpdateeUserActivation");
                    }
                    return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");


                    
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        #endregion


        #region  HttpGet GetAllUsers
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/GetAllUsers
        ///     {        
        ///     
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
        /// <returns>List of Users </returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers([FromHeader] string token)
        {
            try
            {
                if (TokenHelper.IsValidToken(token) == UserType.Admin)
                {

                    return StatusCode(200, await _IUserService.GetUserAll());
                }
                return StatusCode(401, "You're Unautharized to Use This Funcationality & Is not Admin");
                

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
        public async Task<IActionResult> LoginbyAdmin([FromBody] CreateLoginDTO DTO)
        {
            try
            {
                return StatusCode(201, await _ILoginService.LoginbyAdmin(DTO));

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

