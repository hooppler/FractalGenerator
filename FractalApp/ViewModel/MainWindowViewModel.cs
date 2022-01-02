// Author: Aleksandar Stojimirovic
// E-mail: stojimirovic@yahoo.com
// Mob:    +381 60 087 2516
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using FractalApp.Model;
using System.Windows.Input;
using FractalApp.View;
using System.Threading.Tasks;

namespace FractalApp.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private ImageDrawer drw = new ImageDrawer(500, 500);
        private BitmapImage imgMndb;

        private ICommand buttonScalePlusCommand;
        private ICommand buttonScaleMinusCommand;
        private ICommand buttonLeftCommand;
        private ICommand buttonRightCommand;
        private ICommand buttonUpCommand;
        private ICommand buttonDownCommand;
        private ICommand btnFileQuitCommand;
        private ICommand btnViewResetCommand;
        private ICommand btnHelpAboutCommand;
        public double Scale 
        { 
            get { return drw.Scale ; }
            set
            {
                drw.Scale = value;
                OnPropertyChanged("imgMandelbrot");
            } 
        }
        public double Xoffset 
        {
            get { return drw.Xoffset; } 
            set
            {
                drw.Xoffset = value;
                OnPropertyChanged("imgMandelbrot");
            }
        }
        public double Yoffset
        {
            get { return drw.Yoffset; }
            set
            {
                drw.Yoffset = value;
                OnPropertyChanged("imgMandelbrot");
            }
        }

        public double DScale { get; set; }

        public BitmapImage imgMandelbrot
        {
            get
            {
                //return Convert(drw.DrawBlackWhite());
                return Convert(drw.DrawGray());
                //return Convert(drw.DrawColor());

                //Task task = new Task(() => 
                //{
                //        GenerateFractalImage();
                //});
                //task.Start();
                //
                //return imgMndb;
            }
        }

        public MainWindowViewModel()
        {
            SetDefaultValues();
            imgMndb = new BitmapImage();
        }

        public BitmapImage Convert(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();

            return bi;
        }

        public ICommand ButtonScalePlusCommand
        {
            get { return buttonScalePlusCommand ?? (buttonScalePlusCommand = new RelayCommand(param => ButtonScalePlusCommandExecute(param))); }
        }

        public ICommand ButtonScaleMinusCommand
        {
            get { return buttonScaleMinusCommand ?? (buttonScaleMinusCommand = new RelayCommand(param => ButtonScaleMinusCommandExecute(param))); }
        }

        public ICommand ButtonLeftCommand
        {
            get { return buttonLeftCommand ?? (buttonLeftCommand = new RelayCommand(param => ButtonLeftCommandExecute(param))); }
        }

        public ICommand ButtonRightCommand
        {
            get { return buttonRightCommand ?? (buttonRightCommand = new RelayCommand(param => ButtonRightCommandExecute(param))); }
        }

        public ICommand ButtonUpCommand
        {
            get { return buttonUpCommand ?? (buttonUpCommand = new RelayCommand(param => ButtonUpCommandExecute(param))); }
        }

        public ICommand ButtonDownCommand
        {
            get { return buttonDownCommand ?? (buttonDownCommand = new RelayCommand(param => ButtonDownCommandExecute(param))); }
        }

        public ICommand BtnFileQuitCommand
        {
            get { return btnFileQuitCommand ?? (btnFileQuitCommand = new RelayCommand(param => BtnFileQuitCommandExecute(param))); }
        }

        public ICommand BtnViewResetCommand
        {
            get { return btnViewResetCommand ?? (btnViewResetCommand = new RelayCommand(param => BtnViewResetCommandExecute(param))); }
        }

        public ICommand BtnHelpAboutCommand
        {
            get { return btnHelpAboutCommand ?? (btnHelpAboutCommand = new RelayCommand(param => BtnHelpAboutCommandExecute(param))); }
        }

        public void ButtonScalePlusCommandExecute(object param)
        {
            drw.Scale -= DScale;
            OnPropertyChanged("imgMandelbrot");
            OnPropertyChanged("Scale");
        }

        public void ButtonScaleMinusCommandExecute(object param)
        {
            drw.Scale += DScale;
            OnPropertyChanged("imgMandelbrot");
            OnPropertyChanged("Scale");
        }

        public void ButtonLeftCommandExecute(object param)
        {
            drw.Xoffset -= 30 * drw.Scale;
            OnPropertyChanged("imgMandelbrot");
        }

        public void ButtonRightCommandExecute(object param)
        {
            drw.Xoffset += 30 * drw.Scale;
            OnPropertyChanged("imgMandelbrot");
        }

        public void ButtonUpCommandExecute(object param)
        {
            drw.Yoffset -= 30 * drw.Scale;
            OnPropertyChanged("imgMandelbrot");
        }

        public void ButtonDownCommandExecute(object param)
        {
            drw.Yoffset += 30 * drw.Scale;
            OnPropertyChanged("imgMandelbrot");
        }

        public void BtnFileQuitCommandExecute(object param)
        {
            var mainWindowView = (MainWindowView)param;
            //mainWindowView.Close();
            var loadWin = new LoadingWindowView();
            loadWin.Owner = mainWindowView;
            loadWin.Show();
        }

        public void BtnViewResetCommandExecute(object param)
        {
            SetDefaultValues();
            OnPropertyChanged("imgMandelbrot");
            OnPropertyChanged("Scale");
            OnPropertyChanged("Xoffset");
            OnPropertyChanged("Yoffset");
            OnPropertyChanged("DScale");
        }
        private void SetDefaultValues()
        {
            drw.Scale = 0.01;
            drw.Xoffset = -2.5;
            drw.Yoffset = -2;
            DScale = 0.001;
        }

        public void BtnHelpAboutCommandExecute(object param)
        {
            var helpWin = new AboutWindowView();
            helpWin.ShowDialog();
        }

        private void GenerateFractalImage()
        {
            imgMndb = Convert(drw.DrawGray());
            OnPropertyChanged("imgMandelbrot");
        }
    }
}

