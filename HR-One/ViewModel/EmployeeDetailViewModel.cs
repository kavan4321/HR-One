
using CommunityToolkit.Maui.Core.Extensions;
using HR_One.HttpModel;
using HR_One.Model;
using HR_One.Table;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HR_One.ViewModel.ViewModelEmployeeDetail
{
    public class EmployeeDetailViewModel:INotifyPropertyChanged
    {
        private GetEmployeeProjectModel _employeeProjectModel;
        
        
        private EmployeeDetail _employeeDetail;
        private string _genderImage;
        private ObservableCollection<EmployeeProjectDetail> _employeeProjectDetails;
        private bool _isLoading;


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
        public ObservableCollection<EmployeeProjectDetail> EmployeeProjectDetails
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



        public event EventHandler<ErrorResult> GetEmployeeProjectEvent;
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
