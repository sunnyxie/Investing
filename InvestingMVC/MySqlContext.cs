using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InvestingMVC.Models;

namespace InvestingMVC
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlContext : DbContext
    {
        public DbSet<TranType> types { get; set; }
        public DbSet<InvestingTax> records { get; set; }

        public MySqlContext() : base(@"MyInvesting")
        {
            this.Configuration.LazyLoadingEnabled = false;

            // Database.SetInitializer<MySqlContext>();
        }
        //DbSets....

        public MySqlContext(DbConnection existingConnection, bool contextOwnsConnection)
               : base(existingConnection, contextOwnsConnection)
        {
        }

        public static MySqlContext GetMySqlContext()
        {
            //using (MySqlConnection conn = new MySqlConnection("MyContext"))
            //{
            //    conn.Open();
            //    gsContext = new MySqlContext(conn, false);
            //}
            return null;
        }

        public void GetAllData()
        {
            types.Load();
        }

        public void InsertNewRec(InvestingTax rec)
        {
            records.Add(rec);
        }

        public void InsertData()
        {
            types.Add(new TranType {name = @"Cash Transfer" });
            types.Add(new TranType {name = @"Cash 3" });
            this.SaveChanges();
        }

        //public void Update(Int32 id, Car ent)
        //{
        //    // cars.Load();
        //    Car tmp = this.cars.SingleOrDefault(a => a.id == id);
        //    if (tmp != null)
        //    {
        //        ent.id = id;
        //        tmp = ent;
        //    }

        //}

        public System.Data.DataTable GetAllRecords()
        {
            Console.WriteLine(this.Database.Connection);
            return null;
        }
    }
}