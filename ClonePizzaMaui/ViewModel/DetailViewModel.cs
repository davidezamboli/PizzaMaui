using ClonePizzaMaui.Model;
using ClonePizzaMaui.Pages;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClonePizzaMaui.ViewModel
{
    [QueryProperty(nameof(Pizza), nameof(Pizza))]   
    public partial class DetailViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;

        public DetailViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;
            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;
        }

        [ObservableProperty]
        private Pizza _pizza;

        private void OnCartItemRemoved(object? _, Pizza pizza) => OnCartItemChanged(pizza, 0);

        private void OnCartCleared(object? _, EventArgs e) => Pizza.CartQuantity = 0;
        private void OnCartItemUpdated(object? _, Pizza pizza) => OnCartItemChanged(pizza, pizza.CartQuantity);

        private void OnCartItemChanged(Pizza pizza, int quantity)
        {
            if(pizza.Name == Pizza.Name)
            {
                Pizza.CartQuantity = quantity;
            }
        }

        [RelayCommand]
        private void AddToCart()
        {
            Pizza.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
        }

        [RelayCommand]
        private void RemoveFromCart()
        {
            if(Pizza.CartQuantity > 0)
            {
                Pizza.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
                _cartViewModel.UpdateCartItemQuantity(Pizza);
            }
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if (Pizza.CartQuantity > 0)
            {
                //go to CartPage
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                // display a toast message (CommunityToolkit)
                await Toast.Make("Please select the quantity using the (+) button", ToastDuration.Short)
                    .Show();
            }
        }

        public void Dispose()
        {
            if(_cartViewModel is not null)
            {
                _cartViewModel.CartCleared -= OnCartCleared;
                _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
                _cartViewModel.CartItemUpdated -= OnCartItemUpdated;
            }
        }
    }
}
