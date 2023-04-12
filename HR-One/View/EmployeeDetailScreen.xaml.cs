using HR_One.HttpModel;
using HR_One.ViewModel.ViewModelEmployeeDetail;

namespace HR_One.View;

public partial class EmployeeDetailScreen : ContentPage
{
	private EmployeeDetailViewModel _EmployeeDetailViewModel;
	public EmployeeDetailScreen(EmployeeDetail employeeDetail)
	{
		InitializeComponent();	
		_EmployeeDetailViewModel=(EmployeeDetailViewModel)BindingContext;
		_EmployeeDetailViewModel.EmployeeDetail = employeeDetail;
		_EmployeeDetailViewModel.ChangeImage();
	}
}