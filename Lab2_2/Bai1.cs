using System;
using System.Collections.Generic;

class Program
{
    static void XuatMang(List<string> M)
    {
        string chuoi = string.Join(", ", M);
        Console.WriteLine(chuoi);
    }

    static void Main(string[] args)
    {
        List<string> mang = new List<string>();
        string tmp;

        while (true)
        {
            Console.Write("Chuoi nhap: ");
            tmp = (Console.ReadLine() ?? "").Trim();
            if (tmp.ToUpper() == "STOP")
            {
                break;
            }
            mang.Add(tmp);
            Console.WriteLine("Count = {0}, Capacity = {1}", mang.Count, mang.Capacity);
        }

        Console.WriteLine("\n--- DANH SACH HANG HOA ---");
        XuatMang(mang);

        Console.Write("\nCan tim: ");
        tmp = (Console.ReadLine() ?? "").Trim();
        if (mang.Contains(tmp))
        {
            Console.WriteLine("Tim thay {0} tai vi tri {1}", tmp, mang.IndexOf(tmp));
            mang.Remove(tmp);
            Console.WriteLine("--- DANH SACH SAU KHI XOA ---");
            XuatMang(mang);
        }
        else
        {
            Console.WriteLine("Khong tim thay {0} trong danh sach.", tmp);
        }

        Console.Write("\nNhap ten hang hoa muon chem: ");
        string hangHoaMoi = (Console.ReadLine() ?? "").Trim();
        
        int index = -1;
        while (true)
        {
            Console.Write("Nhap vi tri index muon chen (0 den {0}): ", mang.Count);
            if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= mang.Count)
            {
                break;
            }
            Console.WriteLine("Vi tri index khong hop le! Vui long nhap lai.");
        }

        mang.Insert(index, hangHoaMoi);
        Console.WriteLine("--- DANH SACH SAU KHI CHEN ---");
        XuatMang(mang);

        mang.Sort();
        Console.WriteLine("\nSau khi sap: ");
        XuatMang(mang);

        mang.Clear();
        Console.WriteLine("Sau khi xoa, mang con {0} phan tu", mang.Count);
    }
}
