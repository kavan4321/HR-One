
using CommunityToolkit.Maui.Core.Extensions;
using HR_One.HttpModel;
using HR_One.Model;
using HR_One.Table;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel.ViewModelEmployee
{
    public class EmployeeViewModel:INotifyPropertyChanged
    {
        private GetEmployeeModel _getEmployeeModel;    
        private ObservableCollection<EmployeeDetail> _employeeDetails;
        private EmployeeDetail _itemSelected;
        private bool _isLoading; 
       
        
        public ObservableCollection<EmployeeDetail> EmployeeDetails
        {
            get=>_employeeDetails;
            set
            {
                _employeeDetails = value;
                OnPropertyChanged();
            }
        }
        public EmployeeDetail ItemSelected
        {
            get => _itemSelected;
            set
            {
                _itemSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoading
        {
            get=> _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        
        public event EventHandler<ErrorResult> GetEventHandler; 
        public event EventHandler<EmployeeDetail> SelectionEvent;
      
        public ICommand SelectionCommand { get;private set; }
       
        public EmployeeViewModel()
        {
            _getEmployeeModel = new GetEmployeeModel();
            SelectionCommand = new Command(SelectionChange);
        }


        public void SelectionChange()
        {
            SelectionEvent?.Invoke(this,ItemSelected);
        }
      
        public async Task GetEmployeeListAsync()
        {
            IsLoading=true;
            var result=await _getEmployeeModel.GetEmployeeDetailsAsync();
            EmployeeDetails=_getEmployeeModel.EmployeeDetails.ToObservableCollection();
            GetEventHandler?.Invoke(this, result);
            IsLoading=false;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
