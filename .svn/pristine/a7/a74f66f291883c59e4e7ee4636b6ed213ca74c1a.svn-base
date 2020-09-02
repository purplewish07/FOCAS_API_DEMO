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
    public partial class para : Form
    {
        public para()
        {
            InitializeComponent();
        }
        public void writepara_value()//写入参数的值，已测试
        {
            psd_2.datano = Convert.ToInt16(txt_para.Text);
            psd_2.type = 0;
            psd_2.rdata.prm_val = Convert.ToInt16(txt_data.Text);
            psd_2.rdata.dec_val = 0;

            short ret2 = Fanuc.cnc_wrparam(Fanuc.h, 8, psd_2);
            if (ret2 == Fanuc.EW_OK)
            {
                MessageBox.Show("写入参数成功", "提示");
            }
            else
            {
                if (ret2 == 3)
                    MessageBox.Show("机器中的参数可能未设置或没有，请从填");
                else
                    MessageBox.Show(ret2 + "  ");
               
            }

        }
        Fanuc.IODBPSD_2 psd_2 = new Focas1.IODBPSD_2();//设置参数里的值；
        Fanuc.IODBPSD_1 psd_1 = new Focas1.IODBPSD_1();
        public void rd_para()//duqu 参数号内的值，已测试
        {
            short number = Convert.ToInt16(txt_para.Text);
            short ret = Fanuc.cnc_rdparam(Fanuc.h, number, Fanuc.ALL_AXES, 4 + 4 * Fanuc.MAX_AXIS, psd_1);
            if (ret == Fanuc.EW_OK)
            {
                listBox1.Items.Add(psd_1.cdata.ToString());
                listBox1.Items.Add(psd_1.type.ToString());
                listBox1.Items.Add(psd_1.datano.ToString());
                MessageBox.Show("读取参数成功");
            }
            else
            {
                if (ret == 3)
                     MessageBox.Show("机器中的参数可能未设置或没有，请从填");
                else
                    MessageBox.Show(ret + "  ");
               
            }

        }
        public void get_hong()//读取宏变量的数值
        {
            short number = Convert.ToInt16(txt_hong.Text.ToString());
            short ret = Fanuc.cnc_rdmacro(Fanuc.h, number, 10, odbm);

            if (ret == Fanuc.EW_OK)
            {
                listBox3.Items.Add(odbm.datano.ToString());
                listBox3.Items.Add(odbm.dummy.ToString());
                listBox3.Items.Add(odbm.dec_val.ToString());
                listBox3.Items.Add(odbm.mcr_val.ToString());
                listBox3.Items.Add((Math.Pow(10, -odbm.dec_val) * odbm.mcr_val).ToString());
                listBox3.Items.Add(txt_hong.Text.ToString());
                MessageBox.Show("写入参数成功");
            }
            else
            {
                MessageBox.Show(ret+" ");
            }

        }
        Fanuc.ODBM odbm = new Focas1.ODBM();//宏类
        Fanuc.IODBPI pitch = new Focas1.IODBPI();
        public void rdpitchr()//读取螺距误差补偿数据//成功测试
        {
            short start = Convert.ToInt16(textBox1.Text);//开始的编号；
            short end = Convert.ToInt16(textBox2.Text);//结束的偏号
            short length = (short)(6 + end - start + 1);
            if (length > 11)
                MessageBox.Show("数据不符合");
            else
            {
            short a = 80;
            Fanuc.cnc_rdpitchinfo(Fanuc.h, out a);
            short ret = Fanuc.cnc_rdpitchr(Fanuc.h, start, end, length, pitch);
            if (ret == 0)
            {
                MessageBox.Show("成功读取");
                for (short idx = 0; idx < end - start + 1; idx++)
                {
                    listBox4.Items.Add(pitch.datano_s.ToString());
                    listBox4.Items.Add(pitch.datano_e.ToString());
                    listBox4.Items.Add(pitch.dummy);
                    string result = (idx + start).ToString() + "  " + pitch.data[idx].ToString();
                    listBox4.Items.Add("螺距误差：" + result);
                }
                
            }
            }
        }
        Fanuc.ODBTLINF inf = new Focas1.ODBTLINF();
        Fanuc.ODBTOFS tof = new Focas1.ODBTOFS();
        public void get_tool_offset()//读取刀补值
        {

            Fanuc.cnc_rdtofsinfo(Fanuc.h, inf);
            short a = inf.use_no;
            short b = inf.ofs_type;
            short ret = Fanuc.cnc_rdtofs(Fanuc.h, a, b, 8, tof);
            if (ret == 0)
            {
                listBox1.Items.Add("刀补值" + tof.data);
            }
            else
                MessageBox.Show(ret+" ");


        }



        Fanuc.IODBWCSF wcsf = new Focas1.IODBWCSF();
        Fanuc.IODBZOFS zofs = new Focas1.IODBZOFS();
        public void get_zofs()//读取工作零点的偏移值
        {
            short a=4;//此变量的值得取法，详细看api
            short b=-1;//指定的轴数号，-1，表示所有
            short length=4+4*Fanuc.MAX_AXIS;
            short ret=Fanuc.cnc_rdzofs(Fanuc.h, 1, b, length, zofs);
            if (ret == 0)
            {
                for (int i = 0; i < Fanuc.MAX_AXIS; i++)
                {
                    listBox1.Items.Add(zofs.data[i]);
                }
            }

 
        }
        public void wr_zofs()//写入工作零点的偏移值
        {
            zofs.datano=1;//详细看api
            zofs.type=-1;//表示轴号
            for(int i=0;i<Fanuc.MAX_AXIS;i++)
                zofs.data[i]=2;

            short ret=Fanuc.cnc_wrzofs(Fanuc.h, 4 + 4 * Fanuc.MAX_AXIS, zofs);
            if (ret == 0)
                MessageBox.Show("写入成功");

        }


        public void duqu_zuobiaoyidong()//坐标移动的值
        {
            short a = 10;
            short b = 20;
            short ret = Fanuc.cnc_rdwkcdshft(Fanuc.h, a, b, wcsf);
            if (ret == 0)
            {
                for (int i = 0; i < wcsf.data.Length; i++)

                    listBox1.Items.Add(wcsf.data[i]);
            }
            else
            {
                MessageBox.Show(ret+" ");
            }

        }
        public void write_zuobiaoyidong()//写入移动的值
        {
            wcsf.type=-1;//所有轴
            for (int i = 0; i < Fanuc.MAX_AXIS; i++)
                wcsf.data[i] = 2;
            short ret = Fanuc.cnc_wrwkcdshft(Fanuc.h, 4+4*Fanuc.MAX_AXIS, wcsf);
            if (ret == 0)
            {
                MessageBox.Show("写入成功");
            }
            else
            {
                MessageBox.Show(ret + " ");
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            rd_para();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writepara_value();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get_hong();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rdpitchr();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            get_tool_offset();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            duqu_zuobiaoyidong();
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
