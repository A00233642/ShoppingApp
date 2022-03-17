using System;
using System.Collections.Generic;
using ShoppingApp.ViewModels;
using ShoppingApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace ShoppingApp.Views
{
    public partial class CategoryView : ContentPage
    {
        CategoryViewModel cvm;
        public CategoryView(Category category)
        {
            InitializeComponent();
            cvm = new CategoryViewModel(category);
            this.BindingContext = cvm;
        }

       async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as ShopItem;
            if (selectedProduct == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailsView(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
