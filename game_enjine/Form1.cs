using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using coordinate;

namespace Tank_367_form.ver1._6_pre_beta
{
    public partial class Form1 : Form
    {

//---------------------------------------------------|
        private static int pixel_move = 5;//         |
//---------------------------------------------------|        
        private static List<string> img;//           |
//---------------------------------------------------|
        private static int MyID = 0;//               |
//---------------------------------------------------|
        private static utp client;//                 |
        private static utp server;//                 |
//---------------------------------------------------|
        List<coordinate.coordinate> coordinate_;

        List<coordinate.work> work_;

        public Form1()
        {
            InitializeComponent();
            pictureBox0.SizeMode = PictureBoxSizeMode.StretchImage;
            server = Program.get_client();
            client = Program.get_client();

            byte[] data = new byte[9];
            //data[6] = Convert.ToByte(Convert.ToInt32(server.get_addr_port()[1]));
            //client.send_9byte(new data(true, data, 0, "0"));
            
            img = new List<string>();
            img.Add(@"C:\Users\пк\Pictures\3.jpg");
            pictureBox0.ImageLocation = img[MyID];
            coordinate_ = new List<coordinate.coordinate>();
            work_ = new List<work>();
            work_.Add(new work(pictureBox0));
            work_[0].update_coordinate();
            coordinate_.Add(work_[0].get_coordinate());
        }


        private void Move_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                pictureBox0.Location = new Point(pictureBox0.Location.X + pixel_move,
                    pictureBox0.Location.Y);
                //pictureBox0.ImageLocation = img[MyID];
                
                pictureBox0.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                
                pictureBox0.Refresh();
                work_[0].update_coordinate();
                coordinate_[0] = work_[0].get_coordinate();
                //pictureBox0.Refresh();
            }
            if (e.KeyCode == Keys.Left  || e.KeyCode == Keys.A)
            {
                pictureBox0.Location = new Point(pictureBox0.Location.X - pixel_move,
                    pictureBox0.Location.Y);
                //pictureBox0.ImageLocation = img[MyID];
                pictureBox0.Refresh();
                pictureBox0.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox0.Update();
                work_[0].update_coordinate();
                coordinate_[0] = work_[0].get_coordinate();
                //pictureBox0.Refresh();
            }
            if (e.KeyCode == Keys.Up    || e.KeyCode == Keys.W)
            {
                pictureBox0.Location = new Point(pictureBox0.Location.X,
                    pictureBox0.Location.Y - pixel_move);
                //pictureBox0.ImageLocation = img[MyID];
                pictureBox0.Refresh();
                work_[0].update_coordinate();
                coordinate_[0] = work_[0].get_coordinate();
                //pictureBox0.Update();
            }
            if (e.KeyCode == Keys.Down  || e.KeyCode == Keys.S)
            {
                pictureBox0.Location = new Point(pictureBox0.Location.X,
                    pictureBox0.Location.Y + pixel_move);
                //pictureBox0.ImageLocation = img[MyID];
                
                pictureBox0.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pictureBox0.Refresh();
                work_[0].update_coordinate();
                coordinate_[0] = work_[0].get_coordinate();
                //pictureBox0.Refresh();
            }
            if (e.KeyCode == Keys.Escape)
                Dispose(true);
        }
    }
}
