using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.IO;

namespace FANUC
{
    public partial class ncpro : Form
    {
        public ncpro()
        {
            InitializeComponent();
        }
        public void rdpdfDrive()
        {
            Fanuc.ODBPDFDRV odbpdfdrv = new Focas1.ODBPDFDRV();
            short ret = Fanuc.cnc_rdpdf_drive(Fanuc.h, odbpdfdrv);
            if (ret == Fanuc.EW_OK)
            {
                listBox1.Items.Clear();
                string sodbpdfdrv;
                short num = odbpdfdrv.max_num;//返回存储器的数量，最大不超过16
                listBox1.Items.Add("数量：" + num.ToString());
                System.Type type = odbpdfdrv.GetType();

                for (int i = 1; i < num + 1; i++)
                {
                    sodbpdfdrv = "drive" + i;
                    object obj = type.GetField(sodbpdfdrv).GetValue(odbpdfdrv);
                    listBox1.Items.Add(obj.ToString());
                }
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            rdpdfDrive();
        }
        //TODO 读取注册程序目录  
        public void rdProDir()
        {
            Fanuc.PRGDIR2 prgdir2 = new Focas1.PRGDIR2();
            //a:输出type     Specify the type of the program directory to read. 
            //0  :  "Program number" only 
            //1  :  "Program number" and "Comment" 
            //2  :  "Program number", "Comment" and "Program size" 
            short a = 2, b =Convert.ToInt16(textBox1.Text), c = 10;// b：指针开始位置 c：程序的总数量
            short ret = Fanuc.cnc_rdprogdir2(Fanuc.h, a, ref b, ref c, prgdir2);
            //dir1包含的数据number编号 length程序大小 comment注释
            if (ret == Fanuc.EW_OK)
            {
                string sprgdir2 = "dir";
                string sprgdir2_data = "number";
                string sprgdir2_data2 = "length";
                string sprgdir2_data3 = "comment";
                if (ret == Fanuc.EW_OK)
                {
                    //处理显示的数据
                    listcnc_rdprogdir2.Items.Clear();
                    listcnc_rdprogdir2.Items.Add("合计：" + c);
                    listcnc_rdprogdir2.Items.Add("程序号（个）|大小（Kbyte）|注释（）");
                    System.Type type = prgdir2.GetType();
                    for (int j = 1; j < c + 1; j++)
                    {
                        sprgdir2 = "dir" + j;
                        FieldInfo fieidinfo = type.GetField(sprgdir2);
                        object ob = fieidinfo.GetValue(prgdir2);
                        System.Type typeob = ob.GetType();

                        string ncNumber = typeob.GetField(sprgdir2_data).GetValue(ob).ToString().PadLeft(4, '0');
                        ncNumber = ncNumber.PadRight(12, ' ');

                        double temp = Convert.ToDouble(typeob.GetField(sprgdir2_data2).GetValue(ob).ToString());
                        temp = temp / 1024.0 + 0.5;
                        if (temp < 1)
                            temp += 0.5;

                        string ncLength = ((int)temp).ToString();
                        ncLength = ncLength.PadRight(13, ' ');
                        string ncComment = typeob.GetField(sprgdir2_data3).GetValue(ob).ToString();
                        string all = ncNumber + "|" + ncLength + "|" + ncComment;
                        listcnc_rdprogdir2.Items.Add(all);

                    }
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            rdProDir();
        }

        //读注册程序
        private void button8_Click(object sender, EventArgs e)
        {
            Fanuc.PRGDIR3 prgdir3 = new Focas1.PRGDIR3();
            short a = 2, c = 100;//a:输出type b：指针开始位置 c：程序的总数量
            int b  = Convert.ToInt16(textBox1.Text);
            short ret = Fanuc.cnc_rdprogdir3(Fanuc.h, a, ref b, ref c, prgdir3);
            //dir1包含的数据number编号 length程序大小 comment注释
            if (ret == Fanuc.EW_OK)
            {
                string sprgdir3 = "dir";
                string sprgdir3_data = "number";
                string sprgdir3_data2 = "length";
                string sprgdir3_data3 = "comment";
                string sprgdir3_data4 = "mdate";
                string sprgdir3_data5 = "year";
                string sprgdir3_data6 = "month";
                string sprgdir3_data7 = "day";
                string sprgdir3_data8 = "hour";
                string sprgdir3_data9 = "minute";

                if (ret == Fanuc.EW_OK)
                {
                    //处理显示的数据
                    listcnc_rdprogdir2.Items.Clear();
                    listcnc_rdprogdir2.Items.Add("合计：" + c);
                    listcnc_rdprogdir2.Items.Add("程序号（个）|大小（Kbyte）|时间            |注释（）");
                    System.Type type = prgdir3.GetType();                 //|2016/5/25 24:24
                    for (int j = 1; j < c + 1; j++)
                    {
                        sprgdir3 = "dir" + j;
                        FieldInfo fieidinfo = type.GetField(sprgdir3);
                        object ob = fieidinfo.GetValue(prgdir3);
                        System.Type typeob = ob.GetType();

                        string ncNumber = typeob.GetField(sprgdir3_data).GetValue(ob).ToString().PadLeft(4, '0');
                        ncNumber = ncNumber.PadRight(12, ' ');

                        double temp = Convert.ToDouble(typeob.GetField(sprgdir3_data2).GetValue(ob).ToString());
                        temp = temp / 1024.0 + 0.5;
                        if (temp < 1)
                            temp += 0.5;
                        string ncLength = ((int)temp).ToString();
                        ncLength = ncLength.PadRight(13, ' ');

                        object ob1 = typeob.GetField(sprgdir3_data4).GetValue(ob);
                        System.Type tyob1 = ob1.GetType();
                        string year = tyob1.GetField(sprgdir3_data5).GetValue(ob1).ToString().PadLeft(4, '0');
                        string month = tyob1.GetField(sprgdir3_data6).GetValue(ob1).ToString().PadLeft(2, '0');
                        string day = tyob1.GetField(sprgdir3_data7).GetValue(ob1).ToString().PadLeft(2, '0');
                        string hour = tyob1.GetField(sprgdir3_data8).GetValue(ob1).ToString().PadLeft(2, '0');
                        string minute = tyob1.GetField(sprgdir3_data9).GetValue(ob1).ToString().PadLeft(2, '0');
                        string nctime = year + "/" + month + "/" + day + " " + hour + ":" + minute;

                        string ncComment = typeob.GetField(sprgdir3_data3).GetValue(ob).ToString();

                        string all = ncNumber + "|" + ncLength + "|" + nctime + "|" + ncComment;
                        listcnc_rdprogdir2.Items.Add(all);
                    }
                }
            }
        }
        //读取数控程序的管理数据已经在数控注册。　　　　
        //数控程序的管理数据　　注册程序(30我,保留文件夹的数量由系统添加)。　
        //可用的项目数量　　字符数量的内存使用　　字符数量的未使用的内存　　
        //这个函数返回这些数据以二进制格式或ASCII字符串格式。
        public void rdProInfo()
        {
            Fanuc.ODBNC_1 odbnc_1 = new Focas1.ODBNC_1();
            short ret = Fanuc.cnc_rdproginfo(Fanuc.h, 0, 16, odbnc_1);
            if (ret == Fanuc.EW_OK)
            {
                txtReg_prg.Text = odbnc_1.reg_prg.ToString();
                txtUnreg_prg.Text = odbnc_1.unreg_prg.ToString();
                txtUsed_mem.Text = ((int)(Convert.ToDouble(odbnc_1.used_mem) / 1024.0 + 0.5)).ToString();
                txtUnused_mem.Text = ((int)(Convert.ToDouble(odbnc_1.unused_mem) / 1024.0 + 0.5)).ToString();
            }
            else
            {
                // MessageBox.Show(Fanuc.cnc_getErrorInfo(ret));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            rdProInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            short cncNb = Convert.ToInt16(txtCncNb.Text);
            int ret = Fanuc.cnc_search(Fanuc.h, cncNb);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("程序：" + cncNb + "被找到！");
            }
            else
            {
                MessageBox.Show("未找到！");
            }
        }

        private void btnDelall_Click(object sender, EventArgs e)
        {
            int ret = Fanuc.cnc_delall(Fanuc.h);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("删除所有非受保护的程序成功！");
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            short cncNb = Convert.ToInt16(txtCncNb.Text);
            int ret = Fanuc.cnc_delete(Fanuc.h, cncNb);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("程序：" + cncNb + "删除成功！");
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            Fanuc.ODBERR odberr = new Focas1.ODBERR();
            string data = txtProgram.Text;
            data = data.Replace("\r\n", "\n");
            short ret = Fanuc.download(Fanuc.h, 0, data, odberr);
            if (ret != Fanuc.EW_OK)
            {
                MessageBox.Show("下载出错：" + ret);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            short cncNb = Convert.ToInt16(txtCncNb.Text);
            string data = "";
            short ret = Fanuc.upload(Fanuc.h, 0, cncNb, ref data, null);
            if (ret == 0)
            {
                data = data.Replace("\n", "\r\n");
                txtProgram.Text = data;
            }
            else
            {
                MessageBox.Show("读取出错：" + ret);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream filestream = new FileStream(openFileDialog.FileName, FileMode.Open);
                byte[] fbuf = new byte[filestream.Length];
                filestream.Read(fbuf, 0, fbuf.Length);
                string sfile = Encoding.ASCII.GetString(fbuf);
                txtProgram.Text = sfile;
                filestream.Close();
                MessageBox.Show("导入成功");
            }
        }
    }
}
