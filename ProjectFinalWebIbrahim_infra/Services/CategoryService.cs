

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _ICategoryRepository;
        public CategoryService(ICategoryRepository ICategoryRepository) {

            _ICategoryRepository= ICategoryRepository;
        }

        //admin
        public async Task<string> CreateCategory(CreateCategoryDTO Inpute)
        {
            
            try {

                var Categor = new Category {

                    Title = Inpute.Title,
                    Description = Inpute.Description,
                    CreationDate = Inpute.CreationDate,
                    imageTitleCategory = Inpute.imageTitleCategory,
                    ModifiedDate = null,
                    IsِActive = Inpute.IsِActive,
                
                };

                if (Categor !=null) {

                    await _ICategoryRepository.CreateCategory(Categor);

                    return "AddCategory Has been Finised Successfully ";
                }
                else {

                    throw new ArgumentNullException("Category", "Not Found Category");

                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }

        //admin
        public async Task<string> DeleteCategory(int CategoryId)
        {
            try {

                var Category = await _ICategoryRepository.GetCategoryById(CategoryId);

                if (Category != null)
                {
                   
                    await _ICategoryRepository.DeleteCategory(Category);

                    return "DeleteCategory success";
                    
                }
                else {

                    throw new ArgumentNullException("Category", "Not Found Category");

                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }

        //Users all
        public async Task<List<GetCategoryAllDTO>> GetCategoryAll()
        {
          return await _ICategoryRepository.GetCategoryAll();


        }

        //not QA
        public async Task<GetCategoryAllDTO> GetCategoryById(int CategoryId)
        {

            try {

                var Category = await _ICategoryRepository.GetCategoryById(CategoryId);

                if (Category !=null) {


                    var Categor=new GetCategoryAllDTO() { 
                            CategoryId=Category.CategoryId,
                            CreationDate=Category.CreationDate,
                            Description=Category.Description,
                            imageTitleCategory=Category.imageTitleCategory,
                            ModifiedDate=Category.ModifiedDate,
                            Title=Category.Title,
                            IsِActive = Category.IsِActive,
                    };

                    return Categor;

                } 
                else {

                    throw new ArgumentNullException("Category", "Not Found Category");

                }


            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }


        }

        //admin
        public async Task<string> UpdateCategory(UpdateCategoryDTO Inpute)
        {
            try {



                var Category = await _ICategoryRepository.GetCategoryById(Inpute.CategoryId);

                if (Category != null)
                {
                    Category.imageTitleCategory = Inpute.imageTitleCategory;
                    Category.Description = Inpute.Description;
                    Category.Title = Inpute.Title;
                    Category.ModifiedDate = DateTime.UtcNow;
                    Category.IsِActive = Inpute.IsِActive;



                    await _ICategoryRepository.UpdateCategory(Category);

                    return "UpdateCategory success";

                }
                else
                {

                    throw new ArgumentNullException("Category", "Not Found Category");

                }



            }
            catch (ArgumentNullException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception: {ex.Message}");
            }
        }
    }
}
