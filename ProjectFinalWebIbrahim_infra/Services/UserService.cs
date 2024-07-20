

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.UserDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;


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

        public async Task<List<GetUserAllDTO>> GetUserAll(int userId)
        {

            try
            {

                var userget = await _IUserRepository.GetUserAll(userId);

                if (userget != null)
                {

                    Log.Information("Users are Reached");
                    Log.Debug($"Debugging GetAllUsers Has been Finised Successfully");
                    return userget.ToList();

                }
                else
                {

                    Log.Error($"user Not Found ");
                    throw new ArgumentNullException("Not Found Users");


                }


            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"user Not Found: {ex.Message}");
                throw new DbUpdateException($"datebase Error: {ex.Message}");

            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"date Error: {ex.Message}");

            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");

            }


        }

        public async Task<GetUserDetailDTO> GetUserById(int UserId)
        {
            try
            {

                var user = await _IUserRepository.GetUserById(UserId);

                if (user != null)
                {

                    var GetUserDetailDTO = new GetUserDetailDTO()
                    {
                        UserId = user.UserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = user.Gender,
                        Phone = user.Phone,
                        Email = user.Email,
                        BirthDate = (DateTime)user.BirthDate,
                        CreationDate = user.CreationDate,
                        ModifiedDate = user.ModifiedDate,
                        ImageProfile = user.ImageProfile,
                        userType = user.UserType,
                        IsِActive = user.IsِActive,
                    };
                    if (string.IsNullOrEmpty(GetUserDetailDTO.ImageProfile))
                    {
                        GetUserDetailDTO.ImageProfile = "https://www.shutterstock.com/image-vector/concept-blogging-golden-blog-word-260nw-755744683.jpg";
                    }
                  
                    Log.Information("User Is Reached");
                    Log.Debug($"Debugging GetUserById Has been Finised Successfully With User ID  = {user.UserId}");

                    return GetUserDetailDTO;

                }
                else
                {
                    Log.Error($"user Not Found ");
                    throw new ArgumentNullException("User", "Not Found User");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"user Not Found: {ex.Message}");
                throw new DbUpdateException($"datebase Error: {ex.Message}");

            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"date Error: {ex.Message}");

            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");

            }
        }

        public async Task<string> CreateUser(CreateUserDTO Inpute)
        {
            try {
                Log.Information("Create New User");

                var user = new User() {
                    FirstName = Inpute.FirstName,
                    LastName = Inpute.LastName,
                    Email = Inpute.Email,
                    Phone = Inpute.Phone,
                    BirthDate = Inpute.BirthDate,
                    CreationDate = Inpute.CreationDate,
                    Gender = Inpute.Gender,
                    UserType = Inpute.UserType,
                    IsِActive = Inpute.IsِActive,
                    ImageProfile = Inpute.ImageProfile,
                    ModifiedDate = null,
                    IsApproved=null,
               
                };

                //create  user and return ID
                var UserId = await _IUserRepository.CreateUser(user);
                Log.Information("User Is In Finised");
                Log.Debug($"Debugging AddUser Has been Finised Successfully With User ID  {UserId} ");

                Login login = new Login()
                {

                    UserName = Inpute.Email,
                    Password = Inpute.Password,
                    CreationDate = Inpute.CreationDate,
                    IsِActive = Inpute.IsِActive,
                    IsLoggedIn = false,
                    LastLoginTime = null,
                    
                    UsersId = UserId,
                };
                
                await _ILoginRepository.Login(login);
                Log.Information("Login Is In Finised");
                

                return "Adduser Has been Finised Successfully ";
            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"user Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }



        }


     

        public async Task<string> UpdateUser(UpdateUserDTO Inpute)
        {
            try
            {

                var user = await _IUserRepository.GetUserById(Inpute.UserId);
                var login=await _ILoginRepository.GetLoginById(user.UserId);

                if (user != null)
                {

                    if (!string.IsNullOrEmpty(Inpute.Email)) {
                        user.Email = Inpute.Email;
                        login.UserName= Inpute.Email;

                    }
                    if (!string.IsNullOrEmpty(Inpute.FirstName)) {

                        user.FirstName = Inpute.FirstName;

                    }
                    if(!string.IsNullOrEmpty(Inpute.LastName)) {
                        user.LastName = Inpute.LastName;
                    }
                    if (!string.IsNullOrEmpty(Inpute.Phone)) {
                        user.Phone = Inpute.Phone;

                    }
                    if (!string.IsNullOrEmpty(Inpute.ImageProfile)) {
                        user.ImageProfile = Inpute.ImageProfile;

                    }
                    if (Inpute.BirthDate != null ) {
                        user.BirthDate = (DateTime)Inpute.BirthDate;
                    }
                    if (Inpute.IsِActive !=null) {

                        user.IsِActive = (bool) Inpute.IsِActive;

                    }
                 
                   
                   
                  
                    user.ModifiedDate = Inpute.ModifiedDate;
                 
                    


                    await _IUserRepository.UpdateUser(user);
                    Log.Information("User Is Updated");
                    Log.Debug($"Debugging UpdateUser Has been Finised Successfully With User ID  = {user.UserId}");


                    return "UpdateCustomer Has been Finised Successfully";
                }
                else {
                    Log.Error($"user Not Found ");
                    throw new ArgumentNullException("User", "Not Found User");


                }


            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"user Not Found: {ex.Message}");
                throw new DbUpdateException($"datebase Error: {ex.Message}");

            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"date Error: {ex.Message}");

            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");

            }
        }

        public async Task<string> DeleteUser(int UserId)
        {
            try
            {

                var user = await _IUserRepository.GetUserById(UserId);

                if (user != null)
                {

                    await _IUserRepository.DeleteUser(user);
                    Log.Information("User Is Deleted");
                    Log.Debug($"Debugging DeleteUser Has been Finised Successfully With User ID  = {user.UserId}");

                    return "DeleteCustomer Has been Finised Successfully ";
                }
                else
                {
                    Log.Error($"user Not Found ");
                    throw new ArgumentNullException("User", "Not Found");
                }


            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"user Not Found: {ex.Message}");
                throw new DbUpdateException($"datebase Error: {ex.Message}");

            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"date Error: {ex.Message}");

            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");

            }
        }



        public async Task UpdateUserApprovment(int Id, bool value)
        {
            var User = await _IUserRepository.GetUserById(Id);
            if (User != null)
            {
                User.IsApproved = value;
                await _IUserRepository.UpdateUser(User);
            }
            else
            {
                throw new Exception("User Dose not Exisit");
            }
        }


        public async Task UpdateeUserActivation(int Id, bool value)
        {
            var User = await _IUserRepository.GetUserById(Id);
            if (User != null)
            {
                User.IsِActive = value;
                await _IUserRepository.UpdateUser(User);
            }
            else
            {
                throw new Exception("User Dose not Exisit");
            }
        }

    }
}
