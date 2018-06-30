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
    public partial class frmDeleteAcc : Form
    {
        static String Fullname = "";
        static String Password = "";
        HomePage homepage;                       //  object of home page form
        frmLogin frL;

        public frmDeleteAcc()
        {
            InitializeComponent();
        }

        public frmDeleteAcc(String Name,String Pass)
        {
            InitializeComponent();
            Fullname = Name;
            Password = Pass;
            lbWelcome.Text = "Welcome " + Name;
        }

        private void labelHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            homepage = new HomePage();
            homepage.Show();
        }

        private void lbWelcome_Click(object sender, EventArgs e)
        {

        }

        private void frmDeleteAcc_Load(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (Password == "")
            {
                MessageBox.Show("enter your password first!!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (Password == tbPassword.Text)
            {
                MessageBox.Show("Password Match!!!\nYou can Delete the Account","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            if(Password != tbPassword.Text)
            {
                MessageBox.Show("Password Doesn't Match!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=.;Initial Catalog = ConnectDemo_db ;Integrated Security=true;";      //  connection string
                SqlConnection connection = new SqlConnection(connectionString);                                             //make a connection with the provided connection string
                SqlCommand command = new SqlCommand("DELETE FROM Login WHERE Password=" + Password + ";", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("records deleted successfully");
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frL = new frmLogin();
            this.Hide();
            frL.Show();
            
        }
    }
}
