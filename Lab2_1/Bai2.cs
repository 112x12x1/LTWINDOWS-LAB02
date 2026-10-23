using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = 0;
        while (true)
        {
            Console.Write("Nhap so luong phan tu n (n > 0): ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                break;
            }
            Console.WriteLine("Gia tri khong hop le! Vui long nhap lai.");
        }

        List<int> ds = new List<int>();
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            ds.Add(rnd.Next(100));
        }

        Console.WriteLine("Danh sach truoc khi sap xep:");
        Console.WriteLine(string.Join(", ", ds));

        ds.Sort();

        Console.WriteLine("Danh sach sau khi sap xep tang dan:");
        Console.WriteLine(string.Join(", ", ds));
    }
}
