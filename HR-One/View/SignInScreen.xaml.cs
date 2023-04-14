
using CommunityToolkit.Maui.Alerts;
using HR_One.ViewModel.ViewModelSignIn;

namespace HR_One.View;

public partial class SignInScreen : ContentPage
{
	private SignInViewModel _signInViewModel;
	public SignInScreen()
	{
		InitializeComponent();
		_signInViewModel=(SignInViewModel)BindingContext;
        _signInViewModel.LoginEvent += LoginEvent;
	}

    private void LoginEvent(object sender, Table.ErrorResult e)
    {
        if (e.IsSuccess)
        {           
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            Navigation.PushAsync(new DashbordScreen());
            var firstPage = Navigation.NavigationStack.ElementAtOrDefault(0);
            if (firstPage != null)
            {
                Navigation.RemovePage(firstPage);
            }
        }
        else
        {
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }


    private void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		Navigation.PushAsync(new SignUpScreen());
    }
}