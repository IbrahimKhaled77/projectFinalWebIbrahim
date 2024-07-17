

using ProjectFinalWebIbrahim_core.Dtos.ProblemDTO;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface IProblemService
    {

        Task<GetProblemDetailDTO> GetProblemById(int ProblemId);

        Task<List<GetProblemAllDTO>> GetProblemAll();

        Task<string> CreateProblem(CreateProblemDTO Inpute);


        Task<string> UpdateProblem(UpdateProblemDTO Inpute);
        Task<string> DeleteProblem(int ProblemId);


        Task UpdateProblemActivation(int Id, bool value);



    }
}
