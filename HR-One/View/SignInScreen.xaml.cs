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

    private void LoginEvent(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DashbordScreen());      
       
        var firstPage = Navigation.NavigationStack.ElementAtOrDefault(0);
        if (firstPage != null)
        {
            Navigation.RemovePage(firstPage);
        }
    }

    private void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		Navigation.PushAsync(new SignUpScreen());
    }
}