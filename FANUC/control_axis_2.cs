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
    public partial class control_axis_2 : Form
    {
        public control_axis_2()
        {
            InitializeComponent();
        }
        Fanuc.ODBSPEED speed = new Focas1.ODBSPEED();
        public void duqu_sudu()//读取速度信息
        {

            short ret = Fanuc.cnc_rdspeed(Fanuc.h, -1, speed);
            if (ret == 0)
            {
                listBox1.Items.Add(speed.actf.name + "   " + speed.actf.data + "   " + speed.actf.suff + " " + speed.actf.unit + "  " + speed.actf.disp);
                listBox1.Items.Add(speed.acts.name + "   " + speed.acts.data + "   " + speed.acts.suff);
            }


        }
        Fanuc.ODBAXIS axis = new Focas1.ODBAXIS();
        public void get_skip()//读取轴跳过的位置
        {
            short ret = Fanuc.cnc_skip(Fanuc.h, 1, 8, axis);
            if (ret == 0)
            {
                listBox1.Items.Add("跳过的距离：" + axis.data[0]);
            }
            else
                MessageBox.Show(ret+" ");

        }
        public void serve_delay()//伺服延迟
        {
            short ret = Fanuc.cnc_srvdelay(Fanuc.h, 1, 8, axis);
            if (ret == 0)
            {
                listBox1.Items.Add("伺服延迟值：" + axis.data[0]);
            }
            else
                MessageBox.Show(ret+" ");

        }
        public void add_delay()//加速和减速延迟
        {
            short ret = Fanuc.cnc_accdecdly(Fanuc.h, 1, 8, axis);
            if (ret == 0)
            {
                listBox3.Items.Add("加速减速的延迟值：" + axis.data[0]);
            }
            else
                MessageBox.Show(ret+" ");

        }
        Fanuc.ODBDY2_1 c = new Focas1.ODBDY2_1();//动态信息显示
        public void dynatic()//读取动态的数据的函数
        {
            short ret = Fanuc.cnc_rddynamic2(Fanuc.h, 2, 28 + 4 * 4 * 1, c);
            if (ret == 0)
            {
                listBox4.Items.Add("进给速率" + c.actf);
                listBox4.Items.Add("主轴速率" + c.acts);
                listBox4.Items.Add("警报" + c.alarm);
                listBox4.Items.Add("轴的数量" + c.axis);
                listBox4.Items.Add("可能用" + c.dummy);
                listBox4.Items.Add("绝对 位置：" + c.pos.absolute[0] + c.pos.absolute[1]);
                listBox4.Items.Add("相对 位置：" + c.pos.relative[0] + c.pos.relative[1]);
                listBox4.Items.Add("机器 位置：" + c.pos.machine[0] + c.pos.machine[1]);
                listBox4.Items.Add("剩余 位置：" + c.pos.distance[0] + c.pos.distance[1]);
                listBox4.Items.Add("当前的程序" + c.prgmnum);
                listBox4.Items.Add("主要的程序：" + c.prgmnum);
                listBox4.Items.Add("顺序号：" + c.seqnum);
            }
            else
            {
                MessageBox.Show(ret+" ");
            }

        }//动态数据

        private void button4_Click(object sender, EventArgs e)
        {
            dynatic();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            get_skip();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serve_delay();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add_delay();
        }
    }
}
