using System;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApp.Model;
using ShoppingApp.Views;
using Xamarin.Forms;

namespace ShoppingApp.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        private ShopItem _SelectedShopItem;
        public ShopItem SelectedShopItem
        {
            set
            {
                _SelectedShopItem = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedShopItem;
            }
        }

        private int _TotalQuantity;
        public int TotalQuantity
        {
            set
            {
                this._TotalQuantity = value;
                if (this._TotalQuantity < 0)
                    this._TotalQuantity = 0;
                if (this._TotalQuantity > 100)
                    this._TotalQuantity -= 1;
                OnPropertyChanged();
            }

            get
            {
                return _TotalQuantity;
            }
        }

        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomeCommand { get; set; }

        public ProductDetailsViewModel(ShopItem shopItem)
        {
            SelectedShopItem = shopItem;
            TotalQuantity = 0;

            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(async () => await ViewCartAsync());
            HomeCommand = new Command(async () => await GotoHomeAsync());
        }

        private async Task GotoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private void AddToCart()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                CartItem ci = new CartItem()
                {
                    ProductId = SelectedShopItem.ProductID,
                    ProductName = SelectedShopItem.Name,
                    Price = SelectedShopItem.Price,
                    Quantity = TotalQuantity
                };

                var item = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.ProductId == SelectedShopItem.ProductID);
                if (item == null)
                    cn.Insert(ci);
                else
                {
                    item.Quantity += TotalQuantity;
                    cn.Update(item);
                }
                cn.Commit();
                cn.Close();
                Application.Current.MainPage.DisplayAlert("Cart", "SelectedShopItem Added to cart", "OK");
            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }
            finally
            {
                cn.Close();
            }
        }

        private void DecrementOrder()
        {
            TotalQuantity--;
        }

        private void IncrementOrder()
        {
            TotalQuantity++;
        }
    }
}
