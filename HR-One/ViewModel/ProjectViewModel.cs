
using CommunityToolkit.Maui.Core.Extensions;
using HR_One.HttpModel;
using HR_One.Model;
using HR_One.Table;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel.ViewModelProject
{
    public class ProjectViewModel:INotifyPropertyChanged
    {

        private GetProjectModel _getProjectModel;

        private ObservableCollection<ProjectDetail> _projectDetails;
        private ProjectDetail _itemSelected;
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
        public ProjectDetail ItemSelected
        {
            get=> _itemSelected; 
            set
            {
                _itemSelected=value;
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
        public event EventHandler<ProjectDetail> SelectionEvent;

        public ICommand SelectionCommand { get;private set; }
        public ProjectViewModel()
        {
            _getProjectModel = new GetProjectModel();
            SelectionCommand = new Command(SelectionChange);
        }

        public void SelectionChange()
        {
            SelectionEvent?.Invoke(this, ItemSelected);
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
