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
    public partial class historydata : Form
    {
        public historydata()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ret = Fanuc.cnc_stopophis(Fanuc.h);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ushort a;
            int ret = Fanuc.cnc_rdophisno(Fanuc.h, out a);
            if (ret == Fanuc.EW_OK)
            {
                textBox2.Text = a.ToString();
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ushort a;
            int ret = Fanuc.cnc_rdalmhisno(Fanuc.h, out a);
            if (ret == Fanuc.EW_OK)
            {
                textBox1.Text = a.ToString();
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //+11重载
            ushort a = 0, b = 0, c = 0;
            Fanuc.ODBOPHIS4_1 odbophis41 = new Focas1.ODBOPHIS4_1();
            int ret = Fanuc.cnc_rdophistry4(Fanuc.h, a, ref b, ref c, odbophis41);
            if (ret == Fanuc.EW_OK)
            { }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //从最历史的时间开始
            ushort a = Convert.ToUInt16(textBox3.Text), b = Convert.ToUInt16(textBox4.Text);//b-a<=9
            Fanuc.ODBAHIS5 odbahis5 = new Focas1.ODBAHIS5();
            int all = b - a + 1;
            ushort length = (ushort)((all) * 516 + 4);

            int ret = Fanuc.cnc_rdalmhistry5(Fanuc.h, a, b, length, odbahis5);
            if (ret == Fanuc.EW_OK)
            {
                ushort sno = odbahis5.s_no;
                ushort eno = odbahis5.e_no;

                Fanuc.ALM_HIS5 almhis5 = new Focas1.ALM_HIS5();
                almhis5 = odbahis5.alm_his;

                string time = "";
                string message = "";
                string almno = "";
                string almgrp = "";

                listBox1.Items.Clear();
                listBox1.Items.Add("时间               |错误码         |消息");
                for (int i = 1; i < all+1; i++)
                {
                    time = "";
                    object datao = Help.getfield(almhis5, "data" + i);
                    time += Help.getfield(datao, "year").ToString().PadLeft(4, '0');
                    time += "/";
                    time += Help.getfield(datao, "month").ToString().PadLeft(2, '0');
                    time += "/";
                    time += Help.getfield(datao, "day").ToString().PadLeft(2, '0');
                    time += " ";
                    time += Help.getfield(datao, "hour").ToString().PadLeft(2, '0');
                    time += ":";
                    time += Help.getfield(datao, "minute").ToString().PadLeft(2, '0');
                    time += ":";
                    time += Help.getfield(datao, "second").ToString().PadLeft(2, '0');
                    message = Help.getfield(datao, "alm_msg").ToString();
                    almgrp = Fanuc.getalmgrp(Convert.ToInt16(Help.getfield(datao, "alm_grp")));
                    almno = Help.getfield(datao, "alm_no").ToString().PadLeft(4, '0');
                    string temp = almgrp + almno;
                    listBox1.Items.Add(time + "|" + temp.PadRight(15,' ') + "|" + message);
                }
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ret = Fanuc.cnc_startophis(Fanuc.h);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            short a = 0;
            int ret = Fanuc.cnc_clearophis(Fanuc.h, a);
            if (ret == Fanuc.EW_OK)
            {
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Fanuc.IODBSIG3 iodbsig3 = new Focas1.IODBSIG3();
            int ret = Fanuc.cnc_rdhissgnl3(Fanuc.h, iodbsig3);
            if (ret == Fanuc.EW_OK)
            {
                Fanuc.IODBSIG3_data iodbsig3data = iodbsig3.data;
                short datano = iodbsig3.datano;
                short type = iodbsig3.type;
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Fanuc.IODBSIG3 iodbsig3 = new Focas1.IODBSIG3();
            int ret = Fanuc.cnc_wrhissgnl3(Fanuc.h, iodbsig3);
            if (ret == Fanuc.EW_OK)
            {
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
