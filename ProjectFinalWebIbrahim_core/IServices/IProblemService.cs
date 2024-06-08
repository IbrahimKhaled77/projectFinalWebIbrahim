

using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IProblemService
    {
        Task<string> CreateProblem(CreateProblemDTO Inpute);

        Task<string> DeleteProblem(int ProblemId);

        Task<string> UpdateProblem(UpdateProblemDTO Inpute);


        Task<GetProblemDetailDTO> GetProblemById(int ProblemId);

        Task<List<GetProblemAllDTO>> GetProblemAll();

    }
}
