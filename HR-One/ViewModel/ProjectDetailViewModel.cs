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
        private MessageDetail _selectedMessage;
        private int _id;
        private bool _isLoading;
        private bool _isVisible;
        private string _messageCount;
        private bool _emptyView;
       
        
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
        public MessageDetail SelectedMessage
        {
            get => _selectedMessage;
            set
            {
                _selectedMessage = value;
                OnPropertyChanged();
            }
        }
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();    
            }
        }
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
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
        public bool EmptyView
        {
            get => _emptyView;
            set
            {
                _emptyView = value;
                OnPropertyChanged();
            }
        }


        public event EventHandler<ErrorResult> GetMessageEvent;
        public event EventHandler<MessageDetail> EditEvent;
        public event EventHandler<ErrorResult> DeleteMessageEvent;
        public event EventHandler<MessageDetail> ShowAlertEvent;
      
        
        
        public ICommand EditCommand { get;private set; }
        public ICommand DeleteCommand { get; private set; }
       
              
        public ProjectDetailViewModel()
        {
            _getEmployeeMessageModel=new GetEmployeeMessageModel();
            _deleteEmployeeMessageModel = new DeleteMessageModel();
            EditCommand = new Command<MessageDetail>(EditDetails);
            DeleteCommand = new Command<MessageDetail>(ShowAlert);
        }
         
        public void ShowAlert(MessageDetail messageDetail)
        {
            Id=messageDetail.Id;
            ShowAlertEvent?.Invoke(this,messageDetail);
        }


        public async Task DeleteMessageAsync()
        {
            _deleteEmployeeMessageModel.Id =Id;
            var result = await _deleteEmployeeMessageModel.DeleteMessageAsync();
            DeleteMessageEvent?.Invoke(this, result);
        }
       
        
        public void EditDetails(MessageDetail messageDetail)
        {
            EditEvent?.Invoke(this,messageDetail);
        }



        public async Task GetMessageListAsync()
        {
            IsLoading = true;
            _getEmployeeMessageModel.Id = ProjectDetail.Id;          
            var result=await _getEmployeeMessageModel.GetEmployeeMessageDetailsAsync();
            MessageDetails =_getEmployeeMessageModel.MessageDetails.ToObservableCollection();         
            MessageCountMethod();           
            GetMessageEvent?.Invoke(this, result);
            IsLoading = false;
        }


        public void MessageCountMethod()
        {
            var count = MessageDetails.Count();
            if(count == 0)
            {
                MessageCount = string.Empty;
               // EmptyView = true;
               // IsVisible=false;
            }
            else if (count == 1)
            {
                MessageCount = count + " Message";
               // EmptyView = false;
               // IsVisible=true;
            }
            else
            {
                MessageCount = count + " Messages";
               // EmptyView = false;
               // IsVisible = true;
            }


        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
