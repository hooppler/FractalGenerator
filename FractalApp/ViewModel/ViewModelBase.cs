// Author: Aleksandar Stojimirovic
// E-mail: stojimirovic@yahoo.com
// Mob:    +381 60 087 2516
using System.ComponentModel;

namespace FractalApp.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
