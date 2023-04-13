
using CommunityToolkit.Maui.Alerts;
using HR_One.HttpModel;
using HR_One.Model;
using HR_One.Table;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel.ViewModelEdit
{
    public class EditMessageViewModel:INotifyPropertyChanged
    {
        private EditMessageModel _editMessageModel;

        private MessageDetail _messageDetail;
        public MessageDetail MessageDetail
        {
            get => _messageDetail;
            set
            {
                _messageDetail = value;
                OnPropertyChanged();
            }
        }


        public event EventHandler<ErrorResult> EditEvent;
        public ICommand EditCommand { get;private set; }

        public EditMessageViewModel()
        {
            _editMessageModel = new EditMessageModel();
            EditCommand = new Command(EditDetails);
        }

        public async void EditDetails()
        {
            var title=MessageDetail.Title;
            var body=MessageDetail.Body;

            if(string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(body))
            {
                _=Toast.Make("Please enter title and body",CommunityToolkit.Maui.Core.ToastDuration.Short).Show();    
            }
            else if(string.IsNullOrWhiteSpace(title))
            {
                _=Toast.Make("Please enter title", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(body))
            {
                _ = Toast.Make("Please enter body", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                _editMessageModel.Id = MessageDetail.Id;
                _editMessageModel.ProjectId = MessageDetail.ProjectId;
                _editMessageModel.Title= title;
                _editMessageModel.Body= body;
                _editMessageModel.MessageStutus = MessageDetail.MessageStatus;
                var result=await _editMessageModel.EditMessageAsync();
                EditEvent?.Invoke(this, result);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
