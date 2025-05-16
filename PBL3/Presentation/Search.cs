using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PBL3.Presentation
{
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
            comboBox1.Items.Add("Ascending");
            comboBox1.Items.Add("Descending");
            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " ";
            label6.Text = "Welcome " + BLL.handle.Instance.getCustomerName(Session.currentUser.user_ID);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Focus();
            label2.Enabled=false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                label2.Text = "Input destination";                
            }
            else
            {
                label2.Text = "";
            }
        }
        private bool checkValid()
        {  
            if (dateTimePicker1.Value.Date>dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu");
                return false;
            }
            return true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {   
            Main_screen.Instance.reload(textBox1.Text);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            if (dateTimePicker1.Value<DateTime.Today)
            {   MessageBox.Show("Ngày bắt đầu không được nhỏ hơn ngày hiện tại");
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {   dateTimePicker2.Format = DateTimePickerFormat.Short;
            if (!checkValid())
            {   dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = " ";
            }
        }
    }
}
