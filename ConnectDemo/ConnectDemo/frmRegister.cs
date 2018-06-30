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
    public partial class frmRegister : Form
    {
        frmLogin frL = new frmLogin();      //  login from object created
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frL.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frL.Show();
            }
            else
            {
                return;
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            /*if (String.IsNullOrEmpty(tbUsername.Text))
            {
                MessageBox.Show("Please Enter Username", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string connectionString = "Data Source=.;Initial Catalog = ConnectDemo_db ;Integrated Security=true;";     //  connection string
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("select Username from Login where UserName=@Username", connection);
                command.Parameters.AddWithValue("@Username", tbUsername.Text);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        MessageBox.Show("Username = " + dr[1].ToString() + " Already Exist!!!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        break;      //  to terminate the if block so the control flow can pass to upper loop
                    }
                }

            }
        }**/
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "" && tbPassword.Text == "" && tbFullname.Text == "" && tbPhone.Text == "" && tbEmail.Text == "")
            {
                MessageBox.Show("Please Enter the Details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    string connectionString = "Data Source=.;Initial Catalog = ConnectDemo_db ;Integrated Security=true;";     //  connection string
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("insert into Login (FullName,UserName,Password,PhoneNumber,Email) values(@Fullname,@Username,@Password,@Phone, @Emailid)", connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@Fullname", tbFullname.Text);
                    command.Parameters.AddWithValue("@Username", tbUsername.Text);
                    command.Parameters.AddWithValue("@Password", tbPassword.Text);
                    command.Parameters.AddWithValue("@Phone", tbPhone.Text);
                    command.Parameters.AddWithValue("@Emailid", tbEmail.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("SignUp sccessful!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }       
    }
}