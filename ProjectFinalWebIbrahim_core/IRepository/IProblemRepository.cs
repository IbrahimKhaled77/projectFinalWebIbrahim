using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IRepository
{
   

    public interface IProblemRepository
    {

        Task<GetProblemDetailDTO> GetProblemById(int ProblemId);

        Task<List<GetProblemAllDTO>> GetProblemAll();

        Task<Problem> GetProblemByIdServ(int ProblemId);
        Task CreateProblem(Problem Inpute);

        Task UpdateProblem(Problem Inpute);
        Task DeleteProblem(Problem Inpute);





    }
}
