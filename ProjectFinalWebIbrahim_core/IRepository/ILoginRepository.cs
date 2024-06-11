using ProjectFinalWebIbrahim_core.Model.Entity;


namespace ProjectFinalWebIbrahim_core.IRepository
{
    public interface ILoginRepository
    {

      
        Task Login(Login login);

        Task<Login> Logout(int UserId);

        Task<Login> ResetPassword(string Email);

        Task<Login> LoginBoolen(string Email, string password);

        Task UpdateLogin(Login login);


    }
}
