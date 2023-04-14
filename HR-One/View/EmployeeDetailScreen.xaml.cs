using CommunityToolkit.Maui.Alerts;
using HR_One.HttpModel;
using HR_One.ViewModel.ViewModelEmployeeDetail;

namespace HR_One.View;

public partial class EmployeeDetailScreen : ContentPage
{
	private EmployeeDetailViewModel _employeeDetailViewModel;
	public EmployeeDetailScreen(EmployeeDetail employeeDetail)
	{
		InitializeComponent();	
		_employeeDetailViewModel=(EmployeeDetailViewModel)BindingContext;
		_employeeDetailViewModel.EmployeeDetail = employeeDetail;
		_employeeDetailViewModel.ChangeImage();
        _employeeDetailViewModel.GetEmployeeProjectEvent += GetEmployeeProjectEvent;
		_=GetListAsync();	
	}

	private async Task GetListAsync()
	{
		await _employeeDetailViewModel.GetEmployeeProjectListAsync();
	}
    private void GetEmployeeProjectEvent(object sender, Table.ErrorResult e)
    {
		if (!e.IsSuccess)
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }

    private void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		Navigation.PushAsync(new ProjectDetailScreen(_employeeDetailViewModel.SelectedItem));
    }

    private async void EmailTapped(object sender, TappedEventArgs e)
    {
		if (Email.Default.IsComposeSupported)
		{

			string[] recipients = new[] { _employeeDetailViewModel.EmployeeDetail.Email };

            var message = new EmailMessage
			{
				Subject = _employeeDetailViewModel.EmployeeDetail.Designation,
				Body = _employeeDetailViewModel.EmployeeDetail.CompleteAddress,
				To= new List<string> { recipients[0] }
			};
			await Email.Default.ComposeAsync(message);
		}
    }

    private void PhoneNumberTapped(object sender, TappedEventArgs e)
    {
		if (PhoneDialer.Default.IsSupported)
		{
			PhoneDialer.Default.Open(_employeeDetailViewModel.EmployeeDetail.PhoneNumber);
		}
    }
}