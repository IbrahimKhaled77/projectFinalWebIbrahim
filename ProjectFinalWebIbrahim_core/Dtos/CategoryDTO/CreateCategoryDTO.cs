

namespace ProjectFinalWebIbrahim_core.Dtos.CategoryDTO
{
    public class CreateCategoryDTO
    {


        public string  Title  { get; set; }
        public string   Description     { get; set; }

        public string? imageTitleCategory  { get; set; }
        public DateTime? CreationDate { get; set; }= DateTime.Now;
       
        public bool IsِActive { get; set; }

    }
}
