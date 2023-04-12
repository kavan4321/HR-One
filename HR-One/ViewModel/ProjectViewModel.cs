
using CommunityToolkit.Maui.Core.Extensions;
using HR_One.HttpModel;
using HR_One.Model;
using HR_One.Table;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HR_One.ViewModel.ViewModelProject
{
    public class ProjectViewModel:INotifyPropertyChanged
    {

        private GetProjectModel _getProjectModel;

        private ObservableCollection<ProjectDetail> _projectDetails;
        private bool _isLoading;
        public ObservableCollection<ProjectDetail> ProjectDetails
        {
            get => _projectDetails;
            set
            {
                _projectDetails = value;
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
     
        public event EventHandler<ErrorResult> GetEventHandler;
        public ProjectViewModel()
        {
            _getProjectModel = new GetProjectModel();
        }


        public async Task GetProjectListAsync()
        {
            IsLoading=true;
            var result = await _getProjectModel.GetProjectDetailsAsync();
            ProjectDetails = _getProjectModel.ProjectDetails.ToObservableCollection();
            GetEventHandler?.Invoke(this, result);
            IsLoading= false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
