using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FitnessClub2.ViewModel
{
    abstract class BaseViewModel<T> : DependencyObject, INotifyPropertyChanged where T : BaseViewModel<T>, new()
    {
        private static T _instance = new T();
        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

