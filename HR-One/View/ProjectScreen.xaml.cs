using CommunityToolkit.Maui.Alerts;
using HR_One.ViewModel.ViewModelProject;

namespace HR_One.View;

public partial class ProjectScreen : ContentPage
{
	private ProjectViewModel _projectViewModel;
	public ProjectScreen()
	{
		InitializeComponent();
		_projectViewModel=(ProjectViewModel)BindingContext;
		_=GetProjectListAsync();
        _projectViewModel.GetEventHandler += GetEventHandler;
	}


	private async Task GetProjectListAsync()
	{
		await _projectViewModel.GetProjectListAsync();
	}
    private void GetEventHandler(object sender, Table.ErrorResult e)
    {
       if(!e.IsSuccess)
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}