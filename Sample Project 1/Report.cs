using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Sample_Project_1
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-19SPH86;Initial Catalog=Adeege;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        String date1;
        String date2;
        int ID = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string select = "select * from Payment2 where Item_id='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(select, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            CrystalReport2 cr = new CrystalReport2();
            cr.Database.Tables["Payment2"].SetDataSource(dt);
            this.crystalReportViewer1.ReportSource = cr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string select = "select * from Payment2 where Item_name='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(select, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            CrystalReport2 cr = new CrystalReport2();
            cr.Database.Tables["Payment2"].SetDataSource(dt);
            this.crystalReportViewer1.ReportSource = cr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            date1 = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            date2 = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day;
            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select * from Payment2 Where Date between'" + date1 + "' and '" + date2 + "'", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            CrystalReport2 cr = new CrystalReport2();
            cr.Database.Tables["Payment2"].SetDataSource(dt);
            this.crystalReportViewer1.ReportSource = cr;

              con.Close();
        }
    }
}
