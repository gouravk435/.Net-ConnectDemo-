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
    public partial class frmViewtable : Form
    {
        public frmViewtable()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog = ConnectDemo_db ;Integrated Security=true;";     //  connection string
            SqlConnection connection = new SqlConnection(connectionString);     //make a connection with the provided connection string
            SqlCommand command = new SqlCommand("SELECT * FROM Login", connection);
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dttb = new DataTable();
            sda.Fill(dttb);
            dataGridView1.DataSource = dttb;            
        }
    }
}
