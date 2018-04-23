using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Windows.Forms;
//----------------------------|
using coordinate;//           |
//----------------------------|

namespace Tank_367_form.ver1._6_pre_beta
{
    class Program
    {
        public static bool utp = true;
        public static string ip_port;
        public static int port_server;
        private static utp client_;
        public static utp get_client()
        {
            return client_;
        }
        private static WebSocket socket;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* map.object_ ob = new map.object_("my",
                new work(new PictureBox()), new work(new PictureBox()),
                new work(new PictureBox()), new work(new PictureBox())
                , new work(new PictureBox()), 1, 2);
            ob.on_left(r);
            ob.on_right(r);
            ob.on_top(r);
            ob.on_bottom(r); */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            Application.Run(new game_ninja());
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new start_form());
            if (utp)
            {
                int port = 0;
                string ip = null;
                var r = ip_port.Split(':');
                ip = r[0];
                port = Convert.ToInt32(r[1]);
                client_ = new utp(port, ip);
                byte[] b = new byte[9];
                b[8] = 101;
                client_.send_9byte(new data(true, b, 0, ""));
                client_.send_9byte(new data(true, b, 0, ""));
                client_.recv_9byte();

                //client_.set_local_port(port_server);
                //utp u = client_;
                //u.send_9byte(new data(true, new byte[9], 0, ""));
                */
            //  работает коннект и т.д. ;)
            //    }
            // Application.Run(new Form1());
            /*utp t = new utp(870, "127.0.0.1");            
            t.set_local_ip("127.0.0.1");
            t.set_local_port(8090);
            byte[] b = new byte[9];
            b[1] = 1; b[2] = 1; b[3] = 4; b[5] = 4; b[6] = 4; b[7] = 4; b[8] = 101;
            
            t.send_9byte(new data(true, b, 0, "all ok!"));
            while (true)
            {
                System.Threading.Thread.Sleep(800);
            }*/
        }
        private static int r() { return 0; }
    }
}
