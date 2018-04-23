using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tank_367_form.ver1._6_pre_beta
{
    public class data
    {
        private bool connect { get; set; }
        private byte[] data_ { get; set; }
        private int err_code { get; set; }
        private string err_text { get; set; }

        public data(bool connect_, byte[] data__,
            int err_code_, string err_text_)
        {
            connect = connect_;
            data_ = data__;
            err_code = err_code_;
            err_text = err_text_;            
        }

        internal byte[] buf()
        {
            return data_;
        }
    }
    public class utp
    {
        private int port { get; set; }
        private string ip { get; set; }
        //-----------------------
        private int local_port;
        private string local_ip;

        private UdpClient connection;
        private UdpClient client;
        public utp(int port_, 
            string ip_)
        {
            port = port_;
            ip = ip_;
            client = new UdpClient(ip, port);            
            EndPoint f = client.Client.LocalEndPoint;
            var addrs = f.ToString();
            local_port = Convert.ToInt32(addrs.Split(':')[1]);
            /*connection = new UdpClient(local_port);
            local_ip = "127.0.0.1"; */
        }

        internal string[] get_addr_port()
        {
            string[] arg_r = new string[2];
            arg_r[0] = ip;
            arg_r[1] = port.ToString();

            return arg_r;
        }
        internal void set_local_ip(string ip_)
        {
            local_ip = ip_;
        }
        internal string ret_local_ip()
        {
            return local_ip;
        }
        internal void set_local_port(int port_)
        {
            local_port = port_;
            connection = new UdpClient(local_port);
        }
        internal int ret_local_port()
        {
            return local_port;
        }

        // доверительное управление под процент зарабатывать на битке

        /// <summary>
        /// Из девяти байтов доступно всего 7
        /// </summary> 
        /// <returns>Данные в формате класса</returns>
        internal data recv_9byte()
        {
            IPEndPoint end = (IPEndPoint) client.Client.LocalEndPoint;
            byte[] mes = client.Receive(ref end);
            if ((Convert.ToInt32(mes[1]) 
                + Convert.ToInt32(mes[0])
                    == Convert.ToInt32(mes[mes.Length - 1])) 
                && (mes[mes.Length - 1] == 101))
                    return new data(true, mes, 0, "all ok!");
            return new data(false, mes, 404, "bad connect");
        }
        internal data send_9byte(data d)
        {
            byte[] buf = d.buf();
            if (Convert.ToInt32(buf[1])
                + Convert.ToInt32(buf[0]) != 101)
            {                
                buf[0] = Convert.ToByte(Convert.ToInt32(101) - Convert.ToInt32(buf[1]));
            }
            try
            {
                client.Send(buf, buf.Length);
                
                return new data(true, buf, 0, "all ok!");
            }
            catch { }
            return new data(false, d.buf(), 405, "don't send message");
        }
        internal void close_connection()
        {
            connection.Close();
            client.Close();
        }
    }
}