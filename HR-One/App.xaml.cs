using HR_One.View;

namespace HR_One;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new DashbordScreen());
	}
}
