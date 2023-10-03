using Buoi01Arr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuChiGiaDinh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Xuất text theo Unicode (có dấu tiếng Việt)
            Console.OutputEncoding = Encoding.Unicode;
            // Nhập text theo Unicode (có dấu tiếng Việt)
            Console.InputEncoding = Encoding.Unicode;

            /* Tạo menu */
            Menu menu = new Menu();
            // Xây dựng giá trị cho các tham số để gọi phương thức ShowMenu(title, ms)
            string title = "SỔ THU CHI";   // Tiêu đề menu
            // Danh sách các mục chọn
            string[] ms = { "1. Xem sổ thu chi", "2. Thêm mục thu chi",
                "3. Tìm nội dung mục thu chi", "4. Cập nhật số tiền của mục thu chi",
                "5. Xóa một mục thu chi", "6. Cập nhật sổ thu chi vào file",
                "7. Xuất danh sách các mục thu chi của tháng m", "0. Thoát" };

            SoThuChi sotc = new SoThuChi();
            // Tạo đường dẫn file dùng làm tham số
            string filePath = "../../TextFile/ThuChi.txt";
            sotc.FileToList(filePath);    // Đọc file -> ds
            int chon;
            do
            {
                // Xuất menu
                menu.ShowMenu(title, ms);
                Console.Write("     Chọn : ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            ViewSOTC(sotc); break;
                        }
                    case 2:
                        {
                            sotc.AddNewTC();
                            break;
                        }
                    case 3:
                        {
                            Console.Write(" Nhập số thứ tự k cần tìm : ");
                            string ma = Console.ReadLine();
                            int vitri = sotc.FindTC(ma);
                            if (vitri == -1)
                                Console.WriteLine("   Không có mục thu chi này");
                            else
                            {
                                sotc.PrintTitle();
                                sotc.Sotc[vitri].OutputTC();
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Write(" Nhập mục thu chi cần sửa tiền : ");
                            string ma = Console.ReadLine();
                            int vt = sotc.FindTC(ma);
                            if (vt == -1)
                                Console.WriteLine("   Không có sinh viên này");
                            else
                            {
                                sotc.PrintTitle();
                                sotc.Sotc[vt].OutputTC();
                                Console.Write(" Tiền cập nhật : ");
                                float tien = float.Parse(Console.ReadLine());
                                sotc.Sotc[vt].Tien = tien;
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Write(" Nhập số thứ tự của mục thu chi cần xóa : ");
                            string ma = Console.ReadLine();
                            int vt = sotc.FindTC(ma);
                            if (vt == -1)
                                Console.WriteLine("   Không có mục thu chi này");
                            else
                            {
                                sotc.PrintTitle();
                                sotc.Sotc[vt].OutputTC();
                                Console.Write(" Có chắc xóa mục thu chi trên (0/1?) : ");
                                int ch = int.Parse(Console.ReadLine());
                                if (ch == 1)
                                    sotc.DeleteTC(vt);
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.Write(" Có muốn cập nhật sotc vào file (0/1?) : ");
                            int ch = int.Parse(Console.ReadLine());
                            if (ch == 1)
                                sotc.ListToFile(filePath);
                            break;
                        }
                }
                Console.WriteLine(" Nhấn một phím bất kỳ");
                Console.ReadKey();
                Console.Clear();
            } while (chon != 0);
        }
        static void ViewSOTC(SoThuChi sotc)
        {
            sotc.PrintSoTC();
        }
    }
}
