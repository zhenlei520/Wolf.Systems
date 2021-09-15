using Wolf.Systems.Enumerations.SeedWork;

namespace Wolf.Systems.UnitTest.Enumerations
{
    public class OrderStatus : Enumeration
    {
        public static OrderStatus AwaitPay = new OrderStatus(1, "AwaitPay");

        public static OrderStatus PaymentSuccess = new OrderStatus(2, "PaymentSuccess");

        public static OrderStatus PaymentFail = new OrderStatus(3, "PaymentFail");

        public OrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}
