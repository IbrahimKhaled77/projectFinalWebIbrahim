

namespace ProjectFinalWebIbrahim_core.Dtos.CategoryDTO
{
    public class GetCategoryAllDTO
    {

        public int   CategoryId  { get; set; }
        public string   Title     { get; set; }
        public string  Description     { get; set; }

        public string? imageTitleCategory {get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool IsِActive { get; set; }

    }
}
