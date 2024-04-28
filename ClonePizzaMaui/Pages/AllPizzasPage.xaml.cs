using ClonePizzaMaui.ViewModel;

namespace ClonePizzaMaui.Pages;

public partial class AllPizzasPage : ContentPage
{
	private readonly AllPizzasViewModel _allPizzaViewModel;
	public AllPizzasPage(AllPizzasViewModel allPizzasViewModel)
	{
		InitializeComponent();
		_allPizzaViewModel = allPizzasViewModel;
		BindingContext = _allPizzaViewModel;	
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		if(_allPizzaViewModel.FromSearch)
		{
			await Task.Delay(100);
			searchBar.Focus();
		}
    }
    // sender: object that generated the event
    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		if(!string.IsNullOrWhiteSpace(e.OldTextValue) && string.IsNullOrWhiteSpace(e.NewTextValue))
		{
			_allPizzaViewModel.SearchPizzasCommand.Execute(null);
		}
    }
}