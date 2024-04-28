using ClonePizzaMaui.Model;
using ClonePizzaMaui.Pages;
using ClonePizzaMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ClonePizzaMaui.ViewModel
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllPizzasViewModel : ObservableObject
    {
        private readonly PizzaService _pizzaService;

        public AllPizzasViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetAllPizzas().OrderBy(pizza => pizza.Name).ToList());
        }

        public ObservableCollection<Pizza> Pizzas { get; set; }

        [ObservableProperty]
        private bool _fromSearch;
        // need to get this from the previous page
        // so we'll get it from the shell navigation query string
        //-> when we come from search : search functionality 

        [ObservableProperty]
        private bool searching;

        [RelayCommand]
        private async Task SearchPizzas(string searchTerm)
        {
            // search functionality
            Pizzas.Clear();
            Searching = true;
            await Task.Delay(1000);

            var pizzas = await _pizzaService.SearchPizzas(searchTerm);
            foreach(var pizza in pizzas)
            {
                Pizzas.Add(pizza);
            }
            Searching = false;
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
