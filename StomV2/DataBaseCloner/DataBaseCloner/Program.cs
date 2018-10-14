using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;

namespace DataBaseCloner
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration cfg = new Configuration();

            string connection = "Data Source =MAYHEM\\SQLEXPRESS; Integrated Security = True; database=Stomatologia";
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = connection;
                x.LogSqlInConsole = true;
                x.Driver<NHibernate.Driver.Sql2008ClientDriver>();
                x.Dialect<NHibernate.Dialect.MsSql2008Dialect>();
            });
        }
    }
}
