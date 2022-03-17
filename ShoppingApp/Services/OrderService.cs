using System;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using ShoppingApp.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShoppingApp.Services
{
    public class OrderService
    {
        FirebaseClient client;
        public OrderService()
        {

            client = new FirebaseClient("https://shoppingapp-f4ccb-default-rtdb.firebaseio.com/");

        }
        public async Task<string> PlaceOrderAsync()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<CartItem>().ToList();

            var orderId = Guid.NewGuid().ToString();
            var uname = Preferences.Get("Username", "Guest");

            decimal totalCost = 0;

            foreach (var item in data)
            {
                OrderDetails od = new OrderDetails()
                {
                    // OrderId = orderId,
                    OrderId = orderId,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductID = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                };

                totalCost += item.Price * item.Quantity;
                await client.Child("OrderDetails").PostAsync(od);
            }

            await client.Child("Orders").PostAsync(
                new Order()
                {
                    OrderId = orderId,
                    Username = uname,
                    TotalCost = totalCost
                });

            return orderId;
        }
    }
}
