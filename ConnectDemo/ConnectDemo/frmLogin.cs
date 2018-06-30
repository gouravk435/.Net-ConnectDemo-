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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelDatetime_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //DateTime datetime = DateTime.Now;
            this.labelDatetime.Text = DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt");      //timer1 that's why "this."
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            String message = "Do you want to Exit?";
            String title = "Alert";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);     //DialogResult class, "result" take the return from show function
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //Nothing wil return back to the form
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(tbUsername.Text=="" && tbPassword.Text == "")
            {
                MessageBox.Show("Please provide Username and Password","Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string connectionString = "Data Source=.;Initial Catalog = ConnectDemo_db ;Integrated Security=true;";     //  connection string
                SqlConnection connection = new SqlConnection(connectionString);     //make a connection with the provided connection string
                SqlCommand command = new SqlCommand("Select * from Login where UserName=@username and Password=@password", connection); //  stores the sql command wit the provided connection
                command.Parameters.AddWithValue("@username",tbUsername.Text);   //  add value to the variable in sql command
                command.Parameters.AddWithValue("password",tbPassword.Text);    //  add value to the variable in sql command
                connection.Open();      //open connection
                SqlDataAdapter adpt = new SqlDataAdapter(command);  
                DataSet ds = new DataSet();     //ds dataset hold the data return from sql command 
                adpt.Fill(ds);
                connection.Close();     //  close the connection

                int count = ds.Tables[0].Rows.Count;    //  count the rows of first table stored in ds variable

                /*  why this condition? -with the given username and password their should be only one row of data and that will clone to the Dataset
                 *  and thus, count==1
                */
                if (count==1)        
                {
                    MessageBox.Show("Login Successfully!!!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    String username = tbUsername.Text;
                    String cmd= "select FullName from Login Where UserName=" + username;
                    SqlCommand command2 = new SqlCommand(cmd, connection);
                    connection.Open();
                    SqlDataAdapter adpt2 = new SqlDataAdapter(command2);
                    DataSet ds2 = new DataSet();
                    adpt.Fill(ds2,"Login");

                    if (ds2.Tables[0].Rows.Count != 0)      //obviously, count should be more than 0 (there should be atleast 1 data)
                    {
                        foreach(DataRow dr in ds2.Tables[0].Rows)
                        {
                            HomePage hm = new HomePage(dr[1].ToString()/*fullname*/, dr[3].ToString()/*password*/);                                                          //create object of home page the page that will open for a particular user
                            this.Hide();
                            hm.Show();
                        }
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRegister fmRg = new frmRegister();
            this.Hide();
            fmRg.Show();
        }
    }
}
