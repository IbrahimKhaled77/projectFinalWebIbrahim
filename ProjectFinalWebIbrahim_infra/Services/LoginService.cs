


using Org.BouncyCastle.Asn1.X509;
using ProjectFinalWebIbrahim_core.Dtos.LoginDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;

using ProjectFinalWebIbrahim_infra.Repository;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _ILoginRepository;
        public LoginService(ILoginRepository LoginRepository)
        {
            _ILoginRepository = LoginRepository;

        }

        public async Task<string> Login(CreateLoginDTO Inpute)
        {
            try {
                Log.Information("Starting Login");
                if (string.IsNullOrEmpty(Inpute.UserName))
                    throw new Exception("Email Is Required");

                
                if (string.IsNullOrEmpty(Inpute.Password))
                    throw new Exception("Password Is Required");

                var login = await _ILoginRepository.LoginBoolen(Inpute.UserName,Inpute.Password);

                if (login != null)
                {
                    //**
                

                    if (!login.IsLoggedIn)
                    {

                        //add token
                        //update login
                        login.IsLoggedIn = true;
                        login.LastLoginTime = DateTime.Now;
                        await _ILoginRepository.UpdateLogin(login);

                        Log.Information("Login Is In Finised");
                        Log.Debug($"Debugging Login Has been Finised Successfully ");

                        return "login is Successfully";
                    }
                    else {
                        login.IsLoggedIn = false;

                        //update login
                        await _ILoginRepository.UpdateLogin(login);
                        Log.Information("User Is not Found");
                        Log.Debug($"Youre Session Has been Closed Please Login in Again");
                        return "Youre Session Has been Closed Please Login in Again";
                    }


                }
                else {
                    Log.Information("Either Email or Password is Incorrect");
                    Log.Debug($"Either Email or Password is Incorrect");
                    return "Either Email or Password is Incorrect";

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

                    var user = await _ILoginRepository.ResetPassword(Inpute.UserName);

                    if (user != null)
                    {
                        user.Password = Inpute.NewPassword;

                        //note**
                      //  await Updateuser();
                      await _ILoginRepository.UpdateLogin(user);

                        Log.Information(" ResetPassword Is In Finised");
                        Log.Debug($"Debugging ResetPassword Has been Finised Successfully With User  {user.UsersId} ");
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
    }
}
