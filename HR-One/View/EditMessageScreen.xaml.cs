using CommunityToolkit.Maui.Alerts;
using HR_One.HttpModel;
using HR_One.ViewModel.ViewModelEdit;

namespace HR_One.View;

public partial class EditMessageScreen : ContentPage
{
	private EditMessageViewModel _editMessageViewModel;
	public EditMessageScreen(MessageDetail messageDetail)
	{
		InitializeComponent();
		_editMessageViewModel=(EditMessageViewModel)BindingContext;
		_editMessageViewModel.MessageDetail = messageDetail;
        _editMessageViewModel.EditEvent += EditEvent;
	}

    private void EditEvent(object sender, Table.ErrorResult e)
    {
        if(e.IsSuccess)
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
			Navigation.PopAsync();
		}
		else
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}