
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.Dtos.UserDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectWebFinalDbContext _context;
        public UserRepository(ProjectWebFinalDbContext context) {

            _context = context;
        }



        public async Task<List<GetUserAllDTO>> GetUserAll(int UserId)
        {
            var Provider = await IsProvider(UserId);

            if (Provider)
            {
                var Clien = from x in _context.User
                            where x.UserType == UserType.Clien
                            orderby x.CreationDate descending
                            select new GetUserAllDTO
                            {

                                UserId = x.UserId,
                                Email = x.Email,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                CreationDate = x.CreationDate,
                                Gender = x.Gender,
                                ImageProfile = x.ImageProfile,
                                IsِActive = x.IsِActive,
                                userType = x.UserType,
                                ModifiedDate = x.ModifiedDate,
                            };

                return await Clien.ToListAsync();

            }
            else if (await IsAdmin(UserId))
            {

                var user = from x in _context.User
                           orderby x.CreationDate descending
                           select new GetUserAllDTO
                           {

                               UserId = x.UserId,
                               Email = x.Email,
                               FirstName = x.FirstName,
                               LastName = x.LastName,
                               CreationDate = x.CreationDate,
                               Gender = x.Gender,
                               ImageProfile = x.ImageProfile,
                               IsِActive = x.IsِActive,
                               userType = x.UserType,
                               ModifiedDate = x.ModifiedDate,
                           };


                return await user.ToListAsync();
            }
            else
            {

                var Providers = from x in _context.User
                                where x.UserType == UserType.Provider
                                orderby x.CreationDate descending
                                select new GetUserAllDTO
                                {

                                    UserId = x.UserId,
                                    Email = x.Email,
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    CreationDate = x.CreationDate,
                                    Gender = x.Gender,
                                    ImageProfile = x.ImageProfile,
                                    IsِActive = x.IsِActive,
                                    userType = x.UserType,
                                    ModifiedDate = x.ModifiedDate,
                                };

                return await Providers.ToListAsync();
            }


        }
        public async Task<int> GetUserIdAfterLoginOperation(string email, string password)
        {
            var query = from login in _context.Login
                        where login.UserName == email
                        && login.Password == password
                        select login.UsersId;

            var Id = await query.SingleOrDefaultAsync();
            return  (int)Id;
        }
        public async Task<User> GetUserById(int? UserId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId.Equals(UserId));
            return user;
        }
        public async Task<int> CreateUser(User Inpute)
        {
            _context.User.Add(Inpute);
            await _context.SaveChangesAsync();
            return Inpute.UserId;

        }

        public async Task UpdateUser(User Inpute)
        {

            _context.User.Update(Inpute);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(User Inpute)
        {
            _context.User.Remove(Inpute);
            await _context.SaveChangesAsync();

        }





        public async Task<bool> IsAdmin(int UserId)
        {
            var Admin = await _context.User.AnyAsync( x => x.UserType == UserType.Admin && x.UserId == UserId) ;

            return Admin!;
        }

        public async Task<bool> IsClient(int UserId)
        {
            var Client = await _context.User.AnyAsync(x => x.UserType== UserType.Clien && x.UserId==UserId);

            return Client!;
        }
        public async Task<bool> IsProvider(int UserId)
        {
            var Provider = await _context.User.AnyAsync(x => x.UserType == UserType.Provider && x.UserId == UserId);

            return Provider!;
        }


    }
}
