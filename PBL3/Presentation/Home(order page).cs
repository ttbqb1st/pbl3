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
    public partial class Home_order_page_ : UserControl
    {
        public Home_order_page_()
        {
            
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " ";
            AutoScroll = true;

        }
        void showDetailedImages(List<string> images)
        {
            flowLayoutPanel1.AutoScroll = true;
            foreach (string i in images)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = i;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = 225;
                pictureBox.Height = 150;
                pictureBox.Margin = new Padding(5);
                flowLayoutPanel1.Controls.Add(pictureBox);
            }
        }
        public void showData(int id)
        {
            Room r = new Room();
            r = BLL.handle.Instance.getRoomByID(id);
            label2.Text = r.room_name + "," + r.hotel_name + "," + r.location;
            label9.Text = r.status;
            pictureBox1.ImageLocation = r.avatarImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            showDetailedImages(r.detailedImages);

            int total = (dateTimePicker2.Value.Day - dateTimePicker1.Value.Day + 1) * r.price;
            if (dateTimePicker1.CustomFormat == " " || dateTimePicker2.CustomFormat == " ")
            {
                label10.Text = "Total: ";
            } else
            { label10.Text = "Total: " + total.ToString() + " VND"; }
            label11.Text = r.description;


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Short;
        }
    }
}
