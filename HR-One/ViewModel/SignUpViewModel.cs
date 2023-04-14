using System.Text.RegularExpressions;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HR_One.Database;
using System.Linq;

namespace HR_One.ViewModel.ViewModelSignUp
{
    public class SignUpViewModel:INotifyPropertyChanged
    {
        private SignInDatabase _database;
            
        private string _email;
        private string _userName;
        private string _password;
        private string _confirmPassword;

        public string Email
        {
            get => _email;
            set
            {
                _email= value;
                OnPropertyChanged();
            }
        }
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password= value;
                OnPropertyChanged();
            }
        }
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword= value;
                OnPropertyChanged();
            }
        }


        public event EventHandler RegisterEvent;
        public ICommand RegisterCommand { get; private set; }

        public SignUpViewModel()
        {
            _database= new SignInDatabase();
            _database.CreateDatabase();
            _=_database.CreateTableAsync();
            _=_database.GetRegisterListAsync();
            RegisterCommand = new Command(Validation);
        }

        public void Validation()
        {
            string emailPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            if (string.IsNullOrWhiteSpace(Email) &&
                string.IsNullOrWhiteSpace(UserName) &&
                string.IsNullOrWhiteSpace(Password) &&
                string.IsNullOrWhiteSpace(ConfirmPassword)
                )
            {
                _ = Toast.Make("Please enter values", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Email))
            {
                _ = Toast.Make("Please enter email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (!Regex.IsMatch(Email, emailPattern))
            {
                _ = Toast.Make("Please enter valid email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(UserName))
            {
                _ = Toast.Make("Please enter username", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (UserName.Length < 4)
            {
                _ = Toast.Make("Enter username is too short", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                _ = Toast.Make("Please enter password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (Password.Length < 6)
            {
                _ = Toast.Make("Enter password is too small", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                _ = Toast.Make("Please enter confirm password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (!Password.Equals(ConfirmPassword))
            {
                _ = Toast.Make("Password & confirm password not match", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (_database.SignInDetails.Where(x =>x.Email == Email).Count()>0)
            {
                _=Toast.Make("This email is already registered", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                _database.Email = Email;
                _database.UserName = UserName;
                _database.Password = Password;
                _=_database.InsertAsync();
                _=Toast.Make("User registered successfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                Email = string.Empty;
                UserName = string.Empty;
                Password = string.Empty;
                ConfirmPassword = string.Empty;
                RegisterEvent?.Invoke(this, new EventArgs());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
