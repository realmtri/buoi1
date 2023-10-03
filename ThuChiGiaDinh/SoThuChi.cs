using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThuChiGiaDinh
{
    internal class SoThuChi
    {
        // Thành phần : là danh sách các phần tử thu chi
        ThuChi[] sotc;
        // Propeties
        public ThuChi[] Sotc { get => sotc; set => sotc = value; }
        // Constructor
        //Constructor không đối số, cấp phát vùng nhớ
        public SoThuChi()
        { }
        // Constructor có các đối số là thông tin thu chi
        public SoThuChi(int k)
        {
            sotc = new ThuChi[k];
        }
        // Constructor copy : khởi tạo một đối tượng có nội dung từ một đối tượng đã có
        public SoThuChi(SoThuChi a)
        {
            sotc = new ThuChi[a.sotc.Length];
            for (var i = 0; i < a.sotc.Length; i++)
            {
                sotc[i] = a.sotc[i];
            }
        }

        // Đọc file văn bản filePath (ThuChi.txt) ra danh sách sotc
        public void FileToList(string filePath)
        {
            string[] lines;
            if (File.Exists(filePath)) // kiểm tra sự tồn tại của file
            {	   // Đọc các dòng trong file  array lines
                lines = File.ReadAllLines(filePath);
                // Tạo ds sinh viên
                sotc = new ThuChi[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] s = lines[i].Split('\t');
                    string stt = s[0];
                    string ngay = s[1];
                    string mathuchi = s[2];
                    double tien = double.Parse(s[3]);
                    string lydo = s[4];
                    // Khởi tạo một mục thu chi
                    ThuChi tc = new ThuChi(stt, ngay, mathuchi, tien, lydo);
                    // Đưa vào danh sách lst
                    sotc[i] = tc;
                }
            }
            else
            {
                Console.WriteLine("  Không tìm thấy File ThuChi.txt");
            }
        }
        // Xuất header của danh sách gồm tên danh sách và các tiêu đề cột
        public void PrintTitle()
        {
            Console.WriteLine();
            Console.WriteLine("     SO THU CHI");
            Console.WriteLine(new string('─', 110));
            Console.WriteLine("Tháng".PadLeft(10) + "Thu".PadLeft(20) + "Chi".PadLeft(20)
                + "Số dư".PadLeft(25));
            Console.WriteLine(new string('─', 110));
        }
        // Xuất danh sách sotc lên màn hình
        public void PrintSoTC()
        {
            PrintTitle();   // In tiêu đề lên màn hình
            // Duyệt từng phần tử trong danh sách sotc và xuất lên màn hình
            for (int i = 0; i < sotc.Length; i++)
                sotc[i].OutputTC();  // gọi phương thức OutputTC() trong class ThuChi
            Console.WriteLine(new string('─', 110));
            Console.WriteLine("    Danh sách có {0} mục thu chi", sotc.Length);
        }
        // Thêm một mục thu chi mới
        public void AddNewTC()
        {
            // Khởi tạo một sv mới
            ThuChi tc = new ThuChi();
            // Nhập thông tin sinh viên
            tc.InputTC();
            // Cấp phát thêm vùng nhớ cho lst và Đưa sv vào danh sách
            Array.Resize(ref sotc, sotc.Length + 1);
            sotc[sotc.Length - 1] = tc; ;
        }
        // Tìm nội dung mục thu chi trong sotc khi biết số thứ tự
        // Nếu có trả về vị trí tìm thấy, ngược lại trả về -1
        public int FindTC(string so)
        {
            for (int i = 0; i < sotc.Length; i++)
                if (sotc[i].Stt == so)
                    return i;
            return -1;
        }
        // Cập nhật số tiền của mục thu chi tại vị trí thứ k
        public void UpdateTien(int k)
        {
            Console.Write("  Nhap So Tien moi : ");
            float tien = float.Parse(Console.ReadLine());
            // vì ngoài class ThuChi nên gán tiền thông qua thuộc tính Tien
            sotc[k].Tien = tien;
        }
        // Xóa một mục thu chi tại vị trí thứ k
        public void DeleteTC(int k)
        {
            for (int i = k; i < sotc.Length - 1; i++)
                sotc[i] = sotc[i + 1];
            // Cấp phát lại vùng nhớ cho sotc
            Array.Resize(ref sotc, sotc.Length - 1);
        }
        // Ghi danh sách sotc vào file ThuChi.txt
        public void ListToFile(string filePath)
        {
            //Khởi tạo biến file sw, mở file thông qua biến sw
            StreamWriter sw = new StreamWriter(filePath);
            // Duyệt từng phần tử lst để xây dựng dòng ghi vào file
            for (int i = 0; i < sotc.Length; i++)
            {
                // Tạo dòng thông tin của mục thu chi và ghi vào file
                string lineTC = sotc[i].Stt + '\t' + sotc[i].Ngay + '\t' + sotc[i].Mathuchi + '\t'
                    + sotc[i].Tien + '\t' + sotc[i].Lydo + '\t';
                sw.WriteLine(lineTC);
            }
            sw.Close(); // Đóng file
        }
        // Xuất danh sách các mục thu chi của tháng m
        public void OutIndex(int m)
        {
            PrintTitle();
            sotc[m].OutputTC();
        }
        // Mục thu chi của tháng m
        //public void DsThang(string m)
        //{
        //    for (int i = 0; i < sotc.Length; i++)
        //    {
        //        if (sotc[i]. == cn)
        //        {
        //            lst[i].OutputSV();
        //        }
        //    }
        //}
    }
}
