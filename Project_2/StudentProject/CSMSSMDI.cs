using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentProject
{
    public partial class CSMSSMDI : Form
    {
        private int childFormNumber = 0;

        public CSMSSMDI()
        {
            InitializeComponent();
        }

                
        private void newStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.MdiParent = this;
            f1.Show();
        }
    }
}
