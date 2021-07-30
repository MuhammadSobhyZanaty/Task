using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using DB;
using Newtonsoft.Json;

namespace WebAPI.Areas
{
    public class InvoicePrintServices
    {
        public NORTHWNDEntities entity = new NORTHWNDEntities();

        public List<InvoicePrint> GetALL()
        {
            return entity.InvoicePrints.ToList();
        }
        public InvoicePrint GetOne(int InvoiceID)
        {
            return entity.InvoicePrints.FirstOrDefault(e => e.InvoiceID == InvoiceID);
        }
        public void Add(InvoicePrint InvoicePrintObj)
        {
            entity.InvoicePrints.Add(InvoicePrintObj);
            entity.SaveChanges();
        }
        public void Delete(InvoicePrint InvoicePrintObj)
        {
            entity.InvoicePrints.Remove(InvoicePrintObj);
            entity.SaveChanges();
        }
        public void Update(InvoicePrint InvoicePrintObj)
        {
            entity.InvoicePrints.AddOrUpdate(InvoicePrintObj);
            entity.SaveChanges();
        }
        public void ExportJsonFiles()
        {
            var X = GetALL();
            for (int i = 0; i < X.Count; i++)
            {
                string json = JsonConvert.SerializeObject(X[i], Formatting.None,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
                //Path for JSON File
                System.IO.File.WriteAllText(@"C:\Users\lulud\Downloads\Compressed\ElsabaautoService\JSON Files\" + X[i].InvoiceNo + ".json", json);
            }
        }
        public void ExportOneJsonFile(int InvoiceID)
        {
            var X = GetOne(InvoiceID);
            string json = JsonConvert.SerializeObject(X, Formatting.None,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
                //Path for JSON File
                System.IO.File.WriteAllText(@"C:\Users\lulud\Downloads\Compressed\ElsabaautoService\JSON Files\" + X.InvoiceNo + ".json", json);
            
        }

    }

}
