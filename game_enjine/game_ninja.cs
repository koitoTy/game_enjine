using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            path_code_base = new List<string>();
        }
        List<PictureBox> pb_;
        List<string> game_image;
        List<string> path_code_base;

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
            string[] export_code = new string[path_code_base.Count + 2];
            export_code[export_code.Length - 1] = "}";
            export_code[0] = "class work_in : Form \n{";
            for (int i = 1, k = 0; i < export_code.Length - 2; i++, k++)
            {
                export_code[i] = path_code_base[k];
            }
            string[] code_lib = new string[1223];
            //номер последней строки в файле coordinate.cs
            //READ COORDINATE.CS
            using(System.IO.StreamReader sr = new System.IO.StreamReader("cor.prjlib"))
            {
                string line;
                int j = 0;
                while ((line = sr.ReadLine())!=null)
                {
                    code_lib[j] = line;
                    j++;
                }
            }

            //string main_func = "class Program\n{ static void Main()\n{ export();\n} \n}";


            //List<List<string>> list_pb = new List<List<string>>();
            List<string> pre_pb = new List<string>();
            List<string> pre_works = new List<string>();
            string create_c_works = "List<coordinate.work> c_work = new List<coordinate.work>();";
            string create_pb_s = "List<PictureBox> pb_s = new List<PictureBox>();";
            foreach (var item in pb_)
            {
                pre_pb.Add("\n{\n" + create_pb(item.Location.X,
                    item.Location.Y, item.ImageLocation, item.Name) +
                    "pb_s.Add(pb); c_work.Add(new coordinate.work(pb));" + "\n}");
            }
            //map.object_ ob = new map.object_("Main()", new coordinate.work(pb_));
            // файлы 
            string code = null;            
            {
                for (int i = 0; i < path_code_base.Count; i++)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(path_code_base[i]);
                    string line;
                    int j = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        code += line;
                        j++;
                    }
                }
            }
            // общая сборка
            List<string> all_code = new List<string>();
            all_code.Add(export_code[0]);
            all_code.Add("public work_in()\n{");
            all_code.Add(create_c_works);
            all_code.Add(create_pb_s);
            foreach (var item in pre_works)
            {
                all_code.Add(item);
            }
            foreach (var item in pre_pb)
            {
                all_code.Add(item);
            }
            for (int i = 1; i < code_lib.Length - 2; i++)
            {
                all_code.Add(code_lib[i]);
            }
            all_code.Add("}");
            all_code.Add(code);
            all_code.Add(code_lib[code_lib.Length - 1]);
            System.IO.StreamWriter sw = new System.IO.StreamWriter("game.cs");            
            TimerCallback tm = new TimerCallback(Frame);
            System.Threading.Timer timer = new System.Threading.Timer(tm, null, 0, 20);
            //test del up
            string update_ = "";

            for (int ky = 0; ky < all_code.Count; ky++)
            {
                string str = all_code[ky];
                for (int ty = 0; ty < str.Length; ty++)
                {
                    sw.Write(str[ty]);
                }
            }
        }
        string create_pb(int x, int y, string item_location, string name)
        {
            return "PictureBox pb = new PictureBox();\n" +
                "pb.Location.X = "+x.ToString()+";\n"+
                "pb.Location.Y = "+y.ToString()+";\n"+
                "pb.Name = "+Name+";\n"+
                "pb.ImageLocation = "+item_location+";";
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
            //f_.code_ = code;
            f_.Show();
            f_.Disposed += F__Disposed;            
        }

        private void F__Disposed(object sender, EventArgs e)
        {
            path_code_base.Add((sender as module_form).path);
        }
    }
}
