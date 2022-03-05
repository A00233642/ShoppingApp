using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using ShoppingApp.Model;

namespace ShoppingApp.Services
{
    public class ShopItemService
    {
        FirebaseClient client;
        public ShopItemService()
        {
            client = new FirebaseClient("https://shoppingapp-f4ccb-default-rtdb.firebaseio.com/");
        }

        public async Task<List<ShopItem>> GetShopItemAsync()
        {
            var products = (await client.Child("ShopItems")
                .OnceAsync<ShopItem>())
                .Select(f => new ShopItem
                {
                    CategoryID = f.Object.CategoryID,
                    Decription = f.Object.Decription,
                    HomeSelected = f.Object.HomeSelected,
                    ImageUrl = f.Object.ImageUrl,
                    Name = f.Object.Name,
                    Price = f.Object.Price,
                    ProductID = f.Object.ProductID,
                    Rating = f.Object.Rating,
                    RatingDetail = f.Object.RatingDetail

                }).ToList();
            return products;
        }

        public async Task<ObservableCollection<ShopItem>> GetShopItemsByCategoryAsync(int categoryID)
        {
            var ShopItemsByCayegory = new ObservableCollection<ShopItem>();
            var items = (await GetShopItemAsync()).Where(p => p.CategoryID == categoryID).ToList();
            foreach (var item in items)
            {
                ShopItemsByCayegory.Add(item);
            }

            return ShopItemsByCayegory;
        }

        public async Task<ObservableCollection<ShopItem>> GetLatestShopItemsAsync()
        {
            var lastestShopItems = new ObservableCollection<ShopItem>();
            var items = (await GetShopItemAsync()).OrderByDescending(f => f.Price).Take(3);
            foreach (var item in items)
            {
                lastestShopItems.Add(item);
            }
            return lastestShopItems;
        }
    }
}
