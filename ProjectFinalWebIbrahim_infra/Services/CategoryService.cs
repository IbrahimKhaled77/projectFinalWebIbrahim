

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.IServices;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _ICategoryRepository;
        public CategoryService(ICategoryRepository ICategoryRepository) {

            _ICategoryRepository= ICategoryRepository;
        }


        //Users all
        public async Task<List<GetCategoryAllDTO>> GetCategoryAll()
        {
            return await _ICategoryRepository.GetCategoryAll();


        }

        //not QA
        public async Task<GetCategoryAllDTO> GetCategoryById(int CategoryId)
        {

            try
            {

                Log.Information("Category Is strating GetCategoryById");

                var Category = await _ICategoryRepository.GetCategoryById(CategoryId);

                if (Category != null)
                {


                    var Categor = new GetCategoryAllDTO()
                    {
                        CategoryId = Category.CategoryId,
                        CreationDate = Category.CreationDate,
                        Description = Category.Description,
                        imageTitleCategory = Category.imageTitleCategory,
                        ModifiedDate = Category.ModifiedDate,
                        Title = Category.Title,
                        IsِActive = Category.IsِActive,
                    };


                    Log.Information("Category Is GetCategoryById");
                    Log.Debug($"Debugging Get Category By Id Has been Finised Successfully With Category ID  = {Category.CategoryId}");

                    return Categor;

                }
                else
                {
                    Log.Error($"Category Not Found");
                    throw new ArgumentNullException("Category", "Not Found Category");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Category Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }


        }

        //admin
        public async Task<string> CreateCategory(CreateCategoryDTO Inpute)
        {
            
            try {

                Log.Information("Order Is strating CreateCategory");

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

                    Log.Information("Category Is CreateCategory");
                    Log.Debug($"Debugging Get Category By Id Has been Finised Successfully With Category ID  = {Categor.CategoryId}");

                    return "AddCategory Has been Finised Successfully ";
                }
                else
                {
                    Log.Error($"Category Not Found");
                    throw new ArgumentNullException("Category", "Not Found Category");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Category Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }
        }

        //admin
        public async Task<string> UpdateCategory(UpdateCategoryDTO Inpute)
        {
            try
            {

                Log.Information("Category Is strating UpdateCategory");

                var Category = await _ICategoryRepository.GetCategoryById(Inpute.CategoryId);

                if (Category != null)
                {
                    Category.imageTitleCategory = Inpute.imageTitleCategory;
                    Category.Description = Inpute.Description;
                    Category.Title = Inpute.Title;
                    Category.ModifiedDate = DateTime.UtcNow;
                    Category.IsِActive = Inpute.IsِActive;



                    await _ICategoryRepository.UpdateCategory(Category);

                    Log.Information("Category Is Updated");
                    Log.Debug($"Debugging Get Category By Id Has been Finised Successfully With Category ID  = {Category.CategoryId}");

                    return "UpdateCategory success";

                }
                else
                {
                    Log.Error($"Category Not Found");
                    throw new ArgumentNullException("Category", "Not Found Category");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Category Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }
        }

        //admin
        public async Task<string> DeleteCategory(int CategoryId)
        {
            try {

                Log.Information("Category Is strating DeleteCategory");

                var Category = await _ICategoryRepository.GetCategoryById(CategoryId);

                if (Category != null)
                {
                   
                    await _ICategoryRepository.DeleteCategory(Category);


                    Log.Information("Category Is DeleteCategory");
                    Log.Debug($"Debugging Get Category By Id Has been Finised Successfully With Category ID  = {Category.CategoryId}");

                    return "DeleteCategory success";
                    
                }
                else
                {
                    Log.Error($"Category Not Found");
                    throw new ArgumentNullException("Category", "Not Found Category");

                }



            }
            catch (ArgumentNullException ex)
            {
                Log.Error($"Category Not Found: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Log.Error($"An error occurred in database: {ex.Message}");
                throw new DbUpdateException($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred Exception: {ex.Message}");
                throw new Exception($"Exception: {ex.Message}");
            }
        }

 

     
    }
}
