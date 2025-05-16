using PBL3.BLL;
using PBL3.DTO;
using PBL3.Presentation;
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
    public partial class Log_in : Form
    {   
        public Log_in()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sign_up sign_up = new Sign_up();
            sign_up.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            User loggedInUser = handle.Instance.checkLogin(textBox1.Text, textBox2.Text);
            if (loggedInUser!=null && loggedInUser.role_ID==1)
            {   
                this.Hide();
                Session.currentUser = loggedInUser;
                Main_screen scr = new Main_screen();               
                scr.Show();                
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
        }
    }
}
