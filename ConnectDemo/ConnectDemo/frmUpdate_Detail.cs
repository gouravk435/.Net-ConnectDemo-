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
    public partial class frmUpdate_Detail : Form
    {
        static String Fullname = "";
        static String Password = "";
        HomePage homepage;                      //  object of homepage form

        public frmUpdate_Detail()
        {
            InitializeComponent();
        }
        public frmUpdate_Detail(String Name,String Pass)
        {
            InitializeComponent();
            Fullname = Name;
            Password = Pass;
            lbWelcome.Text = "Welcome " + Name;
        }

        private void frmUpdate_Detail_Load(object sender, EventArgs e)
        {

        }

        private void lbWelcome_Click(object sender, EventArgs e)
        {

        }

        private void labelHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            homepage = new HomePage();
            homepage.Show();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=.;Initial Catalog = ConnectDemo_db ;Integrated Security=true;";      //  connection string
                SqlConnection connection = new SqlConnection(connectionString);                                             //make a connection with the provided connection string
                SqlCommand command = new SqlCommand("UPDATE Login SET Password=@password,PhoneNumber=@phone,Email=@email WHERE Password=" + Password + ";", connection);
                connection.Open();
                command.Parameters.AddWithValue("@password", tbNewpassword.Text);
                command.Parameters.AddWithValue("@phone", tbNewphone.Text);
                command.Parameters.AddWithValue("@email", tbNewemail.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Details Changed successfully");
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            this.Hide();
            homepage = new HomePage();
            homepage.Show();
        }
    }
}
