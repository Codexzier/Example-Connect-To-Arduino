using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ExampleConnectToArduino
{
    public class NetworkHost
    {
        private Socket _connection;
        private int _port = 1200;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="port">Set the port for the network connection.</param>
        public NetworkHost(int port)
        {
            this._port = port;
        }

        /// <summary>
        /// Starts the socket class with the configurate as server.
        /// </summary>
        public void Start()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, this._port));
            socket.Listen(1);

            this._connection = socket.Accept();
        }
        
        /// <summary>
        /// Send a command to 
        /// </summary>
        /// <param name="command">letter can not be blank</param>
        public void SendCommand(char command)
        {
            if (!char.Equals(command, ' '))
            {
                this._connection.Send(Encoding.UTF8.GetBytes(new char[] { command }));
            }
        }

        /// <summary>
        /// Disposed and stop the socket.
        /// </summary>
        public void Stop()
        {
            if (this._connection != null)
            {
                this._connection.Dispose();
                this._connection = null;
            }
        }
    }
}
