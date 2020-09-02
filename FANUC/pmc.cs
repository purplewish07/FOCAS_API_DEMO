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

namespace FANUC
{
    public partial class pmc : Form
    {
        public pmc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Specify the identification code corresponding to the kind of the PMC address
            //Specify the type of the PMC data.
            //Specify the start PMC address number. 
            //Specify the end PMC address number. 
            //Specify the data block length. 
            short a = 0, b = 0;//a=0读g地址
            ushort start = Convert.ToUInt16(textBox4.Text), end = Convert.ToUInt16(textBox3.Text);
            ushort f = 0;
            ushort N = (ushort)(end - start + 1);
            //data_type is 0(byte type) : length = 8 + N 
            //data_type is 1(word type) : length = 8 + N × 2 
            //data_type is 2(long type) : length = 8 + N × 4 
            switch (b)
            {
                case 0:
                    f = (ushort)(8 + N);
                    break;
                case 1:
                    f = (ushort)(8 + N * 2);
                    break;
                case 2:
                    f = (ushort)(8 + N * 4);
                    break;
            }
            //public short   type_a ;    /* PMC address type */ /* Kind of PMC address */
            //public short   type_d ;    /* PMC data type */ /* Type of the PMC data */
            Fanuc.IODBPMC0 iodbpmc0 = new Focas1.IODBPMC0();//byte
            Fanuc.IODBPMC1 iodbpmc1 = new Focas1.IODBPMC1();//short
            Fanuc.IODBPMC2 iodbpmc2 = new Focas1.IODBPMC2();//int
            int ret = Fanuc.pmc_rdpmcrng(Fanuc.h, a, b, start, end, f, iodbpmc0);
            //ret = Fanuc.pmc_rdpmcrng(Fanuc.h, a, b, c, d, f, iodbpmc1);
            //ret = Fanuc.pmc_rdpmcrng(Fanuc.h, a, b, c, d, f, iodbpmc2);
            if (ret == Fanuc.EW_OK)
            {
                //直接读取内部数据，结构之外的参数为输入参数
                listBox1.Items.Clear();
                listBox1.Items.Add("地址 |PMC信号状态（16进制）");
                byte[] data = iodbpmc0.cdata;
                int j = 0;
                for (ushort i = start; i < end; i++, j++)
                {
                    string add = Fanuc.getpmcadd(iodbpmc0.type_a, i);
                    string value = "0X" + Convert.ToString(data[j], 16).ToString().PadLeft(2, '0').ToUpper();
                    listBox1.Items.Add(add + "|" + value);
                }
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Specify the kind of PMC address. 

            short a = -1;
            Fanuc.ODBPMCINF odbpmcinf = new Focas1.ODBPMCINF();
            int ret = Fanuc.pmc_rdpmcinfo(Fanuc.h, a, odbpmcinf);
            if (ret == Fanuc.EW_OK)
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("地址|开始|结束|属性");
                short datano = odbpmcinf.datano;
                Fanuc.ODBPMCINF1 odbpmcinf1 = odbpmcinf.info;
                string temp = "";

                for (short i = 0 + 1; i < datano + 1; i++)
                {
                    temp = "info" + i;
                    string pmcadr = Help.getfield(Help.getfield(odbpmcinf1, temp), "pmc_adr").ToString();
                    string topnum = Help.getfield(Help.getfield(odbpmcinf1, temp), "top_num").ToString();
                    string lastnum = Help.getfield(Help.getfield(odbpmcinf1, temp), "last_num").ToString();
                    string adrattr = Help.getfield(Help.getfield(odbpmcinf1, temp), "adr_attr").ToString();
                    string buf = pmcadr.PadRight(4, ' ') + "|" + topnum.PadLeft(4, '0') + "|" + lastnum.PadLeft(4, '0') + "|" + adrattr;
                    listBox2.Items.Add(buf);

                }
                listBox2.Items.Add("合计：" + datano);
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //提示数据长度错误，但是对象中没有相应的属性可以设置
            //Specify the type of the PMC data.
            ushort a = 8+5*2;//写入数据长度
            Fanuc.IODBPMC0 iodbpmc0 = new Focas1.IODBPMC0();
            iodbpmc0.datano_s = Convert.ToInt16(textBox4.Text);//开始位置
            iodbpmc0.datano_e = Convert.ToInt16(textBox3.Text);//结束位置
            iodbpmc0.type_a =0;//pmc地址类型  g 0
            iodbpmc0.type_d =0;//pmc数据类型  byte 0
            string[] data = textBox2.Text.Split(' ');
            byte[] buf = new byte[5];
            for (int i = 0; i < 5; i++)
            {
                buf[i] = Convert.ToByte(data[i], 16);
            }
            iodbpmc0.cdata = buf;
            int ret = Fanuc.pmc_wrpmcrng(Fanuc.h, a, iodbpmc0);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("写入成功！");
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        Tuple<int, short> pmc_get_timer_type(ushort start, ushort end)
        {
            //Specify the start PMC timer number
            //Specify the end PMC timer number
            //Specify the address of the array to store the timer type.
            short c = 0;
            int r = Fanuc.pmc_get_timer_type(Fanuc.h, start, end, ref c);
            return new Tuple<int, short>(r, c);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ushort start = Convert.ToUInt16(textBox6.Text), end = Convert.ToUInt16(textBox5.Text);
            Tuple<int, short> ret = pmc_get_timer_type(start, end);
            if (ret.Item1 == Fanuc.EW_OK)
            {
                string temp = ret.Item2 + "";
                textBox8.Text = temp;
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Specify the start PMC timer number
            //Specify the end PMC timer number
            //Specify the address of the array to store the timer type.
            ushort start = Convert.ToUInt16(textBox6.Text), end = Convert.ToUInt16(textBox5.Text);
            string temp = textBox8.Text;
            short c = Convert.ToInt16(temp);
            int ret = Fanuc.pmc_set_timer_type(Fanuc.h, start, end, ref c);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("设置成功！");
            }
            else
            {
                // PMC timer type(type) is wrong.可以继续查看具体错误的内容
                if (ret == 5)
                {
                    Fanuc.ODBPMCERR odmpmcerr = new Focas1.ODBPMCERR();
                    ret = Fanuc.pmc_getdtailerr(Fanuc.h, odmpmcerr);
                    if (ret == Fanuc.EW_OK)
                    {
                        //short err_no;         /* Detail error */
                        //short err_dtno;       /* Data number on error */
                        string buf = odmpmcerr.err_dtno + ";" + odmpmcerr.err_no;
                        MessageBox.Show(buf);
                    }
                    else
                    {
                        MessageBox.Show(ret + "n");
                    }
                }
                else
                {
                    MessageBox.Show(ret + "");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //Specify the pointer to an array of "long" where the "Unit Type" of each PMC path will be stored.
            //Specify the pointer where the number of elements of unittypes[] is stored.
            string temp = textBox9.Text;
            int b = Convert.ToInt32(temp);
            int[] a = new int[b];
            int ret = Fanuc.pmc_get_pmc_unit_types(Fanuc.h, a, ref b);
            if (ret == Fanuc.EW_OK)
            {
                for (int i = 0; i < b; i++)
                {
                    MessageBox.Show(a[i].ToString());
                }
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Specify the pointer that stores the number of PMC paths
            int a = 0;
            int ret = Fanuc.pmc_get_number_of_pmc(Fanuc.h, ref a);
            if (ret == Fanuc.EW_OK)
            {
                textBox9.Text = a.ToString();
            }
            else
            {
                MessageBox.Show(ret + "");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Gets the PMC unit type that is currently selected as the target of other PMC FOCAS2 functions.
            int a = 0;
            int ret = Fanuc.pmc_get_current_pmc_unit(Fanuc.h, ref  a);
            if (ret == Fanuc.EW_OK)
            {
                textBox7.Text = a.ToString();
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Specify the PMC unit type to be selected.
            int a = 0;
            int ret = Fanuc.pmc_select_pmc_unit(Fanuc.h, a);
            if (ret == Fanuc.EW_OK)
            {
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            //c
            //When 'read_num' is specified less than the actual number of PMC alarms occurred on PMC side, '1' is returned. 
            //-1  :  There is no alarm. 
            //0  :  All alarms were read. 
            //1  :  Alarm still exists. 
            short snumber = Convert.ToInt16(textBox10.Text), readnum = Convert.ToInt16(textBox11.Text), c;
            Fanuc.ODBPMCALM odnpmcalm = new Focas1.ODBPMCALM();
            int ret = Fanuc.pmc_rdalmmsg(Fanuc.h, snumber, ref readnum, out c, odnpmcalm);
            string buf = "";
            string data = "";
            if (ret == Fanuc.EW_OK)
            {
                for (int i = 1; i < readnum + 1; i++)
                {
                    buf = "msg" + i;
                    data = Help.getfield(Help.getfield(odnpmcalm, buf), "almmsg").ToString();
                    listBox3.Items.Add(data);
                }
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Fanuc.ODBPMCTITLE odbpmctitle = new Focas1.ODBPMCTITLE();
            int ret = Fanuc.pmc_rdpmctitle(Fanuc.h, odbpmctitle);
            if (ret == Fanuc.EW_OK)
            {
                //char    mtb[48];       /* MACHINE TOOL BUILDER NAME */
                //char    machine[48];   /* MACHINE TOOL NAME */
                //char    type[48];      /* NC & PMC TYPE NAME */
                //char    prgno[8];      /* PMC PROGRAM NO. */
                //char    prgvers[4];    /* EDITION NO. */
                //char    prgdraw[48];   /* ROGRAM DRAWING NO. */
                //char    date[32];      /* DATE OF PROGRAMIN */
                //char    design[48];    /* PROGRAM DESIGNED BY */
                //char    written[48];   /* ROM WRITTEN BY */
                //char    remarks[48];   /* REMARKS */
                string data = odbpmctitle.date;
                string design = odbpmctitle.design;
                string machine = odbpmctitle.machine;
                string mtb = odbpmctitle.mtb;
                string prgdraw = odbpmctitle.prgdraw;
                string prgno = odbpmctitle.prgno;
                string prgvers = odbpmctitle.prgvers;
                string remarks = odbpmctitle.remarks;
                string type = odbpmctitle.type;
                string written = odbpmctitle.written;

                textBox12.Text = mtb;
                textBox13.Text = machine;
                textBox14.Text = type;
                textBox15.Text = prgno;
                textBox20.Text = prgvers;
                textBox17.Text = prgdraw;
                textBox18.Text = data;
                textBox19.Text = design;
                textBox16.Text = written;
                textBox21.Text = remarks;
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }









    }
}
