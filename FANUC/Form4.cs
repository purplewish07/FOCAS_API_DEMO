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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public TextBox ParentControl { get; internal set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 handle = new Form1();
            handle.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
