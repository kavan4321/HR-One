
using HR_One.HttpModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HR_One.ViewModel.ViewModelProjectDetail
{
    public class ProjectDetailViewModel:INotifyPropertyChanged
    {
        private ProjectDetail _projectDetail;
        public ProjectDetail ProjectDetail
        {
            get => _projectDetail;
            set
            {
                _projectDetail = value;
                OnPropertyChanged();
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
