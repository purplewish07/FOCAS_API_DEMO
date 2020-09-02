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
    public partial class PMCRW : Form
    {
        public PMCRW()
        {
            InitializeComponent();
        }

        Dictionary<int, String> pmcAddress = new Dictionary<int, string>();

        private void PMCRW_Load(object sender, EventArgs e)
        {
            pmcAddress.Add(0, "G");
            pmcAddress.Add(1, "F");
            pmcAddress.Add(2, "Y");
            pmcAddress.Add(3, "X");
            pmcAddress.Add(4, "A");
            pmcAddress.Add(5, "R");
            pmcAddress.Add(6, "T");
            pmcAddress.Add(7, "K");
            pmcAddress.Add(8, "C");
            pmcAddress.Add(9, "D");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 以10进制的形式向指定pmc中写值
        /// </summary>
        /// <param name="address"></param>
        /// <param name="oneData"></param>
        public void WriterPmc(string address, string oneData)
        {
            try
            {
                //提示数据长度错误，但是对象中没有相应的属性可以设置
                //Specify the type of the PMC data.
                string addressKindStr = address.Substring(0, 1);
                int addressKindInt = 0;
                int addressNo = int.Parse(address.Substring(1, 4).TrimStart('0') == "" ? "0" : address.Substring(1, 4).TrimStart('0'));
                for (int i = 0; i < pmcAddress.Keys.Count; i++)
                {
                    if (pmcAddress[i].ToString() == addressKindStr)
                    {
                        addressKindInt = i;
                        break;
                    }
                }
                ushort a = 8 + 2 * 1;
                Fanuc.IODBPMC0 iodbpmc0 = new Focas1.IODBPMC0();
                iodbpmc0.datano_s = Convert.ToInt16(addressNo);
                iodbpmc0.datano_e = Convert.ToInt16(addressNo + 1);
                iodbpmc0.type_a = Convert.ToInt16(addressKindInt);
                iodbpmc0.type_d = 0;
                string[] data = { oneData };
                byte[] buf = new byte[5];
                for (int i = 0; i < 1; i++)
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
            catch (Exception e)
            {
                MessageBox.Show("输入的内容错误，详细：" + e.ToString());
            }
        }

        /// <summary>
        /// 读取指定pmc地址的内容
        /// </summary>
        /// <param name="address"></param>
        public void ReadPmc(string address)
        {
            try
            {
                string addressKindStr = address.Substring(0, 1);
                int addressKindInt = 0;
                int addressNo = int.Parse(address.Substring(1, 4).TrimStart('0') == "" ? "0" : address.Substring(1, 4).TrimStart('0'));
                for (int i = 0; i < pmcAddress.Keys.Count; i++)
                {
                    if (pmcAddress[i].ToString() == addressKindStr)
                    {
                        addressKindInt = i;
                        break;
                    }
                }
                short a = Convert.ToInt16(addressKindInt);
                short b = 0;
                ushort start = Convert.ToUInt16(addressNo);
                ushort end = Convert.ToUInt16(addressNo + 1);
                ushort f = 0;
                ushort N = (ushort)(end - start + 1);
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
                Fanuc.IODBPMC0 iodbpmc0 = new Focas1.IODBPMC0();
                int ret = Fanuc.pmc_rdpmcrng(Fanuc.h, a, b, start, end, f, iodbpmc0);
                if (ret == Fanuc.EW_OK)
                {
                    byte[] data = iodbpmc0.cdata;
                    int j = 0;
                    for (ushort i = start; i < end; i++, j++)
                    {
                        string add = Fanuc.getpmcadd(iodbpmc0.type_a, i);
                        int value = Convert.ToInt32(Convert.ToString(data[j], 16).ToString());
                        string temp = Convert.ToString(value, 2).PadLeft(8, '0');
                        char[] chars = temp.ToCharArray();
           
                        textBox9.Text = chars[7].ToString();
                        textBox8.Text = chars[6].ToString();
                        textBox7.Text = chars[5].ToString();
                        textBox6.Text = chars[4].ToString();
                        textBox5.Text = chars[3].ToString();
                        textBox4.Text = chars[2].ToString();
                        textBox3.Text = chars[1].ToString();
                        textBox2.Text = chars[0].ToString();
                    }
                }
                else
                {
                    MessageBox.Show(ret + "");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("输入的地址错误，详细：" + e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadPmc(textBox1.Text.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string buf = textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text + textBox8.Text + textBox9.Text;
            buf = buf.TrimStart('0');
            WriterPmc(textBox1.Text.ToString(), Convert.ToInt32(buf, 2).ToString());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string buf = textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text + textBox8.Text + textBox9.Text;
            buf = buf.TrimStart('0');
            if (buf == "")
                buf = "0";
            WriterPmc(textBox1.Text.ToString(), Convert.ToInt32(buf, 2).ToString());
            ReadPmc(textBox1.Text.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ReadPmc(textBox1.Text.ToString());
        }
    }
}
