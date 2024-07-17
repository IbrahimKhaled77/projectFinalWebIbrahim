

using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.UserDTO
{
    public  class CreateUserDTO
    {
      
        public string   FirstName       { get; set; }
        public string   LastName         { get; set; }
        public string    Email           { get; set; }

        public string? ImageProfile { get; set; }
        public string Password              { get; set; }    
        public string    Phone           { get; set; }

        public Gender    Gender         { get; set; }

        public DateTime  BirthDate       { get; set; }

        public DateTime? CreationDate   { get; set; } = DateTime.Now;

        public UserType UserType { get; set; }
        public bool      IsِActive    { get; set; }


    }
}
