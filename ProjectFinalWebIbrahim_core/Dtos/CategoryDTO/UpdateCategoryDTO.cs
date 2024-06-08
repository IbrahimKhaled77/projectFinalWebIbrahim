

namespace ProjectFinalWebIbrahim_core.Dtos.CategoryDTO
{
    public class UpdateCategoryDTO
    {

        public int   CategoryId      { get; set; }
        public string  Title           { get; set; }
        public string   Description     { get; set; }

        public string? imageTitleCategory   { get; set; }
        
        public DateTime? ModifiedDate { get; set; }= DateTime.Now;

        public bool IsِActive { get; set; }

    }
}
