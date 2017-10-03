using System;

namespace ExampleConnectToArduino
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkHost host = new NetworkHost(1200);

            bool run = true;
            while (run)
            {
                Console.WriteLine("a = ON");
                Console.WriteLine("b = OFF");
                Console.WriteLine("c = Close application");

                string enter = Console.ReadLine();

                if(enter.Contains("a") || enter.Contains("b"))
                {
                    host.SendCommand(enter.ToCharArray()[0]);
                }
                else if(enter == "c")
                {
                    run = false;
                }
            }

            host.Stop();
        }
    }
}
