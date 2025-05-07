using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    internal class handle
    {
        private static handle instance;
        public static handle Instance
        {
            get { if (instance == null) instance = new handle(); return handle.instance; }
            private set { handle.instance = value; }
        }
        public bool checkLogin(string username, string password)
        {
            var user = DAL.data.Instance.getAllNguoiDung().FirstOrDefault(u => u.username == username && u.password == password);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
