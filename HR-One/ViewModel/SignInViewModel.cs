
using CommunityToolkit.Maui.Alerts;
using HR_One.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace HR_One.ViewModel.ViewModelSignIn
{
    public class SignInViewModel: INotifyPropertyChanged
    {

        private SignInDatabase _database;
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public event EventHandler LoginEvent;
        public ICommand LoginCommand { get; private set; }
        public SignInViewModel()
        {
            _database = new SignInDatabase();
            _database.CreateDatabase();
            _=_database.CreateTableAsync();
            _=_database.GetRegisterListAsync();
            LoginCommand = new Command(Validation);
        }

        public void Validation()
        {
            string emailPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            if (string.IsNullOrWhiteSpace(Email) &&
                string.IsNullOrWhiteSpace(Password))
            {
                Toast.Make("Please enter values", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Email))
            {
                Toast.Make("Please enter email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (!Regex.IsMatch(Email, emailPattern))
            {
                Toast.Make("Enter email is not valid", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                Toast.Make("Please enter password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (Password.Length < 6)
            {
                Toast.Make("Enter password is small", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                var databaseData = _database.SignInDetails.Where(x => x.Email == Email && x.Password == Password).ToList();                
                if (databaseData.Count>0) 
                {
                    var userName = databaseData.FirstOrDefault().UserName;
                    Toast.Make("Welcome " + userName, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                    LoginEvent?.Invoke(this, new EventArgs());
                }
                else
                {
                    Toast.Make("Invalid username/password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();               
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
