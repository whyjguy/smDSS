using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace smDSS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin popup = new FormAdmin();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                Console.WriteLine("You clicked OK");
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
          
        }

        private void qtyDisplayLabel_Click(object sender, EventArgs e)
        {

        }

        private void PNtextbox_TextChanged(object sender, EventArgs e)
        {
            
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\matth\source\repos\smDSS\SMData.mdf; Integrated Security = True;Initial Catalog=Inventory ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string pnselect = PNtextbox.Text;
                string sql = "SELECT QtyOnHand FROM Inventory WHERE PartNumber = '" + pnselect + "'";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        qtydisplay.Text = reader.GetString(0);
                    }
                }
                finally
                {
                    reader.Close();
                }

                
            }









        }

        private void ClearPNText_Click(object sender, EventArgs e)
        {
            PNtextbox.Text = "";
            qtydisplay.Text = "";
        }
    }
}
