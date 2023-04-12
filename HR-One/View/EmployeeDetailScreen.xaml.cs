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
}