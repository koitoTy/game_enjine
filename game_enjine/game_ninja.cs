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
        string path_code;
        string code;

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
                    new coordinate.work(sender_), 5, 5);
                main_obj = main_;
                main_.unsafe_mod();
                foreach (var item in pb_)
                {
                    if(item.Name != "main()")
                        main_.unsafe_plus_work(new coordinate.work(item));
                }
                //bool b = main_.unsafe_eql();
                string[] str = main_.unsafe_eql_string_array();
                //main_.get_name_();
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

        private void game__DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs m_e = e as MouseEventArgs;
            //MouseButtons mouse_b = m_e.Button;
            int x_pos = m_e.X;
            int y_pos = m_e.Y;
            if (width_ == 0 && height_ == 0) { return; }
            PictureBox pb = new PictureBox();
            pb.Location = new Point(x_pos, y_pos);
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
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((textBox1.Text != "" && textBox2.Text != "") ||
                    (textBox1.Text != null && textBox2.Text != null))
            {
                width_ = Convert.ToInt32(textBox1.Text);
                height_ = Convert.ToInt32(textBox1.Text);
            }
        }


        map.object_ main_obj;
        //bool control = false;
        private void button3_Click(object sender, EventArgs e)
        {
            //BUILD
            //control = true;
            
        }

        private void game_KeyDown(object sender, KeyEventArgs e)
        {
            //main_obj.get_work().update_coordinate();
            switch (e.KeyCode)
            {

                case Keys.Left:
                    main_obj.plus_x(false);
                    break;
                case Keys.Up:
                    main_obj.plus_y(true);
                    break;
                case Keys.Right:
                    main_obj.plus_x(true);
                    break;
                case Keys.Down:
                    main_obj.plus_y(false);
                    break;
                case Keys.Tab: { SaveFileDialog fd = new SaveFileDialog();
                        fd.ShowDialog();
                        string f_path = fd.FileName;
                        System.IO.StreamWriter s_writ = new System.IO.StreamWriter(
                            f_path);
                        for (int i = 0; i < game_.Controls.Count; i++)
                        {
                            PictureBox pb = (PictureBox) game_.Controls[i];
                            string data_ = null;
                            //1-name 2-x 3-y 4-heght, 5-width
                            data_ += pb.Name; data_ += ':';
                            data_ += pb.Location.X.ToString(); data_ += ':';
                            data_ += pb.Location.Y.ToString(); data_ += ':';
                            data_ += pb.Height.ToString(); data_ += ':';
                            data_ += pb.Width.ToString(); data_ += ':';
                            data_ += pb.ImageLocation; data_ += ";";
                            
                            s_writ.WriteLine(data_);
                        }
                        s_writ.Write('`');
                        string[] c_code = code.Split('\n').ToArray();
                        for (int i = 0; i < c_code.Length; i++)
                        {
                            s_writ.WriteLine(c_code[i]);
                        }                        
                        s_writ.Close();
                    } break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // GO 
            // PLAY GAME
            // TEST PROJECT
            // TEST
            textBox1.Enabled = false;
            control_x.Enabled = false;
            control_y.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            item_name_.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            (game_ as Control).KeyDown += new KeyEventHandler(game_KeyDown);
            (game_ as Control).Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            string file_way = fd.FileName;
            path_code = fd.FileName;
            System.IO.StreamReader fs = new System.IO.StreamReader(file_way);
            string data = null;
            string str;
            while((str=fs.ReadLine())!= null)
            {
                data += str;
            }
            string code = data.Split('`').ToArray()[1];            
            string[] elements = data.Split('`').ToArray()[0].Split(';').ToArray();
            //1-name 2-x 3-y 4-heght, 5-width, 6-location
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == "" || elements[i] == null
                    || elements[i] == "\0") break;
                string[] element_data = elements[i].Split(':').ToArray();
                PictureBox pb = new PictureBox();
                pb.Name = element_data[0];
                pb.Location = new Point(
                    Convert.ToInt32(element_data[1]),
                    Convert.ToInt32(element_data[2]));
                pb.Height = Convert.ToInt32(element_data[3]);
                pb.Width = Convert.ToInt32(element_data[4]);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                Image h = Image.FromFile(element_data[5] + ":" + element_data[6]);
                
                pb.Image = h;
                pb.Refresh();

                pb.DoubleClick += new EventHandler(focus_item);

                if (pb.Name == "main()")
                    main_obj = new map.object_("main()", new coordinate.work(pb));
                pb_.Add(pb);
                game_.Controls.Add(pb);                                
            }
            //game_.Refresh();
        }

        
        private void call_module_Click(object sender, EventArgs e)
        {
            module_form f_ = new module_form();
            f_.code_ = code;
            f_.Show();
        }
    }
}
