using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalWebIbrahim_core.Dtos.ProblemDTO
{
    public class UpdateProblemDTO
    {

        public int ProblemId { get; set; }
        public string? Title { get; set; }
        public string? Purpose { get; set; }
        public string? Description { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;


        public bool? IsِActive { get; set; }
        public int? OrderId { get; set; }


    }
}
