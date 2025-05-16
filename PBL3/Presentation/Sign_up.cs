using PBL3.BLL;
using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3
{
    public partial class Sign_up : Form
    {   
        public Sign_up()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            textBox4.UseSystemPasswordChar = true;
            textBox5.UseSystemPasswordChar = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Log_in log_in = new Log_in();
            log_in.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handle h = BLL.handle.Instance;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            if (!h.checkValidUsername(textBox1.Text)) return;
            if(h.checkExistedUsername(textBox1.Text)) return;
            if (!h.checkValidPassword(textBox4.Text)) return;
            if (!h.checkValidRePassword(textBox4.Text, textBox5.Text)) return;
            if (!h.checkValidName(textBox3.Text)) return;
            if (!h.checkValidPhone(textBox2.Text)) return;
            if(!h.checkValidID_card(textBox6.Text)) return;
            User u = new User()
            {
                username = textBox1.Text,
                password = textBox4.Text,
                role_ID = 1
            };
            Customer_view_info c= new Customer_view_info()
            {
                customer_name = textBox3.Text,
                phone_number = textBox2.Text,
                ID_card_number = textBox6.Text,
                user_ID = h.addNguoiDung(u)
            };
            h.addKhachHang(c);

            MessageBox.Show("Đăng ký thành công.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = false;
                textBox5.UseSystemPasswordChar = false;
            }
            else
            {
                textBox4.UseSystemPasswordChar = true;
                textBox5.UseSystemPasswordChar = true;
            }
        
    }
    }
}
