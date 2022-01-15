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
    public partial class FormAdmin : Form
    {

        public FormAdmin()
        {
            InitializeComponent();

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        // Inventory Path Button //
        private void button1_Click(object sender, EventArgs e)
        {
            
            //File browser for finding inventory.csv file saves path to the string filename
            OpenFileDialog inventorycsvpath = new OpenFileDialog();
            inventorycsvpath.Filter = "All Files (*.csv)|*.csv*";
            inventorycsvpath.FilterIndex = 1;
            
            string filename = new SelectedFile().FileName;
            
            if (inventorycsvpath.ShowDialog() == DialogResult.OK)
            {

                filename = inventorycsvpath.FileName;
                csvHelper.InventoryReader(filename);
                

                // Debug message box               
                // MessageBox.Show(sSelectedFile);
            }

            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\matth\source\repos\smDSS\SMData.mdf; Integrated Security = True;Initial Catalog=Inventory ";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqldv = "SELECT * FROM Inventory";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqldv, sqlConnection);
            sqlConnection.Open();
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds, "Inventory_Member");
            sqlConnection.Close();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ds;
            inventorydataview.DataSource = bindingSource;
            inventorydataview.DataMember = "Inventory_Member";
            inventorydataview.Refresh();
            bindingSource.ResetBindings(true);
            
        }
        public  class SelectedFile
        {
             public string FileName { get; set; }
         }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
           
           

        }

        private void POpath_Click(object sender, EventArgs e)
        {
            //File browser for finding PO.csv file saves path to the string filename
            OpenFileDialog POcsvpath = new OpenFileDialog();
            POcsvpath.Filter = "All Files (*.csv)|*.csv*";
            POcsvpath.FilterIndex = 1;

            string filename = new SelectedFile().FileName;

            if (POcsvpath.ShowDialog() == DialogResult.OK)
            {

                filename = POcsvpath.FileName;
                csvHelper.POReader(filename);


                // Debug message box               
                // MessageBox.Show(sSelectedFile);
            }
        }
    }
    
    
}
