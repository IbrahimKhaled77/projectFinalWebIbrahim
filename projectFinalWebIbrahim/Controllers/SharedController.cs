using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.LoginDTO;
using ProjectFinalWebIbrahim_core.Dtos.UserDTO;
using ProjectFinalWebIbrahim_core.IServices;


namespace projectFinalWebIbrahim.Controllers
{
    public class SharedController : ControllerBase
    {

        private readonly IUserService _userService;

        private readonly ILoginService _LoginService;
        private readonly ICategoryService _ICategoryService;
        private readonly IServiceService _ServiceService;
        private readonly IOrderService _IOrderService;
        public SharedController(IOrderService OrderService, IUserService userService, ICategoryService categoryService , ILoginService loginService, IServiceService serviceService)
        {
            _userService = userService;
            _LoginService = loginService;
            _ServiceService = serviceService;
            _ICategoryService = categoryService;
            _IOrderService = OrderService;
        }

        [HttpGet]
        [Route("[action]/{UserId}")]
        public async Task<IActionResult> GetAllUsers([FromRoute] int UserId)
        {
            try
            {

                return StatusCode(201, await _userService.GetUserAll(UserId));

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
        [Route("[action]/{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            try
            {
                return StatusCode(201, await _userService.GetUserById(userId)); 

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
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] CreateLoginDTO DTO)
        {
            try
            {
                return StatusCode(200, await _LoginService.Login(DTO));

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
        [Route("Logout")]
        public async Task<IActionResult> Logout(int UserId)
        {
            try
            {
                return StatusCode(201, await _LoginService.Logout(UserId));

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
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody]  ResetPasswordDTO ResetPasswordDTO)
        {
            try
            {
                return StatusCode(201, await _LoginService.ResetPassword(ResetPasswordDTO));

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

        //Service
        [HttpGet]
        [Route("[action]/{userId}")]
        public async Task<IActionResult> GetServiceById([FromRoute] int userId)
        {
            try
            {
                return StatusCode(201, await _ServiceService.GetServiceById(userId));

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


        //Category


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
    }
}
