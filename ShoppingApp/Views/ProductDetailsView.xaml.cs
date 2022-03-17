using System;
using System.Collections.Generic;
using ShoppingApp.Model;
using ShoppingApp.ViewModels;
using Xamarin.Forms;

namespace ShoppingApp.Views
{
    public partial class ProductDetailsView : ContentPage
    {
        ProductDetailsViewModel pvm;
        public ProductDetailsView(ShopItem shopItem)
        {
            InitializeComponent();
            pvm = new ProductDetailsViewModel(shopItem);
            this.BindingContext = pvm;
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
