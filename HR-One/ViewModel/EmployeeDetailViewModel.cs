
using CommunityToolkit.Maui.Core.Extensions;
using HR_One.HttpModel;
using HR_One.Model;
using HR_One.Table;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel.ViewModelEmployeeDetail
{
    public class EmployeeDetailViewModel:INotifyPropertyChanged
    {
        private GetEmployeeProjectModel _employeeProjectModel;
        
        
        private EmployeeDetail _employeeDetail;
        private string _genderImage;
        private ObservableCollection<ProjectDetail> _employeeProjectDetails;
        private bool _isLoading;
        private ProjectDetail _selectedItem;


        public EmployeeDetail EmployeeDetail
        {
            get => _employeeDetail;
            set
            {
                _employeeDetail = value;
                OnPropertyChanged();
            }
        }
        public string GenderImage
        {
            get => _genderImage;
            set
            {
                _genderImage = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ProjectDetail> EmployeeProjectDetails
        {
            get => _employeeProjectDetails;
            set
            {
                _employeeProjectDetails = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading=value;
                OnPropertyChanged();
            }
        }
        public ProjectDetail SelectedItem
        {
            get=> _selectedItem;
            set
            {
                _selectedItem=value;
                OnPropertyChanged();
            }
        }


        public event EventHandler<ErrorResult> GetEmployeeProjectEvent;
        public event EventHandler<ProjectDetail> SelectionEvent;
        public ICommand SelectionCommand { get;private set; }
        
        
        public EmployeeDetailViewModel()
        {
            _employeeProjectModel = new GetEmployeeProjectModel();
        }
        public void ChangeImage()
        {
            if (EmployeeDetail.Gender == "Male")
            {
                GenderImage = "male_employee";
            }
            else
            {
                GenderImage = "female_employee";
            }
        }
        

        public async Task GetEmployeeProjectListAsync()
        {
            _employeeProjectModel.Id = EmployeeDetail.Id;
            IsLoading = true;
            var result = await _employeeProjectModel.GetEmployeeProjectDetailsAsync();
            EmployeeProjectDetails = _employeeProjectModel.EmployeeProjectDetails.ToObservableCollection();
            GetEmployeeProjectEvent(this, result);
            IsLoading = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
