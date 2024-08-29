

namespace ProjectFinalWebIbrahim_core.Model.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }

        public string TitleArabic { get; set; }
        public string DescriptionArabic { get; set; }
        public string Description { get; set; }



        public string? imageTitleCategory { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }

    }
}
