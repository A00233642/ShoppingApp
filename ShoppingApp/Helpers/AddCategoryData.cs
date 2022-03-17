using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using ShoppingApp.Model;
using Xamarin.Forms;
 
namespace ShoppingApp.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }

        FirebaseClient client;

        public AddCategoryData()
        {

            client = new FirebaseClient("https://shoppingapp-f4ccb-default-rtdb.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryID = 1,
                    CategoryName = "Women",
                    CategoryPoster = "Main",
                    ImageUrl = ""

                },

                new Category()
                {
                    CategoryID = 2,
                    CategoryName = "Men",
                    CategoryPoster = "Main",
                    ImageUrl = ""


                },

            new Category()
            {
                CategoryID = 3,
                    CategoryName = "Children",
                    CategoryPoster = "Main",
                    ImageUrl = ""
            },

            new Category()
            {
                CategoryID = 4,
                    CategoryName = "Electronics",
                    CategoryPoster = "Main",
                    ImageUrl = ""
            },

            new Category()
            {
                CategoryID = 5,
                    CategoryName = "Kitchen",
                    CategoryPoster = "Main",
                    ImageUrl = ""
            },

            new Category()
            {
                CategoryID = 6,
                    CategoryName = "Furniture",
                    CategoryPoster = "Main",
                    ImageUrl = ""
            },

           // new Category()
          //  {
          //      CategoryID = 1,
            //        CategoryName = "Burger",
              //      CategoryPoster = "MainBurger",
                //    ImageUrl = "Buns.png"
            //},


            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl,
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
