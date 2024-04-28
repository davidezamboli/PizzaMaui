#if IOS
using UIKit;
#endif

using ClonePizzaMaui.ViewModel;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;

namespace ClonePizzaMaui.Pages;

public partial class DetailPage : ContentPage
{
	private readonly DetailViewModel _detailViewModel;
	public DetailPage(DetailViewModel detailViewModel)
	{
		InitializeComponent();
		_detailViewModel = detailViewModel;
		BindingContext = _detailViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

#if IOS
		// margin of safe area
		var bottom = UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;
		borderCart.Margin = new Thickness(-1, 0, -1, (bottom + 1) * -1);
#endif
	}

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        Behaviors.Add(new StatusBarBehavior
        {
            StatusBarColor = Colors.DarkSeaGreen,
            StatusBarStyle = StatusBarStyle.LightContent
        });
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        Behaviors.Add(new StatusBarBehavior
        {
            StatusBarColor = Colors.White,
            StatusBarStyle = StatusBarStyle.DarkContent
        });
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..", animate: true);
    }
}