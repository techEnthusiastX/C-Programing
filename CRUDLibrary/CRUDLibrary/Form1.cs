using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace CRUDLibrary
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            string query = "select * from Library where name like @name + '%'";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@name", txtSearch.Text.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Record Found");
                dataGridView1.DataSource = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textID.Text) == true)
            {
                textID.Focus();
                errorProvider1.SetError(this.textID, "Please Enter ID");
            }
            else if (string.IsNullOrEmpty(textName.Text) == true)
            {
                textName.Focus();
                errorProvider2.SetError(this.textName, "Please Enter Name");
            }
            else if (string.IsNullOrEmpty(BookNo.Text) == true)
            {
                BookNo.Focus();
                errorProvider3.SetError(this.BookNo, "Please Enter Book Number");
            }
            else if (string.IsNullOrEmpty(description.Text) == true)
            {
                description.Focus();
                errorProvider4.SetError(this.description, "Please Enter Book Description");
            }
            else if (string.IsNullOrEmpty(returninfo.Text) == true)
            {
                returninfo.Focus();
                errorProvider5.SetError(this.returninfo, "Please Enter Book return details");
            }
            else
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                errorProvider4.Clear();
                errorProvider5.Clear();

                OleDbConnection con = new OleDbConnection(cs);
                con.Open();

                string query2 = "select * from Library where id=@id";
                OleDbCommand cmd2 = new OleDbCommand(query2, con);
                cmd2.Parameters.AddWithValue("@id", textID.Text);
                OleDbDataReader dr = cmd2.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show(textID.Text + " ID has already taken...!!");
                }
                else
                {
                    string query = "insert into Library values(@id, @name, @number, @description, @returninfo)";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", textID.Text);
                    cmd.Parameters.AddWithValue("@name", textName.Text);
                    cmd.Parameters.AddWithValue("@number", BookNo.Value);
                    cmd.Parameters.AddWithValue("@description", description.Text);
                    cmd.Parameters.AddWithValue("@returninfo", returninfo.Text);

                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Record Saved Succesfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        display();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    con.Close();
                }
            }
        }

        void reset()
        {
            textID.Clear();
            textName.Clear();
            BookNo.Value = 0;
            description.Clear();
            returninfo.Clear();
            textID.Focus();
        }
        void display()
        {
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            string query = "select * from Library";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btmview_Click(object sender, EventArgs e)
        {
            display();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            BookNo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            description.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            returninfo.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();

            string query = "UPDATE Library set id=@id, name=@name, number=@number, description=@description, returninfo=@returninfo WHERE id=@id";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textID.Text);
            cmd.Parameters.AddWithValue("@name", textName.Text);
            cmd.Parameters.AddWithValue("@number", BookNo.Value);
            cmd.Parameters.AddWithValue("@description", description.Text);
            cmd.Parameters.AddWithValue("@returninfo", returninfo.Text);

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Record updated Succesfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();
                reset();
            }
            else
            {
                MessageBox.Show("Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        
        private void btndelete_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();

            string query = "delete from Library where id=@id";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textID.Text);
            

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Record Deleted Succesfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();
                reset();
            }
            else
            {
                MessageBox.Show("Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void search_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            string query = "select * from Library where name like @name + '%'";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@name", txtSearch.Text.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Record Found");
                dataGridView1.DataSource = null; 
            }
        }
    }
}
