using PBL3.DTO;
using PBL3.Presentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PBL3.DAL
{
    internal class data
    {
        private static data instance;
        public static data Instance
        {
            get { if (instance == null) instance = new data(); return data.instance; }
            private set { data.instance = value; }
        }
        public List<User> getAllNguoiDung()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from i in db.NGUOIDUNGs
                    select new User()
                    {
                        user_ID = Convert.ToInt32(i.MaNguoiDung),
                        username = i.TenDangNhap,
                        password = i.MatKhau,
                        role_ID = Convert.ToInt32(i.VaiTroID)
                    }).ToList();
        }
        public List<Customer_view_info> getAllCustomer()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from i in db.KHACHHANGs
                    select new Customer_view_info()
                    {
                        customer_ID = Convert.ToInt32(i.MaKhachHang),
                        user_ID = Convert.ToInt32(i.MaNguoiDung),
                        customer_name = i.HoTen,
                        ID_card_number = i.CMND,
                        phone_number = i.SoDienThoai
                    }).ToList();
        }
        public string getCustomerName(int user_id)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var query = (from i in db.KHACHHANGs 
                         join j in db.NGUOIDUNGs on i.MaNguoiDung equals j.MaNguoiDung
                         where j.MaNguoiDung == user_id
                         select i.HoTen).FirstOrDefault();
            return query;
        }

        public List<Room_view> getRoomView(string txt)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var query=from i in db.PHONGs
                      join j in db.KHACHSANs on i.MaKhachSan equals j.MaKhachSan
                      where j.TenKhachSan.Contains(txt)
                      select new Room_view()
                      {     room_ID = Convert.ToInt32(i.MaPhong),
                          room_name = i.TenPhong,
                          hotel_name = j.TenKhachSan,
                          image = i.HinhAnh,
                          price = Convert.ToInt32(i.GiaTien),
                          location = j.DiaChi
                      };
            return query.ToList();
        }
        public int insertNguoiDung(User u)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            NGUOIDUNG entity = new NGUOIDUNG() { TenDangNhap = u.username, MatKhau = u.password, VaiTroID = u.role_ID };
            db.NGUOIDUNGs.InsertOnSubmit(entity);
            db.SubmitChanges();
            return entity.MaNguoiDung;
        }
        public void insertKhachHang(Customer_view_info c)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            KHACHHANG entity = new KHACHHANG() { MaNguoiDung = c.user_ID, HoTen = c.customer_name, CMND = c.ID_card_number, SoDienThoai = c.phone_number };
            db.KHACHHANGs.InsertOnSubmit(entity);
            db.SubmitChanges();
        }
        public Room getRoomByID(int id)
        {   DataClasses1DataContext db = new DataClasses1DataContext();
            var query = from i in db.PHONGs
                        join j in db.KHACHSANs on i.MaKhachSan equals j.MaKhachSan
                        join k in db.LOAIPHONGs on i.MaLoaiPhong equals k.MaLoaiPhong
                        join l in db.TRANGTHAIPHONGs on i.MaTrangThai equals l.MaTrangThai
                        where i.MaPhong == id
                        
                        select new Room()
                        {
                            room_ID = Convert.ToInt32(i.MaPhong),
                            room_name = i.TenPhong,
                            hotel_name = j.TenKhachSan,
                           location = j.DiaChi,
                            room_type = k.TenLoaiPhong,
                            price = Convert.ToInt32(i.GiaTien),
                            status = l.TenTrangThai,
                            description = i.MoTa,
                            avatarImage = i.HinhAnh,
                            detailedImages = (from m in db.ANHPHONGs
                                              where m.MaPhong == i.MaPhong
                                              select m.DuongDan).ToList()
                        };
            return query.FirstOrDefault();

        }
        
    }
}
