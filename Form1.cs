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
            //Opens connection to Inventory and reads the text box PNTextbox then applies that value to a Query and exact matches
            //Then it updates the qtydisplay text box with the QuantityOnHand column matching that PN
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\matth\source\repos\smDSS\SMData.mdf; Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string pnselect = PNtextbox.Text;
                string pnsql = "SELECT QtyOnHand FROM Inventory WHERE PartNumber = '" + pnselect + "'";
                SqlCommand pncommand = new SqlCommand(pnsql, connection);
                connection.Open();
                SqlDataReader reader = pncommand.ExecuteReader();
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

                string posql = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) <= 1 AND YEAR(DueDate) <= 2022 AND QtyReceived != QtyOrdered";
               // SqlCommand pocommand = new SqlCommand(posql, connection);
              // SqlDataReader poreader = pocommand.ExecuteReader();

                using (SqlCommand pocommand = new SqlCommand(posql, connection))
                {
                    
                    QtyOnOrder1.Text = pocommand.ExecuteScalar().ToString();
                }


/*
               try



                {
                    while(poreader.Read())
                    {
                        QtyOnOrder1.Text = Convert.ToString(poreader);
                    }
                }
                finally
                {
                    poreader.Close();
                }

*/
                connection.Close();
            }
        }

        private void ClearPNText_Click(object sender, EventArgs e)
        {
            //Resets form
            PNtextbox.Text = "";
            qtydisplay.Text = "";
            QtyOnOrder1.Text = "";
        }
    }
}
