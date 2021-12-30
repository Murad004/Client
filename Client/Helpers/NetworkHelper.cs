using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Helpers
{
    public class NetworkHelper
    {
        TcpClient TcpClient;
        IPEndPoint endPoint;
        BinaryWriter BinaryWriter;
        byte[] buffer;

        public void Start()
        {
            endPoint = new IPEndPoint(IPAddress.Parse(EndPointHelper.IP), EndPointHelper.PORT);


            try
            {
                TcpClient.Connect(endPoint);
                if (TcpClient.Connected)
                {
                    Task.Run(() =>
                    {
                        var stream = TcpClient.GetStream();
                        BinaryWriter = new BinaryWriter(stream);
                        BinaryWriter.Write(buffer);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }

}
