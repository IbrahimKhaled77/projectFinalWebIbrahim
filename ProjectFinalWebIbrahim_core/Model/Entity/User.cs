

using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Model.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public UserType UserType { get; set; }

        public Gender Gender { get; set; }
       
        public string? ImageProfile { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }


        public bool IsِActive { get; set; }

        public bool? IsApproved { get; set; }

    }
}
