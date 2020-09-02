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
    public partial class tool_life_manage : Form
    {
        public tool_life_manage()
        {
            InitializeComponent();
        }
        Fanuc.ODBTLIFE5 tool = new Focas1.ODBTLIFE5();//读取刀片组的序号
        Fanuc.ODBTLIFE2 tool1 = new Focas1.ODBTLIFE2();//读取刀片组的全部数量
        Fanuc.ODBTLIFE3 tool2 = new Focas1.ODBTLIFE3();//刀具的数量
        Fanuc.ODBTLIFE4 life = new Focas1.ODBTLIFE4();
        Fanuc.ODBTG btg = new Focas1.ODBTG();
        Fanuc.ODBUSEGRP grp = new Focas1.ODBUSEGRP();
       
        public void get_grp_info()//获得刀具组的信息
        {
            short start=1;//开始的刀具组
            short end=3;//结束的刀具组
            short length=Convert.ToInt16(8+16*(end-start));//
            short ret=Fanuc.cnc_rdgrpinfo(Fanuc.h, start, end, length, btgi);
            if (ret == 0)
            {
                listBox1.Items.Add(btgi.data.data1.count_value);
            }
 
        }
        public void get_tool_life()//读取获得刀片的有关信息
        {
            int m = 2;
            Fanuc.cnc_rdgrpid2(Fanuc.h, m, tool);
            int group_numer = tool.data;
            int all = Fanuc.cnc_rdngrp(Fanuc.h, tool1);//刀片组的全部数量
            short b = Convert.ToInt16(group_numer);
            Fanuc.cnc_rdntool(Fanuc.h, b, tool2);//刀具的数量
            Fanuc.cnc_rdlife(Fanuc.h, b, tool2);//刀具寿命
            Fanuc.cnc_rdcount(Fanuc.h, b, tool2);//刀具计时器
            Fanuc.cnc_rdtoolgrp(Fanuc.h, 2, 20 + 20 * 1, btg);//根据刀组号读出所有信息，很重要；
            Fanuc.cnc_rdtlusegrp(Fanuc.h, grp);//读出正在使用的到组号；
            listBox10.Items.Add("刀片组号：" + group_numer);
            listBox10.Items.Add("type:" + tool.type);
            listBox10.Items.Add("刀片组的全部数量" + all);
            listBox10.Items.Add("刀片号：" + tool2.data);
            listBox10.Items.Add("刀片组号;" + group_numer + "   寿命：" + tool2.data);
            listBox10.Items.Add("刀片组号;" + group_numer + "   寿命计时：" + tool2.data);
        }
        Fanuc.IODBTGI btgi = new Focas1.IODBTGI();
        public void set_tool_life()//设置刀具
        {
            btgi.data.data1.counter = 13;
            btgi.data.data1.count_type = 0;
            btgi.data.data1.count_value = 14;
            short ret=Fanuc.cnc_wrgrpinfo(Fanuc.h, 8 + 16 * 2, btgi);
            if (ret == 0)
            {
                MessageBox.Show("写入成功");
 
            }
        }
        public void get_cutter_cpn()//获得正在运行的刀具的寿命
        {
            Fanuc.cnc_rdtlusegrp(Fanuc.h, grp);
            short a = Convert.ToInt16(grp.use);
            if (a == 0)
                MessageBox.Show("没有刀具在运行");
            else
            {
                short ret = Fanuc.cnc_rdtoolgrp(Fanuc.h, a, 20 + 20 * 1, btg);
                if (ret == 0)
                {
                    listBox10.Items.Add("正在运行的刀片组号;" + a + "   寿命：" + btg.life.ToString() + "  次数：" + btg.count.ToString());
                    listBox10.Items.Add("正在运行的刀片号;" + btg.data.data1.tool_num + "   半径补偿：" + btg.data.data1.radius_num);
                }
                else
                    MessageBox.Show(ret+" ");

            }

        }
        public void delete_tool_group()//删除刀具组
        {
            if(textBox1.Text==null)
            { 
                MessageBox.Show("请输入组号");
            }
            else
            {
            short a=Convert.ToInt16(textBox1.Text);
            Fanuc.cnc_deltlifegrp(Fanuc.h, a);
            }
        }
        Fanuc.IDBITD bitd=new Focas1.IDBITD ();
        public void insert_tool()//插入刀具
        {
            bitd.datano = 1;//刀组号
            bitd.type = 2;//刀具所在的序列号
            bitd.data = 3;//刀具名；
            short ret=Fanuc.cnc_instlifedt(Fanuc.h, bitd);
            if (ret == 0)
                MessageBox.Show("成功插入刀具");
        }
        public void delete_tool()//删除指定的刀组的刀具号
        {
            short a = 1;//组号
            short b = 2;//刀号
            Fanuc.cnc_deltlifedt(Fanuc.h, a, b);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            get_tool_life();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            get_cutter_cpn();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            set_tool_life();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete_tool(); 



        }
    }
}
