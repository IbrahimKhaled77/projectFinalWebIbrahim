
using ProjectFinalWebIbrahim_core.Dtos.UserDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IRepository
{
    //t
    public  interface IUserRepository
    {

        Task<int> CreateUser(User Inpute);

        Task DeleteUser(User Inpute);

        Task UpdateUser(User Inpute);


        Task<User> GetUserById(int UserId);

        Task<List<GetUserAllDTO>> GetUserAll(int UserId);

        Task<bool> IsAdmin(int UserId);
        Task<bool> IsClient(int UserId);
        Task<bool> IsProvider(int UserId);

    }
}
