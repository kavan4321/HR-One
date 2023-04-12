using CommunityToolkit.Maui.Alerts;
using HR_One.ViewModel.ViewModelEmployee;

namespace HR_One.View;

public partial class EmployeeScreen : ContentPage
{
	private EmployeeViewModel _employeeViewModel;
	public EmployeeScreen()
	{
		InitializeComponent();
		_employeeViewModel=(EmployeeViewModel)BindingContext;
		_=GetEmployeeListAsync();
        _employeeViewModel.GetEventHandler += GetEventHandler;
        _employeeViewModel.SelectionEvent += SelectionEvent;
	}

    private void SelectionEvent(object sender, HttpModel.EmployeeDetail e)
    {
		Navigation.PushAsync(new EmployeeDetailScreen(_employeeViewModel.ItemSelected));
    }

    private async Task GetEmployeeListAsync()
	{
		await _employeeViewModel.GetEmployeeListAsync();
	}
    private void GetEventHandler(object sender, Table.ErrorResult e)
    {
		if (!e.IsSuccess)
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}