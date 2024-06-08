

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.UserDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _IUserRepository;
        private readonly ILoginRepository _ILoginRepository;
        public UserService(IUserRepository IUserRepository , ILoginRepository ILoginRepository) {

            _IUserRepository = IUserRepository;
            _ILoginRepository = ILoginRepository;

    }
        public async Task<string> CreateUser(CreateUserDTO Inpute)
        {
            try {

                var user = new User {
                    FirstName = Inpute.FirstName,
                    LastName = Inpute.LastName,
                    Email = Inpute.Email,
                    Phone = Inpute.Phone,
                    BirthDate = Inpute.BirthDate,
                    CreationDate = Inpute.CreationDate,
                    Gender = Inpute.Gender,
                    UserType = Inpute.UserType,
                    IsِActive = Inpute.IsِActive,
                    ImageProfile = null,
                    ModifiedDate = null,
                    
               
                };

                //create  user and return ID
                var UserId = await _IUserRepository.CreateUser(user);

                Login login = new Login
                {

                    UserName = Inpute.Email,
                    Password = Inpute.Password,
                    CreationDate= Inpute.CreationDate,
                    IsِActive = Inpute.IsِActive,
                    UsersId = UserId,
                };
                
                await _ILoginRepository.Login(login);
                  
                return "Adduser Has been Finised Successfully ";
            }
            catch (ArgumentNullException ex)
            {
               
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
       
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
               
                throw new Exception($"Exception: {ex.Message}");
            }



        }

        public async Task<string> DeleteUser(int UserId)
        {
            try {

                var user= await _IUserRepository.GetUserById(UserId);

                if (user != null)
                {

                    await _IUserRepository.DeleteUser(user);
                    return "DeleteCustomer Has been Finised Successfully ";
                }
                else {

                    throw new ArgumentNullException("User", "Not Found");
                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"datebase Error: {ex.Message}");

            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"date Error: {ex.Message}");

            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");

            }
        }

        public async Task<List<GetUserAllDTO>> GetUserAll(int userId)
        {

            try {

                var userget= await _IUserRepository.GetUserAll(userId);

                if (userget != null)
                {

                    return userget.ToList();

                }
                else {


                    throw new ArgumentNullException("Not Found Users");

                
                }    


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"datebase Error: {ex.Message}");

            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"date Error: {ex.Message}");

            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");

            }


        }

        public async Task<GetUserDetailDTO> GetUserById(int UserId)
        {
            try {

                var user = await _IUserRepository.GetUserById(UserId);
                
                if (user !=null) {

                    var GetUserDetailDTO = new GetUserDetailDTO()
                    {
                        UserId = user.UserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = user.Gender,
                        Phone = user.Phone,
                        Email=user.Email,
                        BirthDate=user.BirthDate,
                        CreationDate=user.CreationDate,
                        ModifiedDate=user.ModifiedDate, 
                        ImageProfile=user.ImageProfile,
                        userType=user.UserType,
                        IsِActive = user.IsِActive,
                    };

                    return GetUserDetailDTO;

                }
                else {

                    throw new ArgumentNullException("User", "Not Found User");

                }



            }
            catch (ArgumentNullException ex)
            {
              
                throw new DbUpdateException($"datebase Error: {ex.Message}");

            }
            catch (DbUpdateException ex)
            {
               
                throw new DbUpdateException($"date Error: {ex.Message}");

            }
            catch (Exception ex)
            {
               
                throw new Exception($"Exception: {ex.Message}");

            }
        }

        public async Task<string> UpdateUser(UpdateUserDTO Inpute)
        {
            try
            {

                var user = await _IUserRepository.GetUserById(Inpute.UserId);

                if (user != null)
                {

                   user.Email = Inpute.Email;
                    user.FirstName = Inpute.FirstName;
                    user.LastName = Inpute.LastName;
                    user.BirthDate = Inpute.BirthDate;
                    user.ModifiedDate = Inpute.ModifiedDate;
                    user.Phone = Inpute.Phone;
                    user.ImageProfile =Inpute.ImageProfile;


                    await _IUserRepository.UpdateUser(user);

                    return "UpdateCustomer Has been Finised Successfully";
                }
                else {

                    throw new ArgumentNullException("User", "Not Found User");


                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"datebase Error: {ex.Message}");

            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"date Error: {ex.Message}");

            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");

            }
        }
    }
}
