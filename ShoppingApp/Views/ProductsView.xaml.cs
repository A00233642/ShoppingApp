using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ShoppingApp.Views
{
    public partial class ProductsView : ContentPage
    {
        public ProductsView()
        {
            InitializeComponent();
        }

       async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
          await  Navigation.PopModalAsync();
        }
    }
}
