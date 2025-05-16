using PBL3.DAL;
using PBL3.DTO;
using PBL3.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public bool validCharacter(char c)
        {
            for (int i = 48; i <= 57; i++)
                if (c == (char)i) return true;
            for(int i = 97; i <= 122; i++)
                if (c == (char)i) return true;
            return false;
        }
        public bool checkValidUsername(string username)
        {
            if (username.Length < 5 || username.Length > 20) {MessageBox.Show("Tên đăng nhập phải dài từ 5 đến 20 kí tự."); return false; }
            for (int i = 0; i < username.Length; i++)
            {
                if (!validCharacter(username[i])) { MessageBox.Show("Tên đăng nhập chỉ được chứa chữ cái thường và số."); return false; }
            }
            return true;
        }
        public bool checkExistedUsername(string username)
        {
            var user = DAL.data.Instance.getAllNguoiDung().FirstOrDefault(u => u.username == username);
            if (user != null)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.");
                return true;
            }
            return false;
        }
        public bool checkValidPassword(string password)
        {
            if (password.Length < 6 || password.Length > 20) { MessageBox.Show("Mật khẩu phải dài từ 6 đến 20 kí tự."); return false; }
            return true;
        }
        public bool checkValidRePassword(string password,string rePassword)
        {
            if (password != rePassword) { MessageBox.Show("Mật khẩu không khớp."); return false; }
            return true;
        }
        public bool checkValidName(string name)
        {   if(name.Trim() == "") { MessageBox.Show("Tên không hợp lệ."); return false; }
            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]) && name[i] != ' ') { MessageBox.Show("Tên không hợp lệ."); return false; }
            }
            return true;
        }
        public bool checkValidPhone(string phone)
        {
            if (phone.Length != 10) { MessageBox.Show("Số điện thoại không hợp lệ."); return false; }
            for (int i = 0; i < phone.Length; i++)
            {
                if (!Char.IsDigit(phone[i])) { MessageBox.Show("Số điện thoại không hợp lệ."); return false; }
            }
            return true;
        }
        public bool checkValidID_card(string id_card)
        {
            if (id_card.Length != 12) { MessageBox.Show("Số CMND/CCCD không hợp lệ."); return false; }
            for (int i = 0; i < id_card.Length; i++)
            {
                if (!Char.IsDigit(id_card[i])) { MessageBox.Show("Số CMND/CCCD không hợp lệ."); return false; }
            }
            return true;
        }
        public User checkLogin(string username, string password)
        {
            var user = DAL.data.Instance.getAllNguoiDung().FirstOrDefault(u => u.username == username && u.password == password);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public string getCustomerName(int id) {
       
            return data.Instance.getCustomerName(id);
        }
        
        public int addNguoiDung(User u)
        {   

            return DAL.data.Instance.insertNguoiDung(u);
        }
        
        public void addKhachHang(Customer_view_info c)
        {
            DAL.data.Instance.insertKhachHang(c);

        }
        public List <Room_view> getRoom_view(string txt)
        {
            return DAL.data.Instance.getRoomView(txt);
        }
        public Room getRoomByID(int id)
        {
            return DAL.data.Instance.getRoomByID(id);
        }


    }
}
