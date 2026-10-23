using System;
using System.Collections.Generic;

struct MatHang
{
    public int MaMH { get; set; }
    public string TenMH { get; set; }
    public int SoLuong { get; set; }
    public float DonGia { get; set; }

    public MatHang(int maMH, string tenMH, int soLuong, float donGia)
    {
        MaMH = maMH;
        TenMH = tenMH;
        SoLuong = soLuong;
        DonGia = donGia;
    }

    public float ThanhTien()
    {
        return SoLuong * DonGia;
    }
}

class Program
{
    static void ThemMatHang(List<MatHang> ds, MatHang m)
    {
        ds.Add(m);
    }

    static bool TimMatHang(List<MatHang> ds, int maMH)
    {
        foreach (var item in ds)
        {
            if (item.MaMH == maMH)
            {
                return true;
            }
        }
        return false;
    }

    static void XoaMatHang(List<MatHang> ds, int maMH)
    {
        ds.RemoveAll(item => item.MaMH == maMH);
    }

    static void XuatDanhSach(List<MatHang> ds)
    {
        foreach (var item in ds)
        {
            Console.WriteLine("Ma: {0} | Ten: {1} | So luong: {2} | Don gia: {3} | Thanh tien: {4}", 
                item.MaMH, item.TenMH, item.SoLuong, item.DonGia, item.ThanhTien());
        }
    }

    static void Main(string[] args)
    {
        List<MatHang> danhSach = new List<MatHang>();

        while (true)
        {
            int ma = 0;
            while (true)
            {
                Console.Write("Nhap ma mat hang (so nguyen): ");
                if (int.TryParse(Console.ReadLine(), out ma)) break;
                Console.WriteLine("Gia tri khong hop le! Vui long nhap lai.");
            }

            Console.Write("Nhap ten mat hang: ");
            string ten = Console.ReadLine() ?? "";

            int sl = 0;
            while (true)
            {
                Console.Write("Nhap so luong (so nguyen): ");
                if (int.TryParse(Console.ReadLine(), out sl) && sl >= 0) break;
                Console.WriteLine("Gia tri khong hop le! Vui long nhap lai.");
            }

            float dg = 0;
            while (true)
            {
                Console.Write("Nhap don gia (so thuc): ");
                if (float.TryParse(Console.ReadLine(), out dg) && dg >= 0) break;
                Console.WriteLine("Gia tri khong hop le! Vui long nhap lai.");
            }

            MatHang mh = new MatHang(ma, ten, sl, dg);
            ThemMatHang(danhSach, mh);

            Console.Write("Ban co muon tiep tuc nhap khong? (C/K): ");
            string choice = Console.ReadLine() ?? "";
            if (choice.ToUpper() != "C")
            {
                break;
            }
        }

        Console.WriteLine("\n--- DANH SACH CAC MAT HANG ---");
        XuatDanhSach(danhSach);

        int maTim = 0;
        Console.Write("\nNhap ma mat hang can tim va xoa: ");
        if (int.TryParse(Console.ReadLine(), out maTim))
        {
            if (TimMatHang(danhSach, maTim))
            {
                Console.WriteLine("Tim thay mat hang! Tien hanh xoa...");
                XoaMatHang(danhSach, maTim);
                Console.WriteLine("--- DANH SACH SAU KHI XOA ---");
                XuatDanhSach(danhSach);
            }
            else
            {
                Console.WriteLine("Khong tim thay mat hang co ma nay.");
            }
        }
    }
}
