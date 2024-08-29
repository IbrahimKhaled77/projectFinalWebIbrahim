

namespace ProjectFinalWebIbrahim_core.Helper.Enums
{
    public class SystemEnums
    {


        public enum UserType
        {
           Clien=3,
           Admin=1,
           Provider=2,
        }

        public enum OrderStatus
        {
            Pending,
            Shipped,
            Delivered,
            Cancelled
        }
        public enum QuantityUnitType
        {
            Kilogram = 0,
            Gram = 1,
            Liter = 2,
            Milliliter = 3,
            Meter = 4,
            Centimeter = 5,
            Kilometer = 6,
            Inch = 7,
            Foot = 8,
            Yard = 9,
            Piece = 10,
        }
   
        public enum Gender
        {
            Male=1,
            Female=2,
        }
    }
}
