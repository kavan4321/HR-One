
using CommunityToolkit.Maui.Alerts;
using HR_One.Database;
using HR_One.Table;
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



        public event EventHandler<ErrorResult> LoginEvent;
        public ICommand LoginCommand { get; private set; }
      
        
        public SignInViewModel()
        {
            _database = new SignInDatabase();
            _database.CreateDatabase();
            _=_database.CreateTableAsync();
            _=_database.GetRegisterListAsync();
            LoginCommand = new Command(Validation);
        }



        public async void Validation()
        {        
            string emailPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            
            if (string.IsNullOrWhiteSpace(Email) &&
                string.IsNullOrWhiteSpace(Password))
            {
                _ = Toast.Make("Please enter values", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Email))
            {
                _ = Toast.Make("Please enter email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (!Regex.IsMatch(Email, emailPattern))
            {
                _ = Toast.Make("Enter email is not valid", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                _=Toast.Make("Please enter password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (Password.Length < 6)
            {
                _=Toast.Make("Enter password is small", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                _database.Email=Email;
                _database.Password=Password;
                var result =await  _database.GetUserData();
                LoginEvent?.Invoke(this,result);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
