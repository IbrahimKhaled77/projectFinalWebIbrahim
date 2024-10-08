﻿


using ProjectFinalWebIbrahim_core.Dtos.LoginDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface ILoginService
    {

        Task<string> GenerateUserAccessToken(string UserName, string Password);
        Task<User> TryAuthanticate(string UserName, string Password);
        Task<string> LoginbyAdmin(CreateLoginDTO Inpute);

        Task<string> LoginbyUser(CreateLoginDTO Inpute);
        Task<string> Logout(int UserId);

        Task<string> ResetPassword(ResetPasswordDTO Inpute);


    }
}
