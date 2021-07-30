using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DB;

namespace WebAPI.Areas
{
    public class InvoiceServices
    {
        public NORTHWNDEntities entity = new NORTHWNDEntities();
        //Start of Invoice Table
        public List<Invoice> GetALL()
        {
            return entity.Invoices.ToList();
        }        
        public Invoice GetOne(int InvoiceId)
        {
            return entity.Invoices.FirstOrDefault(e=>e.InvoiceID==InvoiceId);
        }
        public void Add(Invoice InvoiceObj)
        {
            entity.Invoices.Add(InvoiceObj);
            entity.SaveChanges();
        }
        public void Delete(Invoice InvoiceObj)
        {
            entity.Invoices.Remove(InvoiceObj);
            entity.SaveChanges();
        }
        public void Update(Invoice InvoiceObj)
        {
            entity.Invoices.AddOrUpdate(InvoiceObj);
            entity.SaveChanges();
        }
        // end Of InvoiceTable
    }
}