using ProjectFinalWebIbrahim_core.Model.Entity;


namespace ProjectFinalWebIbrahim_core.IRepository
{
    public interface ILoginRepository
    {

        Task UpdateLogin(Login login);
        Task<Login> LoginBoolen(string Email, string password);
        Task Login(Login login);

        Task<Login> Logout(int UserId);

        Task<Login> ResetPassword(string Email);
       



    }
}
