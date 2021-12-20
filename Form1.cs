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

namespace JobberLogin
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=192.168.174.75,1433;Initial Catalog=Gebruikers;Persist Security Info=True;User ID=Marco;Password=P@ssword1"); // making connection   
        public Form1()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM GebruikersTest WHERE UserName='" + tbUsername.Text + "' AND Password='" + tbPassword.Text + "'", con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                MessageBox.Show("Goedzo, neef");
            }
            else
                MessageBox.Show("Invalid username or password");
        }
    }
}



/*"' OR UserName LIKE '%'; INSERT INTO GebruikersTest VALUES (1002, 'ypv', 'youp@youp.nl', 'lollol');--";*/