using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectDemo
{
    public partial class HomePage : Form
    {
        static String Fullname = "";
        static String Password = "";
        frmLogin frmL;                                                              //  object of frmLogin form
        frmUpdate_Detail frmUpdate;                                                 //  object of frmUpdate_Details form
        frmDeleteAcc frmDelete;                                                     //  object of frmDeleteAcc form
        frmViewtable frmviewtable;                                                  //  object of frmviewtable

        public HomePage()
        {
            InitializeComponent();
        }
        
        public HomePage(String Name, String Pass)        //  parameterize constructor    "Name" pass from frmlogin page for a particular user that logged in
        {
            InitializeComponent();
            Fullname = Name;
            Password = Pass;
            lbWelcome.Text = "Welcome " + Name;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void lbWelcome_Click(object sender, EventArgs e)
        {

        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmL = new frmLogin();
            frmL.Show();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cbModule.Text == "")
            {
                MessageBox.Show("Plese Select a module", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cbModule.Text == "Update your Details")
            {
                this.Hide();
                frmUpdate = new frmUpdate_Detail(Fullname,Password);
                frmUpdate.Show();
            }
            if(cbModule.Text == "Delete your Account")
            {
                this.Hide();
                frmDelete = new frmDeleteAcc(Fullname,Password);
                frmDelete.Show();
            }
            if(cbModule.Text== "Show Entire Table")
            {
                frmviewtable = new frmViewtable();
                frmviewtable.Show();
            }
        }
    }
}
