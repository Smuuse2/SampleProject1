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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-19SPH86;Initial Catalog=Adeege;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        int ID = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from Payment2", con);
            da.Fill(dt);

            Dgv.DataSource = dt;
            con.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txt_id.Text != "" && txt_Item_name.Text != "" && txt_Price.Text != "" && txt_Quantity.Text != "" && txt_Discount.Text != "" && t.Text != "" && Dtp.Text != "")
            {
                cmd = new SqlCommand("insert into Payment2 values(@Item_id,@Item_name, @Price, @Quantity, @Discount, @Total,@Date,@payment_Method)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Item_id", txt_id.Text);
                cmd.Parameters.AddWithValue("@Item_name", txt_Item_name.Text);
                cmd.Parameters.AddWithValue("@Price", txt_Price.Text);
                cmd.Parameters.AddWithValue("@Quantity", txt_Quantity.Text);
                cmd.Parameters.AddWithValue("@Discount", txt_Discount.Text);
                cmd.Parameters.AddWithValue("@Total", t.Text);
                cmd.Parameters.AddWithValue("@payment_Method", gunaComboBox1.Text);
                cmd.Parameters.AddWithValue("@Date", Dtp.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Saved Successfully","ma hubtaa inad save Garayso",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                DisplayData();
                ClearData();
            }
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from Payment2", con);
            da.Fill(dt);
            Dgv.DataSource = dt;
            con.Close();

        }
        private void ClearData()
        {



            ID = 0;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (txt_id.Text != "" && txt_Item_name.Text != "" && txt_Price.Text != "" && txt_Quantity.Text != "" && txt_Discount.Text != "" && t.Text != "" && Dtp.Text != "")
            {
                cmd = new SqlCommand("update Payment2 set Item_id=@Item_id, Item_name=@Item_name, Price=@Price, Quantity=@Quantity, Discount=@Discount,Total=@Total,Date=@Date,payment_method=@payment_method where Item_id=@Item_id", con);
                con.Open();
                ID = Convert.ToInt32(txt_id.Text);
                cmd.Parameters.AddWithValue("@Item_id", txt_id.Text);
                cmd.Parameters.AddWithValue("@Item_name", txt_Item_name.Text);
                cmd.Parameters.AddWithValue("@Price", txt_Price.Text);
                cmd.Parameters.AddWithValue("@Quantity", txt_Quantity.Text);
                cmd.Parameters.AddWithValue("@Discount", txt_Discount.Text);
                cmd.Parameters.AddWithValue("@Total", t.Text);
                cmd.Parameters.AddWithValue("@payment_Method", gunaComboBox1.Text);
                cmd.Parameters.AddWithValue("@Date", Dtp.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }
       

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (txt_id.Text != "")
            {
                cmd = new SqlCommand("delete Payment2 where Item_id=@Item_id", con);
                con.Open();
                ID = Convert.ToInt32(txt_id.Text);
                cmd.Parameters.AddWithValue("@Item_id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string select = "select * from Payment2 where Item_id like'" + txt_Search.Text + "%'or Item_name like'" + txt_Search.Text + "%'";
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Dgv.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void txt_Discount_TextChanged(object sender, EventArgs e)
        {
            if (txt_Discount.Text != "")
            {
                double cost;
                double price;
                double Discount;
                double total;

                cost = Convert.ToDouble(txt_Price.Text);
                price = Convert.ToDouble(txt_Quantity.Text);
                Discount = Convert.ToDouble(txt_Discount.Text);

                total = cost * price  - Discount;
                t.Text = Convert.ToString(total);
            }
            else
            {
                t.Text = "";
                txt_Discount.Clear();
                txt_Price.Clear();
                t.Clear();
            }





         
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form1_Load(this,null);
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Row = this.Dgv.Rows[e.RowIndex];

                txt_id.Text = Row.Cells[0].Value.ToString();
                txt_Item_name.Text = Row.Cells[1].Value.ToString();
                txt_Price.Text = Row.Cells[2].Value.ToString();
                txt_Quantity.Text = Row.Cells[3].Value.ToString();
                txt_Discount.Text = Row.Cells[4].Value.ToString();
                t.Text = Row.Cells[5].Value.ToString();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            {
               
                }
            }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Report dd = new Report();
            dd.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
          
           
            

        }

        private void label9_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_Discount.Clear();
            txt_Item_name.Clear();
            txt_Price.Clear();
            t.Clear();
            txt_Quantity.Clear();
        }
           
            
        }

    }

