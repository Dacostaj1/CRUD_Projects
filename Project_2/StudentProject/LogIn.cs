using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace StudentProject
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=project;Integrated Security=True;Pooling=False");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from student where sname='"+textBox1.Text.ToString()+"' and sadd='"+textBox2.Text.ToString()+"'" , con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count>=1){
                CSMSSMDI cs=new CSMSSMDI();
                cs.Show();
                this.Hide();
            }
        }
        
    }
}
