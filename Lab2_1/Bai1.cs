using System;

class NotNegativeException : Exception
{
    public NotNegativeException() : base("Gia tri duoi dau can < 0")
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Nhap x: ");
            double x = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap y: ");
            double y = double.Parse(Console.ReadLine() ?? "0");

            double mauSo = 2 * x - y;
            if (mauSo == 0)
            {
                throw new DivideByZeroException("Loi chia cho 0 trong mau so.");
            }

            double bieuThuc = (3 * x + 2 * y) / mauSo;
            if (bieuThuc < 0)
            {
                throw new NotNegativeException();
            }

            double H = Math.Sqrt(bieuThuc);
            Console.WriteLine("Gia tri bieu thuc H = " + H.ToString());
        }
        catch (FormatException)
        {
            Console.WriteLine("Loi: Sai format du lieu! Vui long nhap vao mot so thuc.");
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Loi: " + e.Message);
        }
        catch (NotNegativeException e)
        {
            Console.WriteLine("Loi: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Loi khong xac định: " + e.Message);
        }
    }
}