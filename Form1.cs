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

            Month1GroupBox.Text = " " + month + " / " + year + "";
            Month2GroupBox.Text = " " + month2 + " / " + year + "";
            Month3GroupBox.Text = " " + month3 + " / " + year + "";
            Month4GroupBox.Text = " " + month4 + " / " + year + "";
            Month5GroupBox.Text = " " + month5 + " / " + year + "";
            Month6GroupBox.Text = " " + month6 + " / " + year + "";
            Month7GroupBox.Text = " " + month7 + " / " + year + "";
            Month8GroupBox.Text = " " + month8 + " / " + year + "";
            Month9GroupBox.Text = " " + month9 + " / " + year + "";
            Month10GroupBox.Text = " " + month10 + " / " + year + "";
            Month11GroupBox.Text = " " + month11 + " / " + year + "";
            Month12GroupBox.Text = " " + month12 + " / " + year + "";

            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\matth\source\repos\smDSS\SMData.mdf; Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                try
                {
                    string query = "SELECT * from Inventory";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    connection.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Inventory");
                    PNtextbox.DataSource = ds.Tables["Inventory"];
                    PNtextbox.ValueMember = "ID";
                    PNtextbox.DisplayMember = "PartNumber";
                    

                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }











                /*

                string sqldv = "SELECT * FROM Inventory";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqldv, connection);
                connection.Open();
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds, "Inventory_Member");
                connection.Close();

                PNtextbox.DataSource = ds;
                connection.Close();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = ds;
                PNtextbox.DataSource = bindingSource.DataSource;
                PNtextbox.DisplayMember = "Inventory_Member";
                PNtextbox.ValueMember = "PartNumber";

                */
            }

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
                string posql4 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month4 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd4 = new SqlCommand(posql4, connection))
                {
                    QtyOnOrder4.Text = pocmd4.ExecuteScalar().ToString();
                }
                string posql5 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month5 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd5 = new SqlCommand(posql5, connection))
                {
                    QtyOnOrder5.Text = pocmd5.ExecuteScalar().ToString();
                }
                string posql6 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month6 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd6 = new SqlCommand(posql6, connection))
                {
                    QtyOnOrder6.Text = pocmd6.ExecuteScalar().ToString();
                }
                string posql7 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month7 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd7 = new SqlCommand(posql7, connection))
                {
                    QtyOnOrder7.Text = pocmd7.ExecuteScalar().ToString();
                }
                string posql8 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month8 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd8 = new SqlCommand(posql8, connection))
                {
                    QtyOnOrder8.Text = pocmd8.ExecuteScalar().ToString();
                }
                string posql9 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month9 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd9 = new SqlCommand(posql9, connection))
                {
                    QtyOnOrder9.Text = pocmd9.ExecuteScalar().ToString();
                }
                string posql10 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month10 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd10 = new SqlCommand(posql10, connection))
                {
                    QtyOnOrder10.Text = pocmd10.ExecuteScalar().ToString();
                }
                string posql11 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month11 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd11 = new SqlCommand(posql11, connection))
                {
                    QtyOnOrder11.Text = pocmd11.ExecuteScalar().ToString();
                }
                string posql12 = "SELECT SUM(QtyOrdered) FROM PurchaseOrders WHERE PartNo = '" + pnselect + "' AND MONTH(DueDate) = '" + month12 + "' AND YEAR(DueDate) = '" + year + "' AND QtyReceived != QtyOrdered";
                using (SqlCommand pocmd12 = new SqlCommand(posql12, connection))
                {
                    QtyOnOrder12.Text = pocmd12.ExecuteScalar().ToString();
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

        private void Month7GroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
