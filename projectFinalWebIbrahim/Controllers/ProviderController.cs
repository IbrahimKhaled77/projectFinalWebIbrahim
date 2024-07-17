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
        public ProviderController(IOrderService OrderService, IServiceService serviceService) {

            _ServiceService = serviceService;
            _IOrderService = OrderService;
        }

        #region Service

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
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceDTO updateDTO)
        {
            try
            {
                return StatusCode(200, await _ServiceService.UpdateService(updateDTO));

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


        #region  HttpDelete  DeleteService
        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteService
        ///     {     
        ///        "ServiceId": "Enter your Service ID whose information you want to Delete",
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
        public async Task<IActionResult> UpdateServiceActivation([FromQuery] int ServiceId, [FromQuery] bool value)
        {
            if (ServiceId == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _ServiceService.UpdateServiceActivation(ServiceId, value);
                    return StatusCode(200, "Service Has Been UpdateServiceActivation");
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
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {

                return StatusCode(200, await _IOrderService.GetOrderAll());

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
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDTO updateDTO)
        {
            try
            {
                return StatusCode(200, await _IOrderService.UpdateOrder(updateDTO));

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

        #region HttpDelete  DeleteOrder

        /// <remarks>
        /// Sample request:
        /// 
        ///     Delete api/DeleteOrder
        ///     {     
        ///        "OrderId": "Enter your Order ID whose information you want to Delete",
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
        public async Task<IActionResult> UpdateOrderApprovment([FromQuery] int OrderId, [FromQuery] bool value)
        {
            if (OrderId == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _IOrderService.UpdateOrderApprovment(OrderId, value);
                    return StatusCode(200, "Order Has Been Update");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
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
        public async Task<IActionResult> UpdateOrderActivation([FromQuery] int OrderId, [FromQuery] bool value)
        {
            if (OrderId == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _IOrderService.UpdateOrderActivation(OrderId, value);
                    return StatusCode(200, "Order Has Been Update");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        #endregion

        #endregion


     

    }
}