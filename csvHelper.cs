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


namespace smDSS
{
    internal class csvHelper
    {
        string csvPath = new FormAdmin.SelectedFile().FileName;
        

        public void InventoryReader()
        {
          // csvPath = FormAdmin().sSelectedFile;
            using ( var streamReader = new StreamReader(csvPath))
            {
                using (var Reader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    Reader.Context.RegisterClassMap<InventoryClassMap>();
                    var records = Reader.GetRecords<Inventory>().ToList();
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
