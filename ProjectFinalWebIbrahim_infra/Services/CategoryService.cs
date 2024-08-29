

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


        public async Task<List<GetCategoryAllDTO>> GetCategoryAll()
        {
            return await _ICategoryRepository.GetCategoryAll();


        }

        public async Task<GetCategoryAllDTO> GetCategoryById(int CategoryId)
        {

            try
            {

                Log.Information("Category Is strating GetCategoryById");

                var Category = await _ICategoryRepository.GetCategoryById(CategoryId);

                if (Category != null)
                {
                

                    var Categors = new GetCategoryAllDTO()
                    {
                        CategoryId = Category.CategoryId,
                        CreationDate = Category.CreationDate,
                        Description = Category.Description,
                        imageTitleCategory = Category.imageTitleCategory,
                        ModifiedDate = Category.ModifiedDate,
                        Title = Category.Title,
                        TitleArabic = Category.TitleArabic,
                        DescriptionArabic = Category.DescriptionArabic,
                        IsActive = Category.IsActive,
                    };

                   // if (string.IsNullOrEmpty(Categors.imageTitleCategory))
                   // {
                     //   Categors.imageTitleCategory = "https://www.shutterstock.com/image-vector/concept-blogging-golden-blog-word-260nw-755744683.jpg";
                   // }
                   // else {
                     //   Categors.imageTitleCategory = $"https://localhost:44305/Images/Category/{Category.imageTitleCategory}";
                    
                  //  }
                    Log.Information("Category Is GetCategoryById");
                    Log.Debug($"Debugging Get Category By Id Has been Finised Successfully With Category ID  = {Category.CategoryId}");

                    return Categors;

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


        public async Task<string> CreateCategory(CreateCategoryDTO Inpute)
        {
            
            try {

                Log.Information("Order Is strating CreateCategory");

                var Categor = new Category();

                Categor.Title = Inpute.titlecategory;
                Categor.Description = Inpute.description;
                Categor.TitleArabic = Inpute.titlecategoryArabic;
                Categor.DescriptionArabic = Inpute.descriptionArabic;
                Categor.CreationDate = DateTime.Now;
                Categor.imageTitleCategory = Inpute.imageTitleCategory;
                Categor.ModifiedDate = null;
                Categor.IsActive = true;

             int   CategoryId = await _ICategoryRepository.CreateCategory(Categor);

                var a = await _ICategoryRepository.GetCategoryById(CategoryId);

                if (string.IsNullOrEmpty(a.imageTitleCategory))
                {
                    Categor.imageTitleCategory = "https://www.shutterstock.com/image-vector/concept-blogging-golden-blog-word-260nw-755744683.jpg";
                }
                else
                {
                    Categor.imageTitleCategory = $"https://localhost:44305/Images/Category/{Inpute.imageTitleCategory}";

                }


                if (Categor !=null) {

                    await _ICategoryRepository.UpdateCategory(Categor);

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


        public async Task<string> UpdateCategory(UpdateCategoryDTO Inpute)
        {
            try
            {

                Log.Information("Category Is strating UpdateCategory");

                var Category = await _ICategoryRepository.GetCategoryById(Inpute.CategoryId);

                if (Category != null)
                {

                  
                        Category.IsActive = true;
                        Category.imageTitleCategory = Inpute.imageTitleCategory;
                       if (!string.IsNullOrEmpty(Inpute.imageTitleCategory)) {

                       Category.imageTitleCategory = Inpute.imageTitleCategory;
                    }
                    if (!string.IsNullOrEmpty(Inpute.Description))
                    {
                        Category.Description = Inpute.Description;
                    }
                    if (!string.IsNullOrEmpty(Inpute.TitleArabic))
                    {
                        Category.TitleArabic = Inpute.TitleArabic;
                    }
                    if (!string.IsNullOrEmpty(Inpute.DescriptionArabic))
                    {
                        Category.DescriptionArabic = Inpute.DescriptionArabic;
                    }
                 
                    Category.ModifiedDate = DateTime.Now;
                    



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


        public async Task UpdateCategoryActivation(int Id, bool value)
        {
            var Category = await _ICategoryRepository.GetCategoryById(Id);
            if (Category != null)
            {
                Category.IsActive = value;
                await _ICategoryRepository.UpdateCategory(Category);
            }
            else
            {
                throw new Exception("Category Dose not Exisit");
            }
        }



    }
}
