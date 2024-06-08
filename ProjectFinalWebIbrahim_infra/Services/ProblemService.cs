

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using ProjectFinalWebIbrahim_infra.Repository;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class ProblemService : IProblemService
    {
        private readonly IProblemRepository _IProblemRepository;
        private readonly IUserRepository _IUserRepository;
        public ProblemService(IProblemRepository IProblemRepository, IUserRepository iUserRepository)
        {

            _IProblemRepository = IProblemRepository;
            _IUserRepository = iUserRepository; 
        }

        //client
        public  async Task<string> CreateProblem(CreateProblemDTO Inpute)
        {
            try
            {
               


                var Problem = new Problem
                {

                    
                    ModifiedDate=null,
                    OrderId = Inpute.OrderId,
                    Title = Inpute.Title,
                    Purpose = Inpute.Purpose,
                    IsِActive = Inpute.IsِActive,
                    CreationDate = DateTime.UtcNow,
                    Description = Inpute.Description,
                  

                };

                if (Problem != null)
                {

                    await _IProblemRepository.CreateProblem(Problem);

                    return "AddProblem Has been Finised Successfully ";
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


        //admin
        public async Task<string> DeleteProblem(int ProblemId)
        {
            try
            {

                var Problem = await _IProblemRepository.GetProblemByIdServ(ProblemId);

                if (Problem != null)
                {

                    await _IProblemRepository.DeleteProblem(Problem);

                    return "DeleteProblem success";

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



        //admin
        public async Task<List<GetProblemAllDTO>> GetProblemAll()
        {
            return await _IProblemRepository.GetProblemAll();
        }

        //admin
        public async Task<GetProblemDetailDTO> GetProblemById(int ProblemId)
        {
            return await _IProblemRepository.GetProblemById(ProblemId);
        }

        //not found 
        public async Task<string> UpdateProblem(UpdateProblemDTO Inpute)
        {
            try
            {



                var Problem = await _IProblemRepository.GetProblemByIdServ(Inpute.ProblemId);

                if (Problem != null)
                {
                    Problem.Purpose = Inpute.Purpose;
                    Problem.Description = Inpute.Description;
                    Problem.Title = Inpute.Title;
                    Problem.ModifiedDate = Inpute.ModifiedDate;
                    Problem.IsِActive = Inpute.IsِActive;



                    await _IProblemRepository.UpdateProblem(Problem);

                    return "UpdateProblem success";

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
    }
}

/*
 * 
 *  try
            {

                var Problem = await _IProblemRepository.GetProblemById(ProblemId);

                if (Problem != null)
                {


                    var ProblemDt = new GetProblemDetailDTO()
                    {
                        ProblemId = Problem.ProblemId,
                        CreationDate = Problem.CreationDate,
                        Description = Problem.Description,
                        Purpose = Problem.Purpose,
                        OrderId= Problem.OrderId,
                        ModifiedDate = Problem.ModifiedDate,
                        Title = Problem.Title,
                        IsِActive = Problem.IsِActive,
                    };

                    return ProblemDt;

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
 * */


/*
 * 
 * 
 *  try
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
 * */