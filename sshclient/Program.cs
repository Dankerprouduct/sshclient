using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet; 
using System.Threading;

namespace sshclient
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var client = new SshClient("10.146.3.39", "pi", "raspberry"))
            {
                client.Connect();

                if (client.IsConnected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("connected");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                while (true)
                {
                    string input = Console.ReadLine();
                    SshCommand command = client.CreateCommand(input);
                    
                    command.Execute();

                    Console.WriteLine("sent command");

                    Thread.Sleep(500);

                    Console.WriteLine(command.Result);

                    Console.WriteLine(command.Error);
                        
                    Console.WriteLine(command.ExtendedOutputStream);

                    
                }
            }
        }
    }
}
