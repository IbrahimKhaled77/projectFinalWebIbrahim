
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IRepository
{


    public interface ICategoryRepository
    {
        
        Task<Category> GetCategoryById(int? CategoryId);

        Task<List<GetCategoryAllDTO>> GetCategoryAll();

        Task<int> CreateCategory(Category Inpute);

        Task UpdateCategory(Category Inpute);
        Task DeleteCategory(Category Inpute);




   


    }
}
