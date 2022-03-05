using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ShoppingApp.Model;
using ShoppingApp.Services;
using ShoppingApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShoppingApp.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private string _UserName;
        public string UserName
        {
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }

            get
            {
                return _UserName;
            }
        }

        private string _UserCartItemsCount;
        public string UserCartItemsCount
        {
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }

            get
            {
                return _UserCartItemsCount;
            }
        }


        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<ShopItem> LatestItems { get; set; }

        public Command ViewCartCommand { get; set; }

        public Command LogoutCommand { get; set; }

        public ProductsViewModel()
        {
            var uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
                UserName = "Guest";
            else
                UserName = uname;

            var UserCartItemsCount = new CartItemService().GetUserCartCount();

            //   UserCartItemsCount = new CarItemService().GetUserCartCount();

            Categories = new ObservableCollection<Category>();
            LatestItems = new ObservableCollection<ShopItem>();

            ViewCartCommand = new Command(async () => await ViewCartAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());

            GetCategories();
            GetLatestItems();
        }

        private async Task LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());

        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async void GetLatestItems()
        {
            var data = await new ShopItemService().GetLatestShopItemsAsync();
            LatestItems.Clear();
            foreach (var item in data)
            {
                LatestItems.Add(item);
            }

        }

        private async void GetCategories()
        {
            var data = await new CategoryDataService().GetCategoryAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }
    }
}
