
using HR_One.HttpModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HR_One.ViewModel.ViewModelEmployeeDetail
{
    public class EmployeeDetailViewModel:INotifyPropertyChanged
    {
        private EmployeeDetail _employeeDetail;
        private string _genderImage;
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

        public EmployeeDetailViewModel()
        {
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
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
