using HR_One.HttpModel;
using HR_One.ViewModel.ViewModelProjectDetail;

namespace HR_One.View;

public partial class ProjectDetailScreen : ContentPage
{
	private ProjectDetailViewModel _projectDetailViewModel;
	public ProjectDetailScreen(ProjectDetail projectDetail)
	{
		InitializeComponent();
		_projectDetailViewModel=(ProjectDetailViewModel)BindingContext;
		_projectDetailViewModel.ProjectDetail = projectDetail;

	}
}