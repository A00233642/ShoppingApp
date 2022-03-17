using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ShoppingApp.Model;
using Xamarin.Forms;

namespace ShoppingApp.Views
{
    public partial class ProductsView : ContentPage
    {
        public ProductsView()
        {
            InitializeComponent();
            CultureInfo myCurrency = new CultureInfo("yo-NG");
            CultureInfo.DefaultThreadCurrentCulture = myCurrency;
        }

       async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
          await  Navigation.PopModalAsync();
        }

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var category = e.CurrentSelection.FirstOrDefault() as Category;
            if (category == null)
                return;

            await Navigation.PushModalAsync(new CategoryView(category));

            ((CollectionView)sender).SelectedItem = null;


        }

    }
}
