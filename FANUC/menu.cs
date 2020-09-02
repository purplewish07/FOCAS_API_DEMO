using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FANUC
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            int ret = Fanuc.cnc_freelibhndl(Fanuc.h);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handle handle = new handle();
            handle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ncpro ncpro = new ncpro();
            ncpro.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            historydata historydata = new historydata();
            historydata.Show();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            
        }

   

        private void button2_Click(object sender, EventArgs e)
        {
            control_axis con_axis = new control_axis();
            con_axis.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //related re = new related();
            //re.Show();
            related_axis relate = new related_axis();
            relate.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
         
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pmc pmc = new pmc();
            pmc.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            alarm alarm = new alarm();
            alarm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tool_life_manage tool_life = new tool_life_manage();
            tool_life.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            para papagroph = new para();
            papagroph.Show(); 

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            demo demo = new demo();
            demo.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://qm.qq.com/cgi-bin/qm/qr?k=v5-kKV-S695UGd-O-tVozhnKxJhAFjnH");
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            PMCRW demo = new PMCRW();
            demo.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void 傳輸設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 傳輸設定ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            
                
            
        }

        private void 基本設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 handle = new Form2();
            handle.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 新增設備ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 handle = new Form1();
            handle.Show();
        }

        private void 管理設備ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 handle = new Form4();
            handle.Show();
        }
    }
}
