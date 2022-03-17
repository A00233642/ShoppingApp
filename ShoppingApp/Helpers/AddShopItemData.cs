using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using ShoppingApp.Model;
using Xamarin.Forms;

namespace ShoppingApp.Helpers
{
    public class AddShopItemData
    {

        FirebaseClient client;
        public List<ShopItem> ShopItem { get; set; }
        public AddShopItemData()
        {
            client = new FirebaseClient("https://shoppingapp-f4ccb-default-rtdb.firebaseio.com/");
            ShopItem = new List<ShopItem>()
            {
                new ShopItem
                {
                  ProductID = 1,
                  CategoryID = 1,
                  ImageUrl = "",
                  Name = "Women",
                 Decription ="",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 2,
                  CategoryID = 1,
                  ImageUrl = "Logout.png",
                  Name = "Women",
                 Decription ="",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45
            },
                 new ShopItem
                {
                  ProductID = 3,
                  CategoryID = 1,
                  ImageUrl = "Rice",
                  Name = "Women",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Empty",
                 Price = 45
            },
                 new ShopItem
                {
                  ProductID = 4,
                  CategoryID = 1,
                  ImageUrl = "",
                  Name = "Women",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Empty",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 5,
                  CategoryID = 2,
                  ImageUrl = "",
                  Name = "Men",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 6,
                  CategoryID = 2,
                  ImageUrl = "",
                  Name = "Men",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 7,
                  CategoryID = 2,
                  ImageUrl = "",
                  Name = "Men",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 8,
                  CategoryID = 2,
                  ImageUrl = "",
                  Name = "Men",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Empty",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 9,
                  CategoryID = 3,
                  ImageUrl = "",
                  Name = "Children",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Empty",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 10,
                  CategoryID = 3,
                  ImageUrl = "",
                  Name = "Children",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 11,
                  CategoryID = 3,
                  ImageUrl = "",
                  Name = "Children",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 12,
                  CategoryID = 3,
                  ImageUrl = "",
                  Name = "Children",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Empty",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 13,
                  CategoryID = 4,
                  ImageUrl = "",
                  Name = "Children",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45
            },

                 new ShopItem
                {
                  ProductID = 14,
                  CategoryID = 4,
                  ImageUrl = "",
                  Name = "Children",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45

                 },

                 new ShopItem
                {
                  ProductID = 15,
                  CategoryID = 4,
                  ImageUrl = "",
                  Name = "Children",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45

                 },

                 new ShopItem
                {
                  ProductID = 16,
                  CategoryID = 4,
                  ImageUrl = "",
                  Name = "Children",
                 Decription ="Burger and Pizza Breakfast",
                 Rating ="4.9",
                 RatingDetail = "(50 ratings)",
                 HomeSelected =  "Complete",
                 Price = 45

                 },

    };

        }
        public async Task AddShopItemAsync()
        {
            try
            {
                foreach (var item in ShopItem)
                {
                    await client.Child("ShopItems").PostAsync(new ShopItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        Decription = item.Decription,
                        HomeSelected = item.HomeSelected,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Price = item.Price,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail

                    });
                }
            }

            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }
        }


    }

}


