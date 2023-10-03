using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThuChiGiaDinh
{
    internal class ThuChi
    {
        // Các thành phần
        private string stt;
        private string ngay;
        private string mathuchi;
        private double tien;
        private string lydo;
        //Properties
        public string Stt { get => stt; set => stt = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string Mathuchi { get => mathuchi; set => mathuchi = value; }
        public double Tien { get => tien; set => tien = value; }
        public string Lydo { get => lydo; set => lydo = value; }

        //Constructor
        // Constructor không có đối sồ
        public ThuChi() { }
        // Constructor có các đối số là thông tin thu chi
        public ThuChi(string stt, string ngay, string mathuchi, double tien, string lydo)
        {
            this.stt = stt;
            this.ngay = ngay;
            this.mathuchi = mathuchi;
            this.tien = tien;
            this.lydo = lydo;
        }
        // Constructor copy : khởi tạo một đối tượng có nội dung từ một đối tượng đã có
        public ThuChi(ThuChi thuChi)
        {
            stt = thuChi.stt;
            ngay = thuChi.ngay;
            mathuchi = thuChi.mathuchi;
            tien = thuChi.tien;
            lydo = thuChi.lydo;
        }

        public void InputTC()
        {
            Console.WriteLine("Nhập thông tin một mục thu chi :");
            Console.Write("         Số thứ tự : ");
            stt = Console.ReadLine();
            Console.Write("        Ngày : ");
            ngay = Console.ReadLine();
            Console.Write("           Mã Thu Chi : ");
            mathuchi = Console.ReadLine();
            Console.Write("          Tiền : ");
            tien = double.Parse(Console.ReadLine());
            Console.Write("     Lý do : ");
            lydo = Console.ReadLine();
        }

        public void OutputTC()
        {
            Console.WriteLine(stt.PadLeft(10) + ngay.PadRight(20) + mathuchi.PadRight(10)
                + tien.ToString().PadLeft(12) + lydo.PadRight(10));
        }
    }
}
