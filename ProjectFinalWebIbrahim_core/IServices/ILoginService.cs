

using ProjectFinalWebIbrahim_core.Dtos.LoginDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface ILoginService
    {
    

        Task<string> Login(CreateLoginDTO Inpute);

        Task<string> Logout(int UserId);

        Task<string> ResetPassword(ResetPasswordDTO Inpute);
    }
}
