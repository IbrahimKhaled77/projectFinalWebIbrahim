

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_infra.Repository
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly ProjectWebFinalDbContext _context;
        public ProblemRepository(ProjectWebFinalDbContext context)
        {
            _context = context;

        }
        public async Task CreateProblem(Problem Inpute)
        {
            _context.Problem.Add(Inpute);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProblem(Problem Inpute)
        {
            _context.Problem.Remove(Inpute);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetProblemAllDTO>> GetProblemAll()
        {

            try {

                var Problems = from p in _context.Problem
                               join x in _context.Order
                               on p.OrderId equals x.OrderId
                               select new GetProblemAllDTO
                               {
                                   OrderId = p.OrderId,
                                   ProblemId=p.ProblemId,
                                   Title = p.Title, 
                                   Purpose  = p.Purpose,
                                   IsِActive=p.IsِActive,
                                 
                               };


                var Problem = await Problems.ToListAsync();

                if (Problem != null)
                {

                    return Problem;
                }
                else
                {

                    throw new ArgumentNullException("Problem", "Not Found Problem");

                }
            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

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
                var Problem = from p in _context.Problem
                              where p.ProblemId == ProblemId
                              join o in _context.Order
                              on p.OrderId equals o.OrderId
                              select new GetProblemDetailDTO
                              {


                                  ProblemId = p.ProblemId,
                                  CreationDate = p.CreationDate,
                                  Description = p.Description,
                                  Purpose = p.Purpose,
                                  OrderId = p.OrderId,
                                  TitleOrder = p.Title,
                                  ModifiedDate = p.ModifiedDate,
                                  Title = p.Title,
                                  IsِActive = p.IsِActive,

                              };

                var qu = await Problem.LastOrDefaultAsync();
                if (qu != null)
                {

                    return qu;
                }
                else
                {

                    throw new ArgumentNullException("Problem", "Not Found Problem");

                }
            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }

        }

        public async Task UpdateProblem(Problem Inpute)
        {
            _context.Problem.Update(Inpute);
            await _context.SaveChangesAsync();
        }
    }
}
