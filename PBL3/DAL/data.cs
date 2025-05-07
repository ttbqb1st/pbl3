using PBL3.DTO;
using PBL3.Presentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    internal class data
    {
        private DataClasses1DataContext db = new DataClasses1DataContext();
        private static data instance;
        public static data Instance
        {
            get { if (instance == null) instance = new data(); return data.instance; }
            private set { data.instance = value; }
        }
        public List<Nguoi_dung> getAllNguoiDung()
        {
            return (from i in db.NGUOIDUNGs
                    select new Nguoi_dung()
                    {
                        user_ID = Convert.ToInt32(i.MaNguoiDung),
                        username = i.TenDangNhap,
                        password = i.MatKhau,
                        role_ID = Convert.ToInt32(i.VaiTroID)
                    }).ToList();
        }
    }
}
