
using CommunityToolkit.Maui.Core.Extensions;
using HR_One.EndPoint;
using HR_One.HttpModel;
using HR_One.Model;
using HR_One.Table;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel.ViewModelProjectDetail
{
    public class ProjectDetailViewModel:INotifyPropertyChanged
    {
        private GetEmployeeMessageModel _getEmployeeMessageModel;
        private DeleteMessageModel _deleteEmployeeMessageModel;

        private ProjectDetail _projectDetail;
        private ObservableCollection<MessageDetail> _messageDetails;
        private string _messageCount; 
        public ProjectDetail ProjectDetail
        {
            get => _projectDetail;
            set
            {
                _projectDetail = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<MessageDetail> MessageDetails
        {
            get => _messageDetails;
            set
            {
                _messageDetails = value;
                OnPropertyChanged();
            }
        }
        public string MessageCount
        {
            get => _messageCount;
            set
            {
                _messageCount = value;
                OnPropertyChanged();
            }
        }



        public event EventHandler<ErrorResult> GetMessageEvent;
        public event EventHandler<MessageDetail> EditEvent;
        public event EventHandler<ErrorResult> DeleteMessageEvent;
        public event EventHandler ShowAlertEvent;
        public ICommand EditCommand { get;private set; }
        public ICommand DeleteCommand { get; private set; }
       
              
        public ProjectDetailViewModel()
        {
            _getEmployeeMessageModel=new GetEmployeeMessageModel();
            _deleteEmployeeMessageModel = new DeleteMessageModel();
            EditCommand = new Command<MessageDetail>(EditDetails);
            DeleteCommand = new Command(ShowAlert);
        }
         
        public void ShowAlert()
        {
            ShowAlertEvent?.Invoke(this,new EventArgs());
        }


        public async Task DeleteMessageAsync()
        {
            _deleteEmployeeMessageModel.Id = ProjectDetail.Id;
            var result = await _deleteEmployeeMessageModel.DeleteMessageAsync();
            DeleteMessageEvent?.Invoke(this, result);
        }
        public void EditDetails(MessageDetail messageDetail)
        {
            EditEvent?.Invoke(this,messageDetail);
        }
        public async Task GetMessageListAsync()
        {
            _getEmployeeMessageModel.Id = ProjectDetail.Id;
            var result=await _getEmployeeMessageModel.GetEmployeeMessageDetailsAsync();
            MessageDetails =_getEmployeeMessageModel.MessageDetails.ToObservableCollection();
            MessageCountMethod();
            GetMessageEvent?.Invoke(this, result);
        }

        public void MessageCountMethod()
        {
            var count = MessageDetails.Count();
            if(count == 0)
            {
                MessageCount = "";
            }
            else if (count == 1)
            {
                MessageCount = count + " Message";
            }
            else
            {
                MessageCount = count + " Messages";
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
