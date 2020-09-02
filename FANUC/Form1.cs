using System;
using System.IO.Ports;
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
    public partial class Form1 : Form
    {
       

        public object DropDownList { get; private set; }
        public object cboDept { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = 4;
            comboBox4.SelectedIndex = 1;
            comboBox5.SelectedIndex = 2;
            comboBox6.SelectedIndex = 1;
            comboBox7.SelectedIndex = 1;

            


        }







        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void label8_Click(object sender, EventArgs e)
        {
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (string PortName in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBox2.Items.Add(PortName);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           ;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
    }
}
