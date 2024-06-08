
using ProjectFinalWebIbrahim_core.Dtos.UserDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IUserService
    {
        Task<string> CreateUser(CreateUserDTO Inpute);

        Task<string> DeleteUser(int UserId);

        Task<string> UpdateUser(UpdateUserDTO Inpute);


        Task<GetUserDetailDTO> GetUserById(int UserId);

        Task<List<GetUserAllDTO>> GetUserAll(int UserId);


    }
}
