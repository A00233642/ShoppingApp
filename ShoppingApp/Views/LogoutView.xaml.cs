using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ShoppingApp.Views
{
    public partial class LogoutView : ContentPage
    {
        public LogoutView()
        {
            InitializeComponent();
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
