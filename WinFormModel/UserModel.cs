using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinFormModel
{
    public class UserModel : INotifyPropertyChanged
    {
        private int _id;
        private string _userName = "";
        private int _age;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id
        {
            get => _id;
            set
            {
                if (_id == value) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName == value) return;
                _userName = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age == value) return;
                _age = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
