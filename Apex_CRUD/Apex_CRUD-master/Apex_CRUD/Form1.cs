using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apex_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string ConnectionString = ConfigurationManager.ConnectionStrings["Apex"].ToString();
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Insertdata();
            ClearMethod();
        }

        private void Insertdata()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Student VALUES('" + txt_Name.Text + "','" + txt_Fname.Text + "','" + txt_DoB.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data saved Successfuly!");
        }

        private void ClearMethod()
        {
            txt_DoB.Clear();
            txt_Fname.Clear();
            txt_Name.Clear();
        }
    }
}
