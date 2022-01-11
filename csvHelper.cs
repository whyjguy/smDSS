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

namespace smDSS
{
    internal class csvHelper
    {
        //csvPath is passed through from the Form Admin after the path is selected from the system dialog. 
        //InventoryReader() can also be called by pressing the refresh button on the main form to refresh the data tables.
        public static void InventoryReader(string csvPath)
        {
          
            using ( var streamReader = new StreamReader(csvPath))
            {
                using (var Reader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    Reader.Context.RegisterClassMap<InventoryClassMap>();
                    var records = Reader.GetRecords<Inventory>().ToList();


                    DataTable inventory = new DataTable();
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
                }
            }
        }

        private class InventoryClassMap : ClassMap<Inventory>
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
