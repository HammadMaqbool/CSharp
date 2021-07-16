using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiUserDesktop
{
    public partial class Form1 : Form
    {
        private static string userrole = "";
        public Form1()
        {
            InitializeComponent();
        }
        public static string UserRole { 
            get
            {
                return userrole;
            }
            set
            {
                userrole = value;
            }
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (txt_username.Text == "Admin" && txt_password.Text == "Admin")
            {
                    if (comboBox1.Text == "Admin")
                    {
                        UserRole = "Admin";
                        MainFrm obj = new MainFrm();
                        obj.Show();
                        this.Hide();
                    }
                    else if (comboBox1.Text == "Sales Man")
                    {
                        UserRole = "Sales Man";
                        MainFrm obj = new MainFrm();
                        obj.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Password!");
                }            
        }
    }
}
