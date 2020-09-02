using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FANUC
{
    public partial class handle : Form
    {
        public handle()
        {
            InitializeComponent();
        }

        private void btnConc_Click(object sender, EventArgs e)
        {
            string ip = txtIp.Text;
            string port = txtPort.Text;
            string timeout = txtTimeOut.Text;
            int ret = Fanuc.cnc_allclibhndl3(ip, Convert.ToUInt16(port), Convert.ToInt32(timeout), out Fanuc.h);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("连接成功！");
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ret = Fanuc.cnc_freelibhndl(Fanuc.h);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("断开连接成功！");
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string timeout = textBox1.Text;
            int ret = Fanuc.cnc_settimeout(Fanuc.h, Convert.ToInt32(timeout));
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("设置超时成功！");
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }
    }
}
