
using ProjectFinalWebIbrahim_core.Dtos.Authantication;
using ProjectFinalWebIbrahim_core.Dtos.UserDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IUserService
    {

     
        Task<GetUserDetailDTO> GetUserById(int UserId);

        Task<List<GetUserAllDTO>> GetUserAll(int UserId);

        Task<string> CreateUser(CreateUserDTO Inpute);

        Task<string> UpdateUser(UpdateUserDTO Inpute);
        Task<string> DeleteUser(int UserId);


        Task UpdateUserApprovment(int Id, bool value);

        Task UpdateeUserActivation(int Id, bool value);


    }
}
