



using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;

namespace ProjectFinalWebIbrahim_core.IServices
{
    public interface ICategoryService
    {


        Task<GetCategoryAllDTO> GetCategoryById(int CategoryId);

        Task<List<GetCategoryAllDTO>> GetCategoryAll();

        Task<string> CreateCategory(CreateCategoryDTO Inpute);

        Task<string> UpdateCategory(UpdateCategoryDTO Inpute);
        Task<string> DeleteCategory(int CategoryId);





    }
}
