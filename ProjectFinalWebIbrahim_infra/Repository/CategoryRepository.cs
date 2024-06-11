

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Context;
using ProjectFinalWebIbrahim_core.Dtos.CategoryDTO;
using ProjectFinalWebIbrahim_core.IRepository;
using ProjectFinalWebIbrahim_core.Model.Entity;
using Serilog;

namespace ProjectFinalWebIbrahim_infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ProjectWebFinalDbContext _context;
        public CategoryRepository(ProjectWebFinalDbContext context) {

            _context=context;

        }


        public async Task<List<GetCategoryAllDTO>> GetCategoryAll()
        {
            try
            {

                Log.Information("Order Is strating GetCategoryAll");

                var Categorys = from x in _context.Categorie
                                orderby x.CreationDate descending
                                select new GetCategoryAllDTO
                                {
                                    CategoryId = x.CategoryId,
                                    Title = x.Title,
                                    Description = x.Description,
                                    imageTitleCategory = x.imageTitleCategory,
                                    ModifiedDate = x.ModifiedDate,
                                    CreationDate = x.CreationDate,
                                    IsِActive = x.IsِActive,
                                };

                var Category = await Categorys.ToListAsync();

                if (Category != null)
                {


                    Log.Information("Category Is CreateCategory");
                    Log.Debug($"Debugging Get Category By Id Has been Finised Successfully");

                    return Category;
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

        public async Task<Category> GetCategoryById(int CategoryId)
        {
            var Category = await _context.Categorie.FindAsync(CategoryId);

            return Category;
        }

        public  async Task CreateCategory(Category Inpute)
        {
             _context.Categorie.Add(Inpute);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category Inpute)
        {
            _context.Categorie.Update(Inpute);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategory(Category Inpute)
        {
            _context.Categorie.Remove(Inpute);
            await _context.SaveChangesAsync();
        }

 

  
    }
}
