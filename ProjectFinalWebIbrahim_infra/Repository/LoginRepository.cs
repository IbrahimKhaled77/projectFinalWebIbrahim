

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_infra.Repository
{
    public class LoginRepository : ILoginRepository
    {

        private readonly ProjectWebFinalDbContext _context;
        public LoginRepository(ProjectWebFinalDbContext context)
        {
            _context = context;

        }

        //Exception
        public async Task<Login> LoginBoolen(string  emial,string password)
        {
          var login = await _context.Login.SingleOrDefaultAsync(x=>x.UserName.Equals(emial) && x.Password.Equals(password));
            if (login != null)
            {
                return login;
            }
            else
            {

                throw new NotImplementedException("This method LoginBoolen is not implemented for non-empty inputs");
            }
        }
        public async Task UpdateLogin(Login login)
        {
            _context.Login.Update(login);
            await _context.SaveChangesAsync();
        }

        //ADDLogin
        public async Task Login(Login login)
        {
            _context.Login.Add(login);
            await _context.SaveChangesAsync();
        }

        public async Task<Login> Logout(int UserId)
        {
           var logout= await _context.Login.FirstOrDefaultAsync(x=>x.IsLoggedIn==true && x.UsersId==UserId);

            return logout;
        }
    
        public async Task<Login> ResetPassword(string Email)
        {

            var  User= await _context.Login.Where(x=>x.UserName==Email).FirstOrDefaultAsync();

            if (User != null)
            {
                return User;
            }
            else { 
            
            throw new NotImplementedException("This method ResetPassword is not implemented for non-empty inputs");
            }

            
            

           
        }
    }
}
/*
    public async Task<Login> LoginGetById(int UserId)
    {
        return await _context.Login.FirstOrDefaultAsync(x => x.IsLoggedIn == true && x.UsersId == UserId);

    }*/