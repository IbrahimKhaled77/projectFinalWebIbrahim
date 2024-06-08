

namespace ProjectFinalWebIbrahim_core.Helper.Enums
{
    public class SystemEnums
    {

        public enum UserType2
        {
            Clien = 3,
            Admin = 1,
            Provider = 2,
        }

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

        public enum PaymentMethod
        {
            CreditCard,
            PayPal ,
            Cash ,
        }

        public enum QuantityUnitType
        {
            Kilogram = 0,
            Gram = 1,
            Liter = 2,
            Milliliter = 3,
            Meter = 4,
            Centimeter = 4,
            Kilometer = 5,
            Inch = 6,
            Foot = 7,
            Yard = 8,
            Piece = 9,
        }


        public enum Gender
        {
            Male,
            Female
        }
    }
}
