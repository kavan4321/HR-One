using CommunityToolkit.Maui.Alerts;
using HR_One.ViewModel.ViewModelAdd;

namespace HR_One.View;

public partial class AddMessageScreen : ContentPage
{
	private AddMessageViewModel _addMessageViewModel;
	public AddMessageScreen()
	{
		InitializeComponent();
		_addMessageViewModel=(AddMessageViewModel)BindingContext;
        _addMessageViewModel.AddEvent += AddEvent;
	}

    private void AddEvent(object sender, Table.ErrorResult e)
    {
        if(e.IsSuccess)
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
		else
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}