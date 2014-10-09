using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System.Management;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Time_Server
{
    class Program
    {
        private static Process process = new Process();
        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _clientSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            string remoteMachine = "Nombre de Servidor"; 
            Console.Title ="Servidor";
            SetupServer();
            Console.ReadLine();
        }

        private static void SetupServer()
        {
            Console.WriteLine("Preparando Servidor...");
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 600));
            _serverSocket.Listen(5);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }

        private static void AcceptCallBack(IAsyncResult AR)
        {
            Socket socket = _serverSocket.EndAccept(AR);
            _clientSockets.Add(socket);
            Console.WriteLine("Cliente Conectado");
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
            
        }

        private static void ReceiveCallBack(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] dataBuf = new byte[received];
            Array.Copy(_buffer, dataBuf, received);

            string text = Encoding.ASCII.GetString(dataBuf);
            Console.WriteLine("El Texto Recibido Fue: " + text);

            string response = string.Empty;

            if (text.ToLower() == "dame la hora")
            {
                //response = "Petición Inválida";
                response = DateTime.Now.ToLongTimeString();
                byte[] data = Encoding.ASCII.GetBytes(response);
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);
            }
            else if (text.ToLower() == "dir")
            {

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd";
                process.StartInfo.Arguments = "/C" + text;
                process.StartInfo.WorkingDirectory = @"C:\";
                String strOutput = String.Empty;
                process.Start();
                strOutput = process.StandardOutput.ReadToEnd();
                System.Console.WriteLine(strOutput);
                var javaScriptSerializerVar = new System.Web.Script.Serialization.JavaScriptSerializer();
                String jSON = javaScriptSerializerVar.Serialize(strOutput);
                System.Console.WriteLine(jSON);

                byte[] data = Encoding.ASCII.GetBytes(strOutput);
                socket.BeginSend(data, 0, strOutput.Length, SocketFlags.None, new AsyncCallback(SendCallBack), socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);

            }
            else
            {
                response = "inserte caracter valido";
                byte[] data = Encoding.ASCII.GetBytes(response);
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);
            }
        }

       

        private static void SendCallBack(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
    }
}
