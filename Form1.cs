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
            DateTime dt = DateTime.Now;
            int year = dt.Year;
            int month = dt.Month;
            int month2 = month + 1;
            int month3 = month2 + 1;
            int month4 = month3 + 1;
            int month5 = month4 + 1;
            int month6 = month5 + 1;
            int month7 = month6 + 1;
            int month8 = month7 + 1;
            int month9 = month8 + 1;
            int month10 = month9 + 1;
            int month11 = month10 + 1;
            int month12 = month11 + 1;

            labelMonth1.Text = " " + month + " / " + year +  "";
            labelMonth2.Text = " " + month2 + " / " + year + "";
            labelMonth3.Text = " " + month3 + " / " + year + "";
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

                DateTime dt = DateTime.Now;

                // Get year, month
                int year = dt.Year;

                int month = dt.Month;
                int month2 = month + 1;
                int month3 = month2 + 1;
                int month4 = month3 + 1;
                int month5 = month4 + 1;
                int month6 = month5 + 1;
                int month7 = month6 + 1;
                int month8 = month7 + 1;
                int month9 = month8 + 1;
                int month10 = month9 + 1;
                int month11 = month10 + 1;
                int month12 = month11 + 1;

                string posql1 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) <= '" + month + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered OR PartNo = '" + pnselect + "' AND QtyReceived != QtyOrdered AND YEAR(DueDate) < '" + year + "'";
                using (SqlCommand pocmd1 = new SqlCommand(posql1, connection))
                {
                  
                    QtyOnOrder1.Text = pocmd1.ExecuteScalar().ToString();
                    
                }
                
                string posql2 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month2 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd2 = new SqlCommand(posql2, connection))
                {
                    QtyOnOrder2.Text = pocmd2.ExecuteScalar().ToString();
                }
                string posql3 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month3 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd3 = new SqlCommand(posql3, connection))
                {
                    QtyOnOrder3.Text = pocmd3.ExecuteScalar().ToString();
                }



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
