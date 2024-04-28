using ClonePizzaMaui.Model;
using ClonePizzaMaui.Pages;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ClonePizzaMaui.ViewModel
{
    public partial class CartViewModel() : ObservableObject
    {
        public ObservableCollection<Pizza> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;

        [ObservableProperty]
        private bool _isPlacingOrder;

        public EventHandler<Pizza>? CartItemRemoved;

        public EventHandler? CartCleared;

        public EventHandler<Pizza>? CartItemUpdated;

        public EventHandler<int>? ItemCountUpdated;

        public EventHandler? ItemCountCleared;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        public void UpdateCartItemQuantity(Pizza pizza)
        {
            var existingItem = Items.FirstOrDefault(item => item.Name == pizza.Name);
            if (existingItem is not null)
            {
                existingItem.CartQuantity = pizza.CartQuantity;
            }
        }

        [RelayCommand]
        private void IncrementItemFromCart(Pizza pizza)
        {
            var cartItem = Items.FirstOrDefault(item => item.Name == pizza?.Name);
            if(cartItem is not null)
            {
                cartItem.CartQuantity++;
                UpdateCartItemCommand.Execute(cartItem);
            }
        }

        [RelayCommand] // adding/updating the item to the cart
        public void UpdateCartItem(Pizza pizza)
        {
            var item = Items.FirstOrDefault(i => i.Name == pizza.Name);

            //if item is present
            if(item is not null)
            {
                item.CartQuantity = pizza.CartQuantity; // which will come from the detail page
                int index = Items.IndexOf(item);
                Items[index] = item.Clone();
            }
            else
            {
                //add item
                Items.Add(pizza.Clone());
            }
            RecalculateTotalAmount();
            ItemCountUpdated?.Invoke(this, Items.Sum(item => item.CartQuantity));
        }

        [RelayCommand]
        private async Task RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i =>i.Name == name);
            if(item is not null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                CartItemRemoved?.Invoke(this, item);

                var snackBarOptions = new SnackbarOptions
                {
                    CornerRadius = 22,
                    BackgroundColor = Colors.LightGreen,
                    TextColor = Colors.Red,
                    Font = Microsoft.Maui.Font.SystemFontOfSize(14),
                    ActionButtonTextColor = Colors.SeaGreen,
                    ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(16)
                };

                var snackBar = Snackbar.Make($"'{item.Name}' removed from cart",
                    () =>
                    {
                        Items.Add(item);
                        RecalculateTotalAmount();

                        CartItemUpdated?.Invoke(this, item);
                    }, "Undo", TimeSpan.FromSeconds(3), snackBarOptions);

                await snackBar.Show();
                ItemCountUpdated?.Invoke(this, Items.Sum(item => item.CartQuantity));
            }
        }

        //clear cart
        [RelayCommand]
        private async Task ClearCart()
        {
            if(Items.Any())
            {
                //destructive action => confirmation logic
                if(await Shell.Current.DisplayAlert(
                    "Confirm Clear Cart?",
                    "Do you really want to clear the cart items?",
                    "Yes", "No"))
                {
                    Items.Clear();
                    RecalculateTotalAmount();

                    CartCleared?.Invoke(this, EventArgs.Empty);
                    ItemCountCleared?.Invoke(this, EventArgs.Empty);

                    await Toast.Make("Cart cleared", ToastDuration.Short).Show();
                }
            }
            else
            {
                await Toast.Make("Cart is already empty", ToastDuration.Short).Show();
            }
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            if (Items.Any())
            {
                IsPlacingOrder = true;
                await Task.Delay(2000);

                // go to checkout
                await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);

                IsPlacingOrder = false;
                Items.Clear();
                CartCleared?.Invoke(this, EventArgs.Empty);
                ItemCountCleared?.Invoke(this, EventArgs.Empty);
                RecalculateTotalAmount();
            }
            else
            {
                await Toast.Make("Insert items in the cart to place order", ToastDuration.Short).Show();
            }
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Pizza pizza)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailViewModel.Pizza)] = pizza
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }

        
    }
}
