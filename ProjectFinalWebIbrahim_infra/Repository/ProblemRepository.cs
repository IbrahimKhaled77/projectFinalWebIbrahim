

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Repository
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly ProjectWebFinalDbContext _context;
        public ProblemRepository(ProjectWebFinalDbContext context)
        {
            _context = context;

        }


        public async Task<List<GetProblemAllDTO>> GetProblemAll()
        {

            try
            {
                Log.Information("Problem Is strating GetProblemAll");

                var Problems = from p in _context.Problem
                               join x in _context.User
                               on p.UserId equals x.UserId
                               where p.IsActive == true
                               select new GetProblemAllDTO
                               {
                                   UserId = p.UserId,
                                   ProblemId = p.ProblemId,
                                   Title = p.Title,
                                   Purpose = p.Purpose,
                                   isActive = p.IsActive,
                                   CreationDate = p.CreationDate,
                                   ModifiedDate=p.ModifiedDate,

                               };


                var Problem = await Problems.ToListAsync();

                if (Problem != null)
                {

                    Log.Information("Problem Is Geted");
                    Log.Debug($"Debugging Get Problem By Id Has been Finised Successfully");

                    return Problem;
                }
                else
                {
                    Log.Error($"Problem Not Found");
                    throw new ArgumentNullException("Problem", "Not Found Problem");

                }
            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Problem Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }



        }

        public async Task<Problem> GetProblemByIdServ(int ProblemId)
        {

            var Problem = await _context.Problem.FindAsync(ProblemId);

            return Problem;


        }

        public async Task<GetProblemDetailDTO> GetProblemById(int ProblemId)
        {

            try
            {
                Log.Information("Problem Is strating GetProblemById");

                var Problem = from p in _context.Problem
                              where p.ProblemId == ProblemId
                              join o in _context.User
                              on p.UserId equals o.UserId
                              select new GetProblemDetailDTO
                              {


                                  ProblemId = p.ProblemId,
                                  CreationDate = p.CreationDate,
                                  Description = p.Description,
                                  Purpose = p.Purpose,
                                  UserId = p.UserId,
                                  TitleOrder = p.Title,
                                  ModifiedDate = p.ModifiedDate,
                                  Title = p.Title,
                                  IsActive = p.IsActive,
                                  

                              };

                var qu = await Problem.FirstOrDefaultAsync();
                if (qu != null)
                {
                    Log.Information("Problem Is Geted");
                    Log.Debug($"Debugging Get Problem By Id Has been Finised Successfully With Problem ID  = {qu.ProblemId}");

                    return qu;
                }
                else
                {
                    Log.Error($"Problem Not Found");
                    throw new ArgumentNullException("Problem", "Not Found Problem");

                }
            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Problem Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }

        }
        public async Task CreateProblem(Problem Inpute)
        {
            _context.Problem.Add(Inpute);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProblem(Problem Inpute)
        {
            _context.Problem.Update(Inpute);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProblem(Problem Inpute)
        {
            _context.Problem.Remove(Inpute);
            await _context.SaveChangesAsync();
        }



 
    }
}
