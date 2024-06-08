using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;
using System;

namespace ProjectFinalWebIbrahim_core.IRepository
{
    //t
    public interface IProblemRepository
    {
        Task CreateProblem(Problem Inpute);

        Task DeleteProblem(Problem Inpute);

        Task UpdateProblem(Problem Inpute);


        Task<GetProblemDetailDTO> GetProblemById(int ProblemId);

        Task<List<GetProblemAllDTO>> GetProblemAll();

        Task<Problem> GetProblemByIdServ(int ProblemId);
    }
}
