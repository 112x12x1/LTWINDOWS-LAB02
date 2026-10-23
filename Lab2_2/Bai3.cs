using System;
using System.Collections.Generic;

class SinhVien
{
    public int MaSV { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public string DiaChi { get; set; }
    public string DienThoai { get; set; }

    public int Tuoi
    {
        get { return DateTime.Now.Year - NgaySinh.Year; }
    }

    public SinhVien()
    {
        HoTen = "";
        DiaChi = "";
        DienThoai = "";
    }

    public SinhVien(int maSV, string hoTen, DateTime ngaySinh, string diaChi, string dienThoai)
    {
        MaSV = maSV;
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        DiaChi = diaChi;
        DienThoai = dienThoai;
    }

    public override string ToString()
    {
        return string.Format("{0} - {1} sinh {2}, {3} tuoi, {4}, {5}.", MaSV, HoTen, NgaySinh.ToString("dd/MM/yyyy"), Tuoi, DienThoai, DiaChi);
    }
}

class HinhChuNhat
{
    private double mChieuCao;
    private double mChieuRong;

    public double ChieuCao
    {
        get { return mChieuCao; }
        set { if (value > 0) mChieuCao = value; }
    }

    public double ChieuRong
    {
        get { return mChieuRong; }
        set { if (value > 0) mChieuRong = value; }
    }

    public HinhChuNhat()
    {
        mChieuCao = 1;
        mChieuRong = 1;
    }

    public HinhChuNhat(double chieuCao, double chieuRong)
    {
        mChieuCao = chieuCao > 0 ? chieuCao : 1;
        mChieuRong = chieuRong > 0 ? chieuRong : 1;
    }

    public double TinhChuVi()
    {
        return (mChieuCao + mChieuRong) * 2;
    }

    public double TinhDienTich()
    {
        return mChieuCao * mChieuRong;
    }

    public bool KiemTraHinhVuong()
    {
        return mChieuCao == mChieuRong;
    }

    public void XuatThongTin()
    {
        Console.WriteLine("Chieu rong: {0}, Chieu dai/cao: {1}, Dien tich: {2}, Chu vi: {3}, La hinh vuong: {4}", 
            mChieuRong, mChieuCao, TinhDienTich(), TinhChuVi(), KiemTraHinhVuong());
    }
}

class SanPham
{
    public string MaSP { get; set; }
    public string TenSP { get; set; }
    public double GiaSP { get; set; }

    public SanPham()
    {
        MaSP = "";
        TenSP = "";
        GiaSP = 0;
    }

    public SanPham(string maSP, string tenSP, double giaSP)
    {
        MaSP = maSP;
        TenSP = tenSP;
        GiaSP = giaSP;
    }

    public double TinhThueVAT()
    {
        return GiaSP * 0.1;
    }

    public void Nhap()
    {
        Console.Write("Nhap ma san pham: ");
        MaSP = Console.ReadLine() ?? "";

        Console.Write("Nhap ten san pham: ");
        TenSP = Console.ReadLine() ?? "";

        while (true)
        {
            Console.Write("Nhap gia san pham: ");
            if (double.TryParse(Console.ReadLine(), out double gia) && gia >= 0)
            {
                GiaSP = gia;
                break;
            }
            Console.WriteLine("Gia khong hop le! Vui long nhap lai.");
        }
    }

    public void Xuat()
    {
        Console.WriteLine("Ma: {0} | Ten: {1} | Gia: {2} | Thue VAT (10%): {3}", MaSP, TenSP, GiaSP, TinhThueVAT());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== 1. KIEM TRA LOP SINH VIEN ===");
        List<SinhVien> dssv = new List<SinhVien>();
        dssv.Add(new SinhVien(1, "Tran Van Teo", new DateTime(2000, 11, 28), "123 Truong Dinh", "0909789567"));
        dssv.Add(new SinhVien(2, "Tran Van Quang", new DateTime(1999, 11, 28), "123 Truong Cong Dinh", "0909567789"));

        foreach (SinhVien sv in dssv)
        {
            Console.WriteLine(sv);
        }

        Console.WriteLine("\n=== 2. KIEM TRA LOP HINH CHU NHAT ===");
        HinhChuNhat hcn = new HinhChuNhat(5, 5);
        hcn.XuatThongTin();

        Console.WriteLine("\n=== 3. KIEM TRA LOP SAN PHAM ===");
        SanPham sp = new SanPham();
        sp.Nhap();
        Console.WriteLine("Thong tin san pham vua nhap:");
        sp.Xuat();
    }
}
