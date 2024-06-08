

namespace ProjectFinalWebIbrahim_core.Model.Entity
{
    public class Login
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool IsLoggedIn { get; set; }
        public DateTime? CreationDate { get; set; }


        public bool IsِActive { get; set; }
        public int? UsersId { get; set; }


    }
}
