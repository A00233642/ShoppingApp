using System;
using System.Collections.ObjectModel;
using ShoppingApp.Model;
using ShoppingApp.Services;

namespace ShoppingApp.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedCategory;
            }
        }

        public ObservableCollection<ShopItem> ShopItemsByCategory { get; set; }

        private int _TotalShopItems;
        public int TotalShopItems
        {
            set
            {
                _TotalShopItems = value;
                OnPropertyChanged();
            }

            get
            {
                return _TotalShopItems;
            }
        }

        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            ShopItemsByCategory = new ObservableCollection<ShopItem>();
            GetShopItems(category.CategoryID);

        }

        private async void GetShopItems(int categoryID)
        {
            var data = await new ShopItemService().GetShopItemsByCategoryAsync(categoryID);
            ShopItemsByCategory.Clear();
            foreach (var item in data)
            {
                ShopItemsByCategory.Add(item);
            }

            TotalShopItems = ShopItemsByCategory.Count;

        }
    }
}
