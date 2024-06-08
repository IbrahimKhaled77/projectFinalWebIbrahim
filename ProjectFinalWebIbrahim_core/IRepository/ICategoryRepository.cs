
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.IRepository
{

    //t
    public interface ICategoryRepository
    {
        Task CreateCategory(Category Inpute);

        Task DeleteCategory(Category Inpute);

        Task UpdateCategory(Category Inpute);


        Task<Category> GetCategoryById(int CategoryId);

        Task<List<GetCategoryAllDTO>> GetCategoryAll();


    }
}
