using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smDSS
{
    public partial class FormAdmin : Form
    {
        string sSelectedFile;
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
            //File browser for finding inventory.csv file saves path to the string sSelectedFile
            OpenFileDialog inventorycsvpath = new OpenFileDialog();
            inventorycsvpath.Filter = "All Files (*.csv)|*.csv*";
            inventorycsvpath.FilterIndex = 1;

            if (inventorycsvpath.ShowDialog() == DialogResult.OK)
            {
                
                sSelectedFile = inventorycsvpath.FileName;
                
                // Debug message box               
                // MessageBox.Show(sSelectedFile);
            }
        }
    }
}
