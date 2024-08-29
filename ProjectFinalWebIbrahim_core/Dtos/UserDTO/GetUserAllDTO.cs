

using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.UserDTO
{
    public class GetUserAllDTO
    {

        public int          UserId             { get; set; }
        public string       FirstName         { get; set; }
        public string       LastName              { get; set; }
        public string        Email                 { get; set; }
        public Gender        Gender             { get; set; }
        public string?      ImageProfile         { get; set; }

        // public DateTime BirthDate { get; set; }

        public UserType     userType                { get; set; }
        public DateTime?    CreationDate           { get; set; }
        public DateTime?     ModifiedDate               { get; set; }

        public bool isctive { get; set; }


    }
}
