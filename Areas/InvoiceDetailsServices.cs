using DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace WebAPI.Areas
{
    public class InvoiceDetailsServices
    {
        public NORTHWNDEntities entity = new NORTHWNDEntities();

        public List<InvoiceDetail> GetALL()
        {
            return entity.InvoiceDetails.ToList();
        }
        public InvoiceDetail GetOne(int InvoiceDetailsId)
        {
            return entity.InvoiceDetails.FirstOrDefault(e => e.InvoiceID == InvoiceDetailsId);
        }
        public List<InvoiceDetail> GetInvoice(int InvoiceId)
        {
            return entity.InvoiceDetails.Where(e => e.InvoiceID == InvoiceId).ToList();
        }
        public void Add(InvoiceDetail InvoiceDetailsObj)
        {
            entity.InvoiceDetails.Add(InvoiceDetailsObj);
            entity.SaveChanges();
        }
        public void Delete(InvoiceDetail InvoiceDetailsObj)
        {
            entity.InvoiceDetails.Remove(InvoiceDetailsObj);
            entity.SaveChanges();
        }
        public void Update(InvoiceDetail InvoiceDetailsObj)
        {
            entity.InvoiceDetails.AddOrUpdate(InvoiceDetailsObj);
            entity.SaveChanges();
        }
    }
}