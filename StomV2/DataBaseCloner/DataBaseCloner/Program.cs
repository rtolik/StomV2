using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataBaseCloner.NewDB;
using NHibernate.Cfg;

namespace DataBaseCloner
{
    class Program
    {
        static void Main(string[] args)
        {
            var sefact = new Configuration()
                .Configure(@"D:\proj\Stom_2_0\StomV2\DataBaseCloner\DataBaseCloner\hibernate.cfg.xml")
                .BuildSessionFactory();
            

            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    foreach (Firm elFirm in Init.NewDB.NewInitializer.InitFirms())
                    {
                        session.Save(elFirm);
                    }
                    tx.Commit();;
                }
            }

            Console.WriteLine("Succes!!!");
        }
    }
}
