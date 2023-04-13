
using HR_One.Model;
using HR_One.Table;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel.ViewModelAdd
{
    public class AddMessageViewModel:INotifyPropertyChanged
    {
        private AddMessageModel _addMessageModel;
      
        private string _title;
        private string _body;

        public string Title
        {
            get => _title;
            set
            {
                _title= value;
                OnPropertyChanged();
            }
        }
        public string Body
        {
            get => _body;
            set
            {
                _body= value;
                OnPropertyChanged();
            }
        }

        public event EventHandler<ErrorResult> AddEvent;
        public ICommand AddCommand { get;private set; }

        public AddMessageViewModel()
        {
            _addMessageModel= new AddMessageModel();
            AddCommand = new Command(() => { _ = AddDetailsAsync();}) ;
        }

        public async Task AddDetailsAsync()
        {
            _addMessageModel.Title= Title;
            _addMessageModel.Body= Body;
            var result =await _addMessageModel.AddMessageAsync();
            AddEvent?.Invoke(this, result);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
