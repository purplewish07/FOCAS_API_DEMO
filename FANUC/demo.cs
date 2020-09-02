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
    public partial class demo : Form
    {
        public demo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fanuc.ODBST odbst=new Focas1.ODBST();
            int ret = Fanuc.cnc_statinfo(Fanuc.h, odbst);
            if (ret == Fanuc.EW_OK)
            {
          
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fanuc.ODBSYS odbsys= new Focas1.ODBSYS();
            int ret = Fanuc.cnc_sysinfo(Fanuc.h, odbsys);
            if (ret == Fanuc.EW_OK)
            {
                short addinfo = odbsys.addinfo;
                char[] axes = odbsys.axes;
                char[] cnctype = odbsys.cnc_type;
                short maxaxis=odbsys.max_axis;
                char[] mttype = odbsys.mt_type;
                char[] series = odbsys.series;
                char[] version = odbsys.version;
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fanuc.IODBTIMER iodbtimer =new Focas1.IODBTIMER();
            int ret = Fanuc.cnc_gettimer(Fanuc.h, iodbtimer);
            if (ret == Fanuc.EW_OK)
            {
                Fanuc.TIMER_DATE timerdate = iodbtimer.date;
                Fanuc.TIMER_TIME timertime = iodbtimer.time;
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }
    }
}
