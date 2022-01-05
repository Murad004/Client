using Client.Commands;
using Client.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.MVVM.ViewModel
{
    public class MainViewModel
    {
        #region Props
        public string PathFile { get; set; }
        #endregion
        #region RelayCommand

        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand DisconnectedCommand { get; set; }
        public RelayCommand SelectCommand { get; set; }
        #endregion

        public MainViewModel(MainWindow mainWindow)
        {
            ConnectCommand = new RelayCommand((sender) =>
              {
                  var client = new TcpClient();
                  var ip = IPAddress.Parse(EndPointHelper.IP);
                  var port = EndPointHelper.PORT;
                  var ep = new IPEndPoint(ip, port);
                  try
                  {
                      client.Connect(ep);
                      if (client.Connected)
                      {
                          MessageBox.Show("Connected . . .");
                          var writer = Task.Run(() =>
                          {
                              while (true)
                              {

                                  var stream = client.GetStream();
                                  var bw = new BinaryWriter(stream);


                                  bw.Write(PathFile);
                                  App.Current.Dispatcher.Invoke(() =>
                                  {

                                      bw.Write(mainWindow.UsernameTxtBox.Text);

                                  });


                                  break;
                              };
                          });



                      }
                      else
                      {
                          MessageBox.Show("Client doesnt connected");
                      }
                  }
                  catch (Exception ex)
                  {
                      Console.WriteLine(ex.Message);
                  }
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
                      open.Filter = "Pdf Files (*.txt)|*.pdf|Image Files|*.jpg;*.jpeg;*.png;";
                      open.ShowDialog();

                      if (".pdf".Equals(Path.GetExtension(open.FileName), StringComparison.OrdinalIgnoreCase))
                      {
                          PathFile = open.FileName;


                      }
                      else
                      {
                          PathFile = open.FileName;

                      }

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
