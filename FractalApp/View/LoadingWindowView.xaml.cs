using System.Windows;
using System.Windows.Input;

namespace FractalApp.View
{
    /// <summary>
    /// Interaction logic for LoadingWindowView.xaml
    /// </summary>
    public partial class LoadingWindowView : Window
    {
        public LoadingWindowView()
        {
            InitializeComponent();
            MouseDown += OnLeftMouseDown;
        }

        private void OnLeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
