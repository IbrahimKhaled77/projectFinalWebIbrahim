using Microsoft.AspNetCore.Mvc;

namespace projectFinalWebIbrahim.Controllers
{
    public class FileController : ControllerBase
    {



        [HttpPost]
        [Route("[action]")]
        public async Task<string> UploadImageUserProfileAndGetURL(IFormFile file)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images\\User");
            if (file == null || file.Length == 0)
            {
                throw new Exception("Please Enter Valid File");
            }
          
            string newFileURL = Guid.NewGuid().ToString() + "" + file.FileName;
            using (var inputFile = new FileStream(Path.Combine(uploadFolder, newFileURL), FileMode.Create))
            {
                await file.CopyToAsync(inputFile);
            }
            return newFileURL;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<string> UploadImageServicesProfileAndGetURL(IFormFile file)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images\\Service");
            if (file == null || file.Length == 0)
            {
                throw new Exception("Please Enter Valid File");
            }
          
            string newFileURL = Guid.NewGuid().ToString() + "" + file.FileName;
            using (var inputFile = new FileStream(Path.Combine(uploadFolder, newFileURL), FileMode.Create))
            {
                await file.CopyToAsync(inputFile);
            }
            return newFileURL;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<string> UploadImageCategoryProfileAndGetURL(IFormFile file)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images\\Category");
            if (file == null || file.Length == 0)
            {
                throw new Exception("Please Enter Valid File");
            }
          
            string newFileURL = Guid.NewGuid().ToString() + "" + file.FileName;
            using (var inputFile = new FileStream(Path.Combine(uploadFolder, newFileURL), FileMode.Create))
            {
                await file.CopyToAsync(inputFile);
            }
            return newFileURL;
        }



    }
}
