


using ProjectFinalWebIbrahim_core.Dtos.LoginDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;

using ProjectFinalWebIbrahim_infra.Repository;

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

                        return "login is true";
                    }
                    else {
                        login.IsLoggedIn = false;

                        //update login
                        await _ILoginRepository.UpdateLogin(login);

                        return "Youre Session Has been Closed Please Login in Again";
                    }


                }
                else {

                    return "Either Email or Password is Incorrect";

                }



            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");

            }


        }

        public async Task<string> Logout(int UserId)
        {

            try {

                var logout = await _ILoginRepository.Logout(UserId);

                if (logout == null)
                {

                    throw new Exception("You Must Login In To Your Account");

                }
                else { 
                 
                    logout.IsLoggedIn = false;
                    await _ILoginRepository.UpdateLogin(logout);

                    return "logout successful";

                }




            }
            catch (Exception ex) {

                throw new Exception($"Exception: {ex.Message}");

            }




        }

        public async Task<string> ResetPassword(ResetPasswordDTO Inpute)
        {
            try
            {

                if (Inpute.NewPassword != null && Inpute.UserName != null)
                {

                    var user = await _ILoginRepository.ResetPassword(Inpute.UserName);

                    if (user != null)
                    {
                        user.Password = Inpute.NewPassword;

                        //note**
                      //  await Updateuser();
                      await _ILoginRepository.UpdateLogin(user);

                             return " Reset Password User Is In Finised";

                    }
                    else {

                        throw new Exception("ERROR NOt Found User to ResetPassword ");

                    }

                }
                else {

                    throw new NotImplementedException("Please Fill All Information");
                }
            }catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");

            }

            

         
        }
    }
}
