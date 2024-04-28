using ClonePizzaMaui.Model;
using ClonePizzaMaui.Pages;
using ClonePizzaMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ClonePizzaMaui.ViewModel
{
    public partial class HomeViewModel : ObservableObject, IDisposable
    {
        private readonly PizzaService _pizzaService;
        private readonly CartViewModel _cartViewModel;

        public HomeViewModel(PizzaService pizzaService, CartViewModel cartViewModel)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetPopularPizzas());
            _cartViewModel = cartViewModel;
            _cartViewModel.ItemCountUpdated += OnCartItemUpdated;
            _cartViewModel.ItemCountCleared += OnCartItemCleared;
        }

        private void OnCartItemCleared(object? _, EventArgs e) => CartItemCount = 0;

        [ObservableProperty]
        public int _cartItemCount;

        private void OnCartItemUpdated(object? _, int e) => OnCartItemChanged(e);
        
        private void OnCartItemChanged(int count)
        {
            CartItemCount = count;
        }

        public ObservableCollection<Pizza> Pizzas { get; set; }

        [RelayCommand]
        private async Task GoToAllPizzasPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllPizzasViewModel.FromSearch)] = fromSearch
            };

            await Shell.Current.GoToAsync(nameof(AllPizzasPage), animate: true, parameters);
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

        public void Dispose()
        {
            if(_cartViewModel is not null)
            {
                _cartViewModel.ItemCountUpdated -= OnCartItemUpdated;
                _cartViewModel.ItemCountCleared -= OnCartItemCleared;
            }
        }
    }
}
