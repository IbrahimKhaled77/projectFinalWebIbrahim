
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IRepository
{

    //t
    public interface ICategoryRepository
    {

        Task<Category> GetCategoryById(int CategoryId);

        Task<List<GetCategoryAllDTO>> GetCategoryAll();

        Task CreateCategory(Category Inpute);

        Task UpdateCategory(Category Inpute);
        Task DeleteCategory(Category Inpute);




   


    }
}
