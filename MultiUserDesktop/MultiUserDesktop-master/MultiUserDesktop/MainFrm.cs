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
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            UserRoleConfirm(); //Method called in Load function of the form so it will run when we load the form.
            
        }

        //If you will login us Sales Man the function will disable the functionality of 
        //Add user and Delete user.
        
        //If you will login as Admin the Method will not work and Add user and Delete user functions will keep working.
        private void UserRoleConfirm()
        {
            if (Form1.UserRole == "Sales Man")
            {
                //The two lines listed below will disable the functionality only.
                addUserToolStripMenuItem.Enabled = false;
                deleteUserToolStripMenuItem.Enabled = false;

                //By uncommenting these two lines one by one you can see the impact these two lines will hide the button 
                //Sub Menu button and main menu button one by one try these.
                //=========================================
                //addUserToolStripMenuItem.Visible = false;
                //userSettingsToolStripMenuItem.Visible = false;
            }
        }
        
    }
}
