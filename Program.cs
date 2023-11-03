using System.Net.Sockets;
using System.Text;

using var topClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
try
{
    await topClient.ConnectAsync("192.168.220.139", 1776);
    while(true){
        System.Console.WriteLine("Enter command for server: ");
        string command = Console.ReadLine() + '\n';

        byte[] reqData = Encoding.UTF8.GetBytes(command);
        await topClient.SendAsync(reqData, SocketFlags.None);
        Console.WriteLine("Message has been send");
        byte[] data = new byte[512];
        int bytes = await topClient.ReceiveAsync(data, SocketFlags.None);


        string time = Encoding.UTF8.GetString(data, 0, bytes);
        Console.WriteLine($"Time: {time}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}