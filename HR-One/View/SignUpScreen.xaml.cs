using HR_One.ViewModel.ViewModelSignUp;

namespace HR_One.View;

public partial class SignUpScreen : ContentPage
{
	private SignUpViewModel _signUpViewModel;
	public SignUpScreen()
	{
		InitializeComponent();
		_signUpViewModel=(SignUpViewModel)BindingContext;
        _signUpViewModel.RegisterEvent += RegisterEvent;
	}

    private void RegisterEvent(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		Navigation.PopAsync();
    }
}