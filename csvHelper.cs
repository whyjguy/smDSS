using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Configuration;




namespace smDSS
{
    internal class csvHelper
    {
        public static void POReader(string csvPath)
        {
            using ( var streamReader = new StreamReader(csvPath))
            {
                using (var Reader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    Reader.Context.RegisterClassMap<POClassMap>();
                    var records = Reader.GetRecords<PurchaseOrders>().ToList();

                    DataTable purchaseorders = new DataTable();

                    purchaseorders.Columns.Add("ID");
                    purchaseorders.Columns.Add("PONum");
                    purchaseorders.Columns.Add("Vendor");
                    purchaseorders.Columns.Add("Date");
                    purchaseorders.Columns.Add("PartNo");
                    purchaseorders.Columns.Add("PartDesc");
                    purchaseorders.Columns.Add("GLAcct");
                    purchaseorders.Columns.Add("TotalQtyOrdered");
                    purchaseorders.Columns.Add("UnitPrice");
                    purchaseorders.Columns.Add("LineTotal");
                    purchaseorders.Columns.Add("DueDate");
                    purchaseorders.Columns.Add("JobNo");
                    purchaseorders.Columns.Add("QtyOrdered");
                    purchaseorders.Columns.Add("QtyReceived");
                    purchaseorders.Columns.Add("QtyCanceled");
                    purchaseorders.Columns.Add("QtyRejected");
                    purchaseorders.Columns.Add("JobNumbers");

                    //Adds each record from CSVReader into the temp table purchaseorders
                    foreach (var record in records)
                    {
                        DataRow row = purchaseorders.NewRow();

                        row["PONum"] = record.purchaseordernum;
                        row["Vendor"] = record.vendor;
                        row["Date"] = record.purchaseorderdate;
                        row["PartNo"] = record.partnumber;
                        row["PartDesc"] = record.partdescription;
                        row["GLAcct"] = record.glaccount;
                        row["TotalQtyOrdered"] = record.tqtyordered;
                        row["UnitPrice"] = record.unitprice;
                        row["LineTotal"] = record.linetotal;
                        row["DueDate"] = record.duedate;
                        row["JobNo"] = record.jobnum;
                        row["QtyOrdered"] = record.qtyordered;
                        row["QtyReceived"] = record.qtyreceived;
                        row["QtyCanceled"] = record.qtycanceled;
                        row["QtyRejected"] = record.qtyrejected;
                        row["JobNumbers"] = record.jobnumbersassigned;

                        purchaseorders.Rows.Add(row);

                    }

                    
                    //Update records to Database: PurchaseOrders Table
                    //Opens SQL Connection to database
                    //Clears all records from table PurchaseOrders
                    //BulkCopies all records from CSVHelper Table purchaseorders to SQL Database PurchaseOrders

                    string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\matth\source\repos\smDSS\SMData.mdf; Integrated Security = True ";

                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {


                        sqlConnection.Open();

                        //Delete old records
                        SqlCommand dCommand;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        String dSql = "";
                        dSql = "DELETE PurchaseOrders WHERE Id LIKE '%'";
                        dCommand = new SqlCommand(dSql, sqlConnection);

                        adapter.DeleteCommand = new SqlCommand(dSql, sqlConnection);
                        adapter.DeleteCommand.ExecuteNonQuery();
                        dCommand.Dispose();

                        //Copy in new records
                        SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection);
                        //BulkCopy columnMappings
                        bulkCopy.DestinationTableName = "PurchaseOrders";
                        bulkCopy.ColumnMappings.Add("PONum", "PONum");
                        bulkCopy.ColumnMappings.Add("Vendor", "Vendor");
                        bulkCopy.ColumnMappings.Add("Date", "Date");
                        bulkCopy.ColumnMappings.Add("PartNo", "PartNo");
                        bulkCopy.ColumnMappings.Add("PartDesc", "PartDesc");
                        bulkCopy.ColumnMappings.Add("GLAcct", "GLAcct");
                        bulkCopy.ColumnMappings.Add("TotalQtyOrdered", "TotalQtyOrdered");
                        bulkCopy.ColumnMappings.Add("UnitPrice", "UnitPrice");
                        bulkCopy.ColumnMappings.Add("LineTotal", "LineTotal");
                        bulkCopy.ColumnMappings.Add("DueDate", "DueDate");
                        bulkCopy.ColumnMappings.Add("JobNo", "JobNo");
                        bulkCopy.ColumnMappings.Add("QtyOrdered", "QtyOrdered");
                        bulkCopy.ColumnMappings.Add("QtyReceived", "QtyReceived");
                        bulkCopy.ColumnMappings.Add("QtyCanceled", "QtyCanceled");
                        bulkCopy.ColumnMappings.Add("QtyRejected", "QtyRejected");
                        bulkCopy.ColumnMappings.Add("JobNumbers", "JobNumbers");
                        //Writes all records to sqlConnection (PurchaseOrders Table)
                        bulkCopy.WriteToServer(purchaseorders);
                        sqlConnection.Close();

                    }
                }
            }
        }
        public class POClassMap : ClassMap<PurchaseOrders>
        {
            //Header Mapping for the Inventory CSV Reader
            public POClassMap()
            {
                Map(m => m.purchaseordernum).Name("PONum");
                Map(m => m.vendor).Name("Vendor");
                Map(m => m.purchaseorderdate).Name("Date");
                Map(m => m.partnumber).Name("PartNo");
                Map(m => m.partdescription).Name("PartDesc");
                Map(m => m.glaccount).Name("GLAcct");
                Map(m => m.tqtyordered).Name("TotalQtyOrdered");
                Map(m => m.unitprice).Name("UnitPrice");
                Map(m => m.linetotal).Name("LineTotal");
                Map(m => m.duedate).Name("DueDate");
                Map(m => m.jobnum).Name("JobNo");
                Map(m => m.qtyordered).Name("QtyOrdered");
                Map(m => m.qtyreceived).Name("QtyReceived");
                Map(m => m.qtycanceled).Name("QtyCanceled");
                Map(m => m.qtyrejected).Name("QtyRejected");
                Map(m => m.jobnumbersassigned).Name("JobNumbers");
            }

        }
        public class PurchaseOrders
        {
            //Columns from the Purchase Order Listing csv
            public double purchaseordernum { get; set; }
            public string vendor { get; set; }
            public string purchaseorderdate { get; set; }
            public string partnumber { get; set; }
            public string partdescription { get; set; }
            public string glaccount { get; set; }
            public string tqtyordered { get; set; }
            public string unitprice { get; set; }
            public string linetotal { get; set; }
            public string duedate { get; set; }
            public string jobnum { get; set; }
            public string qtyordered { get; set; }
            public string qtyreceived { get; set; }
            public string qtycanceled { get; set; }
            public string qtyrejected { get; set; }
            public string jobnumbersassigned { get; set; }
        }
        //csvPath is passed through from the Form Admin after the path is selected from the system dialog. 
        //InventoryReader() can also be called by pressing the refresh button on the main form to refresh the data tables.

        public static void InventoryReader(string csvPath)
        {
          
            using ( var streamReader = new StreamReader(csvPath))
            {
                using (var Reader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    Reader.Context.RegisterClassMap<InventoryClassMap>();
                    var records = Reader.GetRecords<Inventory>().ToArray();
 
                    DataTable inventory = new DataTable();

                    inventory.Columns.Add("ID");
                    inventory.Columns.Add("PartNumber");
                    inventory.Columns.Add("Unit1");
                    inventory.Columns.Add("PartDescription");
                    inventory.Columns.Add("VendorCode");
                    inventory.Columns.Add("CustomerCode");
                    inventory.Columns.Add("GLCode");
                    inventory.Columns.Add("ProductCode");
                    inventory.Columns.Add("QtyInProcess");
                    inventory.Columns.Add("QtyOnOrder");
                    inventory.Columns.Add("QtyReserved");
                    inventory.Columns.Add("QtyConsumed");
                    inventory.Columns.Add("QtyOutside");
                    inventory.Columns.Add("QtyOnHand");
                    inventory.Columns.Add("UnitCost");
                    inventory.Columns.Add("OnHandCost");
                    inventory.Columns.Add("Bins");
                    
                    //Adds each record from CSVReader into the temp table inventory
                    foreach (var record in records)
                    {                       
                        DataRow row = inventory.NewRow();
                                                
                        row["PartNumber"] = record.partnumber;
                        row["Unit1"] = record.unit1;
                        row["PartDescription"] = record.partdescription;
                        row["VendorCode"] = record.vendorcode;
                        row["CustomerCode"] = record.customercode;
                        row["GLCode"] = record.glcode;
                        row["ProductCode"] = record.productcode;
                        row["QtyInProcess"] = record.qtyinprocess;
                        row["QtyOnOrder"] = record.qtyonorder;
                        row["QtyReserved"] = record.qtyreserved;
                        row["QtyConsumed"] = record.qtyconsumed;
                        row["QtyOutside"] = record.qtyoutside;
                        row["QtyOnHand"] = record.qtyonhand;
                        row["UnitCost"] = record.unitcost;
                        row["OnHandCost"] = record.onhandcost;
                        row["Bins"] = record.bins;
                                                
                        inventory.Rows.Add(row);

                    }
                    //Update records to Database: Inventory Table
                    //Opens SQL Connection to database
                    //Clears all records from table Inventory
                    //BulkCopies all records from CSVHelper Table inventory to SQL Database Inventory

                    string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\matth\source\repos\smDSS\SMData.mdf; Integrated Security = True";

                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {


                        sqlConnection.Open();

                        //Delete old records
                        SqlCommand dCommand;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        String dSql = "";
                        dSql = "DELETE Inventory WHERE Id LIKE '%'";
                        dCommand = new SqlCommand(dSql, sqlConnection);

                        adapter.DeleteCommand = new SqlCommand(dSql, sqlConnection);
                        adapter.DeleteCommand.ExecuteNonQuery();
                        dCommand.Dispose();

                        //Copy in new records
                        SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection);
                        //BulkCopy columnMappings
                        bulkCopy.DestinationTableName = "Inventory";
                        bulkCopy.ColumnMappings.Add("PartNumber", "PartNumber");
                        bulkCopy.ColumnMappings.Add("Unit1", "Unit1");
                        bulkCopy.ColumnMappings.Add("PartDescription", "PartDescription");
                        bulkCopy.ColumnMappings.Add("VendorCode", "VendorCode");
                        bulkCopy.ColumnMappings.Add("CustomerCode", "CustomerCode");
                        bulkCopy.ColumnMappings.Add("GLCode", "GLCode");
                        bulkCopy.ColumnMappings.Add("ProductCode", "ProductCode");
                        bulkCopy.ColumnMappings.Add("QtyInProcess", "QtyInProcess");
                        bulkCopy.ColumnMappings.Add("QtyOnOrder", "QtyOnOrder");
                        bulkCopy.ColumnMappings.Add("QtyReserved", "QtyReserved");
                        bulkCopy.ColumnMappings.Add("QtyConsumed", "QtyConsumed");
                        bulkCopy.ColumnMappings.Add("QtyOutside", "QtyOutside");
                        bulkCopy.ColumnMappings.Add("QtyOnHand", "QtyOnHand");
                        bulkCopy.ColumnMappings.Add("UnitCost", "UnitCost");
                        bulkCopy.ColumnMappings.Add("OnHandCost", "OnHandCost");
                        bulkCopy.ColumnMappings.Add("Bins", "Bins");
                        //Writes all records to sqlConnection (Inventory Table)
                        bulkCopy.WriteToServer(inventory);
                        sqlConnection.Close();
                    }

                }
            }
        }
       
        //ClassMapping for the temp table inventory
        public class InventoryClassMap : ClassMap<Inventory>
        {
            //Header Mapping for the Inventory CSV Reader
            public InventoryClassMap()
            {
                Map(m => m.partnumber).Name("PartNumber");
                Map(m => m.unit1).Name("Unit1");
                Map(m => m.partdescription).Name("PartDescription");
                Map(m => m.vendorcode).Name("VendorCode");
                Map(m => m.customercode).Name("CustomerCode");
                Map(m => m.glcode).Name("GLCode");
                Map(m => m.productcode).Name("ProductCode");
                Map(m => m.qtyinprocess).Name("QtyInProcess");
                Map(m => m.qtyonorder).Name("QtyOnOrder");
                Map(m => m.qtyreserved).Name("QtyReserved");
                Map(m => m.qtyconsumed).Name("QtyConsumed");
                Map(m => m.qtyoutside).Name("QtyOutside");
                Map(m => m.qtyonhand).Name("QtyOnHand");
                Map(m => m.unitcost).Name("UnitCost");
                Map(m => m.onhandcost).Name("OnHandCost");
                Map(m => m.bins).Name("Bins");
               
            }

        } 
        //Column Name strings for the temp tabel inventory
        public class Inventory
        {
            //Columns from the PN Inventory Listing csv
            public string partnumber { get; set; }
            public string unit1 { get; set; }
            public string partdescription { get; set; }
            public string vendorcode { get; set; }
            public string customercode { get; set; }
            public string glcode { get; set; }
            public string productcode { get; set; }
            public string qtyinprocess { get; set; }
            public string qtyonorder { get; set; }
            public string qtyreserved { get; set; }
            public string qtyconsumed { get; set; }
            public string qtyoutside { get; set; }
            public string qtyonhand { get; set; }
            public string unitcost { get; set; }
            public string onhandcost { get; set; }
            public string bins { get; set; }

        }
    }
}
