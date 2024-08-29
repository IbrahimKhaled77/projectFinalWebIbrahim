

namespace ProjectFinalWebIbrahim_core.Dtos.ProblemDTO
{
    public class CreateProblemDTO
    {
    
        public string               Title            { get; set; }
        public string   ?        Purpose         { get; set; }
        public string   ?         Description   { get; set; }
            

        public int?             UserId           { get; set; }
    }
}
