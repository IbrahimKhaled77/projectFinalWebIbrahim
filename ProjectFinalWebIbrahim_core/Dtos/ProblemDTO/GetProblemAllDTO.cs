

namespace ProjectFinalWebIbrahim_core.Dtos.ProblemDTO
{
    public class GetProblemAllDTO
    {
        public int ProblemId { get; set; }
        public string Title { get; set; }
        public string Purpose { get; set; }

        public bool IsِActive { get; set; }
        public int? OrderId { get; set; }
    }
}
