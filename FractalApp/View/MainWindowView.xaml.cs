using System.Windows;
using FractalApp.ViewModel;

namespace FractalApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        MainWindowViewModel ViewModel = new MainWindowViewModel();
        public MainWindowView()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
        }
    }
}
