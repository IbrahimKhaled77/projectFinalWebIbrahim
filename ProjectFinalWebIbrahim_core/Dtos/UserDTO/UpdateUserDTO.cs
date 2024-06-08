
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.UserDTO
{
    public class UpdateUserDTO
    {

        public int      UserId                  { get; set; }
        public string   FirstName           { get; set; }
        public string   LastName            { get; set; }
        public string   Email           { get; set; }
        public string   Phone           { get; set; }

        public string?  ImageProfile            { get; set; }
        public DateTime  BirthDate          { get; set; }


        public DateTime?    ModifiedDate        { get; set; }= DateTime.Now;

        public bool          IsِActive           { get; set; }

    }
}
