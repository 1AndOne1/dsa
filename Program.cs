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

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        // Вызов функции с указанием пути к исходной картинке и нового имени файла
        CopyImageAsBytes("путь_к_исходной_картинке.jpg", "новое_имя_файла.jpg");
    }

    public static void CopyImageAsBytes(string sourceImagePath, string newImageName)
    {
        try
        {
            // Чтение изображения в виде массива байтов
            byte[] imageBytes = File.ReadAllBytes(sourceImagePath);

            // Сохранение массива байтов в новый файл
            File.WriteAllBytes(newImageName, imageBytes);

            Console.WriteLine("Изображение успешно скопировано в новый файл с именем " + newImageName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при копировании изображения: " + ex.Message);
        }
    }
}

using System;
﻿using System.Net.Sockets;
using System.Text;
        using var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try {
            await client.ConnectAsync("192.168.220.139", 1777);

            string filePath = @"/home/user/obj/step/cow.webp";
            byte[] fileBytes = File.ReadAllBytes(filePath);

            await client.SendAsync(fileBytes, SocketFlags.None);
            byte[] data = new byte[512];
        int bytes = await client.ReceiveAsync(data, SocketFlags.None);

            Console.WriteLine("Done");
        }
        catch (Exception ex)
        {
    Console.WriteLine(ex);
    throw;
    }
