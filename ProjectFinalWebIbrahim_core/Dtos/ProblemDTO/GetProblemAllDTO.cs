

namespace ProjectFinalWebIbrahim_core.Dtos.ProblemDTO
{
    public class GetProblemAllDTO
    {
        public int ProblemId { get; set; }
        public string Title { get; set; }
        public string Purpose { get; set; }

        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public bool isActive { get; set; }
        public int? UserId { get; set; }

  

  

    }
}
