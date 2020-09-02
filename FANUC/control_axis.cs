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
    public partial class control_axis : Form
    {
        public control_axis()
        {
            InitializeComponent();
        }
        Fanuc.ODBPOS fos = new Focas1.ODBPOS();
        private void duqu_position_rel_info()//读取相对的位置信息
        {
            short num = Fanuc.MAX_AXIS;
            short type = -1; ;
            short ret = Fanuc.cnc_rdposition(Fanuc.h, type, ref num, fos);
            if (ret == 0)
            {
                listBox1.Items.Add(fos.p1.rel.name.ToString() + ":  " + fos.p1.rel.data * Math.Pow(10, -fos.p1.rel.dec));
                listBox1.Items.Add(fos.p2.rel.name.ToString() + ":  " + fos.p2.rel.data * Math.Pow(10, -fos.p2.rel.dec));
                listBox1.Items.Add(fos.p3.rel.name.ToString() + ":  " + fos.p3.rel.data * Math.Pow(10, -fos.p3.rel.dec));
                listBox2.Items.Add(fos.p1.dist.name.ToString() + ":  " + fos.p1.dist.data * Math.Pow(10, -fos.p1.dist.dec));
                listBox2.Items.Add(fos.p2.dist.name.ToString() + ":  " + fos.p2.dist.data * Math.Pow(10, -fos.p2.dist.dec));
                listBox2.Items.Add(fos.p3.dist.name.ToString() + ":  " + fos.p3.dist.data * Math.Pow(10, -fos.p3.dist.dec));
            }
        }
        public void duqu_position_ab_info()//获取绝对位置信息
        {
            short num = Fanuc.MAX_AXIS;
            short type = -1; ;
            short ret = Fanuc.cnc_rdposition(Fanuc.h, type, ref num, fos);
            if (ret == 0)
            {
                listBox8.Items.Add(fos.p1.abs.name.ToString() + ":  " + fos.p1.abs.data * Math.Pow(10, -fos.p1.abs.dec));
                listBox8.Items.Add(fos.p2.abs.name.ToString() + ":  " + fos.p2.abs.data * Math.Pow(10, -fos.p2.abs.dec));
                listBox8.Items.Add(fos.p3.abs.name.ToString() + ":  " + fos.p3.abs.data * Math.Pow(10, -fos.p3.abs.dec));
                listBox7.Items.Add(fos.p1.dist.name.ToString() + ":  " + fos.p1.dist.data * Math.Pow(10, -fos.p1.dist.dec));
                listBox7.Items.Add(fos.p2.dist.name.ToString() + ":  " + fos.p2.dist.data * Math.Pow(10, -fos.p2.dist.dec));
                listBox7.Items.Add(fos.p3.dist.name.ToString() + ":  " + fos.p3.dist.data * Math.Pow(10, -fos.p3.dist.dec));
            }


        }
        public void get_postion()//获取位置信息
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            short num = Fanuc.MAX_AXIS;
            short type = -1;
            short ret = Fanuc.cnc_rdposition(Fanuc.h, type, ref num, fos);
            if (ret == 0)
            {
                //绝对
                listBox3.Items.Add(fos.p1.abs.name.ToString() + ":  " + fos.p1.abs.data * Math.Pow(10, -fos.p1.abs.dec));
                listBox3.Items.Add(fos.p2.abs.name.ToString() + ":  " + fos.p2.abs.data * Math.Pow(10, -fos.p2.abs.dec));
                listBox3.Items.Add(fos.p3.abs.name.ToString() + ":  " + fos.p3.abs.data * Math.Pow(10, -fos.p3.abs.dec));
                listBox3.Items.Add(fos.p4.abs.name.ToString() + ":  " + fos.p4.abs.data * Math.Pow(10, -fos.p3.abs.dec));
                listBox3.Items.Add(fos.p5.abs.name.ToString() + ":  " + fos.p5.abs.data * Math.Pow(10, -fos.p5.abs.dec));
                //相对
                listBox4.Items.Add(fos.p1.rel.name.ToString() + ":  " + fos.p1.rel.data * Math.Pow(10, -fos.p1.rel.dec));
                listBox4.Items.Add(fos.p2.rel.name.ToString() + ":  " + fos.p2.rel.data * Math.Pow(10, -fos.p2.rel.dec));
                listBox4.Items.Add(fos.p3.rel.name.ToString() + ":  " + fos.p3.rel.data * Math.Pow(10, -fos.p3.rel.dec));
                listBox4.Items.Add(fos.p4.rel.name.ToString() + ":  " + fos.p4.rel.data * Math.Pow(10, -fos.p4.rel.dec));
                listBox4.Items.Add(fos.p5.rel.name.ToString() + ":  " + fos.p5.rel.data * Math.Pow(10, -fos.p5.rel.dec));
                //机器
                listBox5.Items.Add(fos.p1.mach.name.ToString() + ":  " + fos.p1.mach.data * Math.Pow(10, -fos.p1.mach.dec));
                listBox5.Items.Add(fos.p2.mach.name.ToString() + ":  " + fos.p2.mach.data * Math.Pow(10, -fos.p2.mach.dec));
                listBox5.Items.Add(fos.p3.mach.name.ToString() + ":  " + fos.p3.mach.data * Math.Pow(10, -fos.p3.mach.dec));
                listBox5.Items.Add(fos.p4.mach.name.ToString() + ":  " + fos.p4.mach.data * Math.Pow(10, -fos.p4.mach.dec));
                listBox5.Items.Add(fos.p5.mach.name.ToString() + ":  " + fos.p5.mach.data * Math.Pow(10, -fos.p5.mach.dec));
                //距离
                listBox6.Items.Add(fos.p1.dist.name.ToString() + ":  " + fos.p1.dist.data * Math.Pow(10, -fos.p1.dist.dec));
                listBox6.Items.Add(fos.p2.dist.name.ToString() + ":  " + fos.p2.dist.data * Math.Pow(10, -fos.p2.dist.dec));
                listBox6.Items.Add(fos.p3.dist.name.ToString() + ":  " + fos.p3.dist.data * Math.Pow(10, -fos.p3.dist.dec));
                listBox6.Items.Add(fos.p4.dist.name.ToString() + ":  " + fos.p3.dist.data * Math.Pow(10, -fos.p4.dist.dec));
                listBox6.Items.Add(fos.p5.dist.name.ToString() + ":  " + fos.p5.dist.data * Math.Pow(10, -fos.p5.dist.dec));

            }
        }
        Fanuc.ODBACT pindle = new Focas1.ODBACT();
        public void get_pindle()//获取主轴的速度
        {
            short ret = Fanuc.cnc_acts(Fanuc.h, pindle);
            if (ret == 0)
            {
                label5.Text = pindle.data.ToString();
            }
            else
            {
                MessageBox.Show(ret+"");
            }
        }
        Fanuc.ODBSVLOAD sv = new Focas1.ODBSVLOAD();
        Fanuc.ODBSPLOAD sp = new Focas1.ODBSPLOAD();
        public void get_load()//主，伺服轴的加载计//测试成功
        {
            short a = 6;//伺服轴的数量
            short ret = Fanuc.cnc_rdsvmeter(Fanuc.h, ref a, sv);
            short type = Convert.ToInt16(textBox1.Text);//1朱轴压力,-1俩者都有,0主轴监控速度表
            short ret2 = Fanuc.cnc_rdspmeter(Fanuc.h, type, ref a, sp);
            if (ret == 0 && ret2 == 0)
            {
                listBox9.Items.Add("伺服的加载值：" + sv.svload1.data + "  " + sv.svload2.data + "  " + sv.svload3.data + " ");
                listBox9.Items.Add("主轴的加载值：" + sp.spload1.spload.data);
            }
            else
                MessageBox.Show(ret+"");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            duqu_position_rel_info();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            duqu_position_ab_info();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            get_postion();
            get_pindle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_load();
        }
    }
}
