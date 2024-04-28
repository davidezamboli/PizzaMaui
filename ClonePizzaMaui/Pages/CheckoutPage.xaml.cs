namespace ClonePizzaMaui.Pages;

public partial class CheckoutPage : ContentPage
{
	public CheckoutPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing() //await not applied cause they'll be run in parallel
    {
        base.OnAppearing();

        img_Checkout.ScaleTo(1.5);
        text_Checkout.ScaleTo(1);

        await img_Checkout.ScaleTo(0.5);
        await img_Checkout.ScaleTo(1.5);
        await img_Checkout.ScaleTo(0.5);
        await img_Checkout.ScaleTo(1.5);
        await img_Checkout.ScaleTo(0.5);
        await img_Checkout.ScaleTo(1.5);
        await img_Checkout.ScaleTo(1);

        home_Btn.FadeTo(1, length: 500);
        await home_Btn.ScaleTo(1);
    }

    private async void home_Btn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}