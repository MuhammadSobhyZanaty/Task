using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DB;

namespace WebAPI.Areas
{
    public class InvoiceSetupservices
    {
        public NORTHWNDEntities entity = new NORTHWNDEntities();
        public InvoiceSetup InvoiceSetUPCheck(int InvoiceId)
        {
            return entity.InvoiceSetups.FirstOrDefault(e => e.InvoiceID == InvoiceId);
        }
        public int SeqNextValue()
        {
            ObjectParameter OutputParamInt = new ObjectParameter("seqnextval", typeof(Int32));
            entity.SeqNextVal(OutputParamInt);
            int seqvalue = Convert.ToInt32(OutputParamInt.Value);

            return seqvalue;
        }
        public string CreateInvoiceNo(int InvoiceId)
        {
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlParameter InvoiceIDParam = new SqlParameter("@InvoiceID", SqlDbType.Int);
            SqlParameter SeqNextValueParam = new SqlParameter("@SeqNextValue", SqlDbType.Int);
            InvoiceIDParam.Value = InvoiceId;
            SeqNextValueParam.Value = SeqNextValue();

            SqlCommand Query = new SqlCommand("SELECT dbo.CreateInvoiceNo(@InvoiceID,@SeqNextValue)", conn);
            Query.Parameters.Add(InvoiceIDParam);
            Query.Parameters.Add(SeqNextValueParam);

            string result = Query.ExecuteScalar().ToString();

            return result;
        }
        
        public List<InvoiceSetup> GetALL()
        {
            return entity.InvoiceSetups.ToList();
        }
        public InvoiceSetup GetOne(int InvoiceSetupId)
        {
            return entity.InvoiceSetups.FirstOrDefault(e => e.InvoiceID == InvoiceSetupId);
        }
        public InvoiceSetup GetOneInvoice(int InvoiceId)
        {
            return entity.InvoiceSetups.Where(e => e.InvoiceID == InvoiceId).FirstOrDefault();
        }
        public void Add(InvoiceSetup InvoiceSetupObj)
        {
            entity.InvoiceSetups.Add(InvoiceSetupObj);
            entity.SaveChanges();
        }
        public void Delete(InvoiceSetup InvoiceSetupObj)
        {
            entity.InvoiceSetups.Remove(InvoiceSetupObj);
            entity.SaveChanges();
        }
        public void Update(InvoiceSetup InvoiceSetupObj)
        {
            entity.InvoiceSetups.AddOrUpdate(InvoiceSetupObj);
            entity.SaveChanges();
        }
    }
}