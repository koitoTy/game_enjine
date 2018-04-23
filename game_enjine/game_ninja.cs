using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_367_form.ver1._6_pre_beta
{
    public partial class game_ninja : Form
    {
        public game_ninja()
        {
            InitializeComponent();
            game_.ControlAdded += Game_ControlAdded;
            game_image = new List<string>();
            //    image_id = new List<int>();
            pb_ = new List<PictureBox>();
        }
        List<PictureBox> pb_;
        List<string> game_image;
        
        string file_name;
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            //string dir = fd.InitialDirectory;
            file_name = fd.FileName;
            pictureBox1.ImageLocation = file_name;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh();
        }

        private static int width_;
        private static int height_;

        private void button2_Click(object sender, EventArgs e)
        {
            if (width_ == 0 && height_ == 0) { return; }
            PictureBox pb = new PictureBox();            
            pb.Location = new Point(Convert.ToInt32(control_x.Text.Trim()), 
                Convert.ToInt32(control_y.Text.Trim()));            
            pb.Name = item_name_.Text;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            game_image.Add(file_name);            
            pb.ImageLocation = game_image[game_image.Count - 1];
            pb.Width = width_;
            pb.Height = height_;
            pb.Visible = true;
            pb.DoubleClick += focus_item;
            pb.Refresh();
            pb_.Add(pb);
            
            game_.Controls.Add(pb);
            
            game_.Refresh();
            //pb_[pb_.Count - 1].Refresh();
        }

        private void focus_item(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            PictureBox sender_ = (PictureBox)sender;
            string name = sender_.Name;
            if (name == "main()")
            {
                /*
                 * 
                 * ОСНОВНОЙ КОД ТУТ 
                 * 
                 * */
                map.object_ main_ = new map.object_("mine", null, null, null, null,
                    new coordinate.work(sender_), 2, 2);
                main_.unsafe_mod();
                foreach (var item in pb_)
                {
                    if(item.Name != "main()")
                        main_.unsafe_plus_work(new coordinate.work(item));
                }
                bool b = main_.unsafe_eql();
                string[] str = main_.unsafe_eql_string_array();
            }                            
        }

        private void Game_ControlAdded(object sender, ControlEventArgs e)
        {
            
            //throw new NotImplementedException();
        }

        private void item_name__MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((textBox1.Text != "" && textBox2.Text != "") ||
                    (textBox1.Text != null && textBox2.Text != null))
                {
                    width_ = Convert.ToInt32(textBox1.Text);
                    height_ = Convert.ToInt32(textBox1.Text);
                }
            }            
        }
    }
}
