using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataBaseCloner.Init.NewDB;
using DataBaseCloner.NewDB;
using DataBaseCloner.OldDB;
using NHibernate;
using NHibernate.Cfg;

namespace DataBaseCloner
{
    class Program
    {
        static void Main(string[] args)
        {
            var mysqDB = ConfigureMySQL();

            
            var MSSQLDB = ConfigureMSSQL();

            using (var session = MSSQLDB.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    IList<oper> opers = session.CreateCriteria<oper>().List<oper>();
                    Console.WriteLine(opers.Count);
                    tx.Commit();
                }

                Console.ReadLine();
            }

            //using (var mysqlSession = mysqDB.OpenSession())
            //    using (var tx = mysqlSession.BeginTransaction())
            //    {


            //    #region MyRegion
            //        //foreach (Firm elFirm in NewInitializer.InitFirms())
            //        //    mysqlSession.Save(elFirm);


            //        //List<Firm> firms =(List<Firm>)mysqlSession.CreateSQLQuery("Select * from firm").AddEntity(typeof(Firm)).List<Firm>();

            //        //List<Bank> banks = new List<Bank>
            //        //{
            //        //    new Bank("splitAccount", "Приватбанк", "092341", "12345", "12345", firms[0]),
            //        //    new Bank("splitAccount2", "Альфабанк", "6543", "54321", "54321",firms[0]),
            //        //    new Bank("Розрахунковий", "Ощадбанк", "номер", "09876", "67890",firms[1]),
            //        //    new Bank("Другий раx", "Дельтабанк", "092341", "12345", "12345",firms[1]),
            //        //    new Bank("Account", "Райфайзенд банк Аваль", "092341", "12345", "12345",firms[2])
            //        //};

            //        //foreach (Bank bank in banks)
            //        //{
            //        //    mysqlSession.Save(bank);
            //        //}
            //    //                    foreach (Doctor doctor in NewInitializer.InitDoctors())
            //    //                        session.Save(doctor);
            //    //
            //    //                    foreach (PatientCategory category in NewInitializer.InitPatientCats())
            //    //                        session.Save(category);
            //    //
            //    //                    foreach (Patient patient in NewInitializer.InitPatients())
            //    //                        session.Save(patient);
            //    //
            //    //                    foreach (Photo photo in NewInitializer.InitPhotos())
            //    //                        session.Save(photo);
            //    //
            //    //                    foreach (PhoneNumber phoneNumber in NewInitializer.InitPhoneNumbers())
            //    //                        session.Save(phoneNumber);
            //    //
            //    //                    foreach (VisitCategory visitCategory in NewInitializer.InitVisitCategories())
            //    //                        session.Save(visitCategory);
            //    //
            //    //                    foreach (Matherial matherial in NewInitializer.InitMatherials())
            //    //                        session.Save(matherial);
            //    //
            //    //                    foreach (Paragraph paragraph in NewInitializer.InitParagraphs())
            //    //                        session.Save(paragraph);
            //    //
            //    //                    foreach (Manipulation manipulation in NewInitializer.InitManipulations())
            //    //                        session.Save(manipulation);
            //    //
            //    //                    foreach (Operation operation in NewInitializer.InitOperations())
            //    //                        session.Save(operation);
            //    //
            //    //                    foreach (Visit visit in NewInitializer.InitVisits())
            //    //                        session.Save(visit);
            //    //
            //    //                    foreach (Cash cash in NewInitializer.InitCashes())
            //    //                        session.Save(cash);
            //    #endregion

            //    tx.Commit();
            
            //    }

            Console.WriteLine("Succes!!!");
        }

        public static ISessionFactory ConfigureMSSQL()
        {
            //Configuration MSSQLConfiguration = new Configuration();

            //string MSSQLConnection = "Data Source =(local); Integrated Security = True; database=Stomatologia";
            //MSSQLConfiguration.DataBaseIntegration(x =>
            //{
            //    x.ConnectionString = MSSQLConnection;
            //    x.LogSqlInConsole = true;
            //    x.Driver<NHibernate.Driver.Sql2008ClientDriver>();
            //    x.Dialect<NHibernate.Dialect.MsSql2008Dialect>();
            //});


            //MSSQLConfiguration.AddAssembly(Assembly.GetExecutingAssembly());
            //return MSSQLConfiguration.BuildSessionFactory();
            return new Configuration()
                .Configure(@"D:\proj\Stom_2_0\StomV2\DataBaseCloner\DataBaseCloner\MSSQL_nhibernate.cfg.xml")
                .BuildSessionFactory();
        }

        public static ISessionFactory ConfigureMySQL()
        {
            return new Configuration()
                .Configure(@"D:\proj\Stom_2_0\StomV2\DataBaseCloner\DataBaseCloner\hibernate.cfg.xml")
                .BuildSessionFactory();
        }
    }
}
