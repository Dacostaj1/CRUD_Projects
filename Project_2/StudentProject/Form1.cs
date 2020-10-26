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
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=project;Integrated Security=True;Pooling=False");
        
        public Form1()
        {
            InitializeComponent();
            show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                con.Open();
                 String name=textBox1.Text.ToString();
                String add=textBox2.Text.ToString();                
                String phone=textBox3.Text.ToString();
                //int iphone=Int3f2.Parse(phone);
                long iphone = Int64.Parse(phone);                
                String sem=textBox4.Text.ToString();
                int isem=Int32.Parse(sem);                
                String branch=comboBox1.SelectedItem.ToString();
                String qry = "insert into student values('"+name+"','"+add+"',"+iphone+","+isem+",'"+branch+"')";
                SqlCommand sc=new SqlCommand(qry,con);
                int i=sc.ExecuteNonQuery();
                if (i>=1)
                MessageBox.Show(i+" Student Registerd Successfully : "+name);
                 else
                    MessageBox.Show(" Student is not Registered: ");

                button1_Click(sender, e);

                show();

                con.Close();

            }catch(System.Exception exp){
                MessageBox.Show(" Error is  "+exp.ToString());
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String name = textBox1.Text.ToString();
                String add = textBox2.Text.ToString();
                String phone = textBox3.Text.ToString();
                long iphone = Int64.Parse(phone);
                String sem = textBox4.Text.ToString();
                int isem = Int32.Parse(sem);
                String branch = comboBox1.SelectedItem.ToString();
                String qry = "update student set sadd='" + add + "', phone=" + iphone + ", sem=" + isem + ", branch='" + branch + "' where sname='" + name + "'";              
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show(i + " Student Updated Successfully : " + name);
                else
                    MessageBox.Show(" Student  Updation Failed..... ");
                button1_Click(sender, e);
                show();
                con.Close();
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(" Error is  " + exp.ToString());

            }
        }

        void show() {

            SqlDataAdapter sda = new SqlDataAdapter("select * from student",con);            
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows) {

                int n=dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();

            }
        }
        //CellContentClick
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text=dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String name = textBox1.Text.ToString();                
                String qry = "delete from student where sname='" + name + "'";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show(i + " Student Deleted Successfully : " + name);
                else
                    MessageBox.Show(" Student  Deletion Failed..... ");
                button1_Click(sender, e);
                show();
                con.Close();
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(" Error is  " + exp.ToString());

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from student where sname like '%"+textBox5.Text.ToString()+"%'" , con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();

            }
        }
       
    }
}


















