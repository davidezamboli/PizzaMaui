using ClonePizzaMaui.ViewModel;

namespace ClonePizzaMaui.Pages;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _homeViewModel;
	public HomePage(HomeViewModel homeViewModel)
	{
        InitializeComponent();
        _homeViewModel = homeViewModel;
		BindingContext = _homeViewModel;
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CartPage));
    }
}