using PBL3.DAL;
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
    public partial class Home : UserControl
    {   
        public Home()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;          
        }

        public void showRoom_view(List<Room_view>list)
        {
            flowLayoutPanel1.Controls.Clear();          
            foreach (Room_view r in list)
            {   
                Panel p = new Panel();
                p.Size = new Size(250, 320);
                p.Margin = new Padding(10);
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(250, 250);
                pictureBox.ImageLocation = r.image;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;  
                pictureBox.Tag=r.room_ID;
                pictureBox.Click += (s, e) =>
                {
                    
                    Home_order_page_ h = new Home_order_page_();
                  
                    h.showData(r.room_ID);
                    Main_screen.Instance.addControl(h);



                };
                Label label1 = new Label();
                Label label2 = new Label();
                Label label3 = new Label();
                label1.Text = r.room_name + "," +r.hotel_name+","+ r.location;
                label1.Location = new Point(0, 260);               
                label1.Size = new Size(250, 40);
                label1.TextAlign = ContentAlignment.TopLeft;
                label1.Font = new Font("Arial Rounded MT", 9, FontStyle.Bold);
                label2.Text=r.price.ToString() + " VND";
                label2.Location = new Point(0, 280);
                label2.Size = new Size(250, 15);
                label2.TextAlign = ContentAlignment.TopLeft;
                label2.Font = new Font("Arial Rounded MT", 9, FontStyle.Regular);
                label3.Text = r.price.ToString() + " VND";
                label3.Location = new Point(0, 300);
                label3.Size = new Size(250, 15);
                label3.TextAlign = ContentAlignment.TopLeft;
                label3.Font = new Font("Arial Rounded MT", 9, FontStyle.Regular);
                p.Controls.Add(label2);
                p.Controls.Add(label3);
                p.Controls.Add(pictureBox);
                p.Controls.Add(label1);
                flowLayoutPanel1.Controls.Add(p);
            }          
        }
    }
}
