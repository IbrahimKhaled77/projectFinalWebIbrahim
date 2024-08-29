



using ProjectFinalWebIbrahim_core.Dtos.LoginDTO;
using ProjectFinalWebIbrahim_core.Helper;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _ILoginRepository;
        private readonly IUserRepository _IUserRepository;
        public LoginService(ILoginRepository LoginRepository, IUserRepository iUserRepository)
        {
            _ILoginRepository = LoginRepository;
            _IUserRepository = iUserRepository;
        }

        public async Task<string> LoginbyAdmin(CreateLoginDTO Inpute)
        {
            try {
                Log.Information("Starting Login");
                if (string.IsNullOrEmpty(Inpute.UserName))
                    throw new Exception("Email Is Required");

                
                if (string.IsNullOrEmpty(Inpute.Password))
                    throw new Exception("Password Is Required");

                var login = await _ILoginRepository.LoginBoolen(Inpute.UserName,Inpute.Password);
                var admin = await _IUserRepository.IsAdmin((int)login.UsersId);

                if (login != null && admin !=false)
                {
                    //**
                

                    if (!login.IsLoggedIn)
                    {

                        //add token
                        var token = await GenerateUserAccessToken(Inpute.UserName, Inpute.Password);

                       
                            //update login
                            login.IsLoggedIn = true;
                            login.IsActive = true;
                            login.LastLoginTime = DateTime.Now;
                            login.CreationDate = DateTime.Now;

                            await _ILoginRepository.UpdateLogin(login);

                            Log.Information("Login Is In Finised");
                            Log.Debug($"Debugging Login Has been Finised Successfully ");

                            return token;
                       
                       
                    }
                    else {
                        login.IsLoggedIn = false;

                        //update login
                        await _ILoginRepository.UpdateLogin(login);
                        await _ILoginRepository.Logout((int)login.UsersId);
                        Log.Information("User Is not Found");
                        Log.Debug($"Youre Session Has been Closed Please Login in Again");
                        throw new Exception($"Youre Session Has been Closed Please Login in Again");
                        
                    }


                }
                else {
                    Log.Information("Either Email or Password is Incorrect");
                    Log.Debug($"Either Email or Password is Incorrect");
                    throw new Exception($"Either Email or Password is Incorrect");
             

                }



            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");

            }


        }


        public async Task<string> LoginbyUser(CreateLoginDTO Inpute)
        {
            try
            {
                Log.Information("Starting Login");
                if (string.IsNullOrEmpty(Inpute.UserName))
                    throw new Exception("Email Is Required");


                if (string.IsNullOrEmpty(Inpute.Password))
                    throw new Exception("Password Is Required");

                var login = await _ILoginRepository.LoginBoolen(Inpute.UserName, Inpute.Password);
               

                if (login != null)
                {
                    //**


                    if (!login.IsLoggedIn)
                    {

                        //add token
                        var token = await GenerateUserAccessToken(Inpute.UserName, Inpute.Password);


                        //update login
                        login.IsLoggedIn = true;
                        login.IsActive = true;
                        login.LastLoginTime = DateTime.Now;
                        login.CreationDate = DateTime.Now;

                        await _ILoginRepository.UpdateLogin(login);

                        Log.Information("Login Is In Finised");
                        Log.Debug($"Debugging Login Has been Finised Successfully ");

                        return token;


                    }
                    else
                    {
                        login.IsLoggedIn = false;

                        //update login
                        await _ILoginRepository.UpdateLogin(login);
                        await _ILoginRepository.Logout((int)login.UsersId);
                        Log.Information("User Is not Found");
                        Log.Debug($"Youre Session Has been Closed Please Login in Again");
                        throw new Exception($"Youre Session Has been Closed Please Login in Again");
                    }


                }
                else
                {
                    Log.Information("Either Email or Password is Incorrect");
                    Log.Debug($"Either Email or Password is Incorrect");
                    throw new Exception($"Either Email or Password is Incorrect");


                }



            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");

            }


        }


        public async Task<string> Logout(int UserId)
        {

            try {
                Log.Information("Starting Logout");
                var logout = await _ILoginRepository.Logout(UserId);

                if (logout == null)
                {
                    Log.Error($"An error occurred Exception: You Must Login In To Your Account");
                    throw new Exception("You Must Login In To Your Account");

                }
                else { 
                 
                    logout.IsLoggedIn = false;
                    await _ILoginRepository.UpdateLogin(logout);


                    Log.Information("Logout Is In Finised");
                    Log.Debug($"Debugging Login Has been Finised Successfully With finalToken  {logout.UsersId} ");


                    return "logout successful";

                }




            }
            catch (Exception ex) {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");

            }




        }

        public async Task<string> ResetPassword(ResetPasswordDTO Inpute)
        {
            try
            {
                Log.Information("Starting ResetPassword");
                if (Inpute.NewPassword != null && Inpute.UserName != null)
                {

                    var login = await _ILoginRepository.ResetPassword(Inpute.UserName);
                    var user = await _IUserRepository.GetUserById((int)login.UsersId);

                    if (login != null)
                    {
                        login.Password = Inpute.NewPassword;

                     

                       
                      await _ILoginRepository.UpdateLogin(login);

                        Log.Information(" ResetPassword Is In Finised");
                        Log.Debug($"Debugging ResetPassword Has been Finised Successfully With User  {login.UsersId} ");
                        return " Reset Password User Is In Finised";

                    }
                    else {
                        Log.Error($"An error occurred Exception: ERROR NOt Found User to ResetPassword ");
                        throw new Exception("ERROR NOt Found User to ResetPassword ");

                    }

                }
                else {
                    Log.Error($"An error occurred Exception: Please Fill All Information");
                    throw new NotImplementedException("Please Fill All Information");
                }
            }catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");

            }

            

         
        }




        public async Task<string> GenerateUserAccessToken(string UserName , string Password )
        {
            var user = await TryAuthanticate(UserName, Password);
            if (user != null)
            {
                return TokenHelper.GenerateJwtToken(user);
            }
            throw new Exception("Failed To Generate Token");
        }


        public async Task<User> TryAuthanticate(string UserName, string Password)
        {
       
            var userId = await _IUserRepository.GetUserIdAfterLoginOperation(UserName,Password);
            if (userId != 0)
            {
                return await _IUserRepository.GetUserById(userId);
            }
            else
            {
                throw new Exception("Not Same Email Or Password");
            }

        }

    }
}
