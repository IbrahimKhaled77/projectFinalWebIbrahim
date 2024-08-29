

using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Dtos.OrderDTO
{
    public class CreateOrderDTO
    {

       
        public DateTime  DateOrder    { get; set; }
        public string    Title         { get; set; }
        public string    Note      { get; set; }


        public int?      ServeicId       { get; set; }
         public string   CardNumber         { get; set; }
      public string      Code             { get; set; }
       public string     CardHolder     { get; set; }

      public int        Quantity     { get; set; }
        
        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public string city { get; set; }

        public int?    UsersId     { get; set; }
    }
}
