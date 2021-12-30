using Client.Commands;
using Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.MVVM.ViewModel
{
    public class MainViewModel
    {
        #region HelperClassesObject
        NetworkHelper NetworkHelper = new NetworkHelper();

        #endregion
        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand DisconnectedCommand { get; set; }
        public RelayCommand SelectCommand { get; set; }

        public MainViewModel(MainWindow mainWindow)
        {
            ConnectCommand = new RelayCommand((sender) =>
              {
                  
              });
            DisconnectedCommand = new RelayCommand((sender) =>
              {
                  
              });
            SelectCommand = new RelayCommand((sender) =>
              {
                  try
                  {
                      var open = new Microsoft.Win32.OpenFileDialog();

                      open.Multiselect = false;
                      open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                      open.ShowDialog();

                      //mainWindow.image1.Source = new BitmapImage(new Uri(open.FileName));
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
              });
        }
    }
}
