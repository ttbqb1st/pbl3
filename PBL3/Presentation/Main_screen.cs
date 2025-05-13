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

namespace PBL3.Presentation
{
    
    public partial class Main_screen : Form
    {   private static Main_screen _instance;
        private Home home;
        private Search search;
        public static Main_screen Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Main_screen();
                }
                return _instance;
            }
        }
        public Main_screen()
        {   
            InitializeComponent();
            _instance = this;
            search = new Search();
            panel2.Controls.Add(search);
            home = new Home();
            reload("");

        }
        
        public void addControl(Control c)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(c);
        }
        public void reload(string txt)
        {
            if(!panel2.Controls.Contains(home))
            {
                panel2.Controls.Add(home);
            }
            home.showRoom_view(BLL.handle.Instance.getRoom_view(txt));           
            home.BringToFront();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
           
        }
        
       

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_screen_MouseClick(object sender, MouseEventArgs e)
        {
            Search s = new Search();       
            if (!s.Bounds.Contains(e.Location))
            {   
                
            }
        }

        

       

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox5.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox5.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox3.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox3.BackColor = Color.FromArgb(0, 0, 0);

        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox4.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.FromArgb(0, 0, 0);
            pictureBox4.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {   panel2.Controls.Clear();
            search = new Search();
            panel2.Controls.Add(search);
            home = new Home();
            reload("");
        }
    }
}
