using CommunityToolkit.Maui.Alerts;
using HR_One.HttpModel;
using HR_One.ViewModel.ViewModelProjectDetail;

namespace HR_One.View;

public partial class ProjectDetailScreen : ContentPage
{
	private ProjectDetailViewModel _projectDetailViewModel;
	
	public ProjectDetailScreen(ProjectDetail projectDetail)
	{
		InitializeComponent();
		_projectDetailViewModel=(ProjectDetailViewModel)BindingContext;
		_projectDetailViewModel.ProjectDetail = projectDetail;
		_ = GetMessageListAsync();
        EventBinding();

	}

    private void EventBinding()
    {
        _projectDetailViewModel.GetMessageEvent += GetMessageEvent;
        _projectDetailViewModel.EditEvent += EditEvent;
        _projectDetailViewModel.ShowAlertEvent += ShowAlertEvent; ;
        _projectDetailViewModel.DeleteMessageEvent += DeleteMessageEvent;
    }

    private async void ShowAlertEvent(object sender, MessageDetail e)
    {
        bool result = await DisplayAlert("Delete Message", "Are you sure you want to delete this message? ", "Yes", "No");

        if (result == true)
        {
            _ = _projectDetailViewModel.DeleteMessageAsync();
        }
    }

    private async Task GetMessageListAsync()
    {
        await _projectDetailViewModel.GetMessageListAsync();
    }

    private void DeleteMessageEvent(object sender, Table.ErrorResult e)
    {
        if (e.IsSuccess)
        {
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

    private void EditEvent(object sender, MessageDetail e)
    {
		Navigation.PushAsync(new EditMessageScreen(e));
    }

 

    private void GetMessageEvent(object sender, Table.ErrorResult e)
    {
		if (!e.IsSuccess)
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }


    private void NewMessageClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new AddMessageScreen());
    }

   
}