using System;
using System.Collections.Generic;
using System.Linq;
using DataBaseCloner.NewDB;
using DataBaseCloner.OldDB;
using NHibernate;
using NHibernate.Cfg;

namespace DataBaseCloner
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                ISessionFactory mysqDb = ConfigureMySql();

                ISessionFactory mssqldb = ConfigureMssql();

                List<PatientCategory> patientCategories = new List<PatientCategory>();
                List<Patient> patients = new List<Patient>();
                List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
                List<Photo> photos = new List<Photo>();
                List<Matherial> matherials = new List<Matherial>();
                List<Paragraph> paragraphs = new List<Paragraph>();
                List<Manipulation> manipulations = new List<Manipulation>();
                List<Firm> firms = new List<Firm>();
                List<Bank> banks = new List<Bank>();
                List<Cash> cashes = new List<Cash>();
                List<Doctor> doctors = new List<Doctor>();
                List<Visit> visits = new List<Visit>();
                List<Operation> operations = new List<Operation>();
                List<VisitCategory> visitCategories = new List<VisitCategory>
                {
                    new VisitCategory(1, "Стоиатологія (загальна)"),
                    new VisitCategory(2, "Ортопедична стоматологія"),
                    new VisitCategory(3, "Ортодонтична стоматологія"),
                    new VisitCategory(4, "Хірургічна стоматологія"),
                    new VisitCategory(5, "План Лікування")

                };

                DateTime start = DateTime.Now;

                using (ISession session = mssqldb.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        Console.WriteLine("Succesfully configured");

                        DBQuery repository = new DBQuery(session);

                        List<sl_firm> slFirms = repository.FindAll<sl_firm>();
                        List<sl_cat> cats = repository.FindAll<sl_cat>();
                        List<fio> fios = repository.FindAll<fio>();
                        List<Foto> fotos = repository.FindAll<Foto>();
                        List<gotivka> gotivkas = repository.FindAll<gotivka>();
                        List<sl_op_roz> rozList = repository.FindAll<sl_op_roz>();
                        List<material> materials = repository.FindAll<material>();
                        List<sl_op_op> ops = repository.FindAll<sl_op_op>();
                        List<sl_likar> likars = repository.FindAll<sl_likar>();
                        List<priom> prioms = repository.FindAll<priom>();
                        List<pl_pr> plPrs = repository.FindAll<pl_pr>();
                        List<oper> opers = repository.FindAll<oper>();
                        List<pl_oper> pl_opers = repository.FindAll<pl_oper>();

                        Dictionary<priom, Visit> PriomVisitDictionary = new Dictionary<priom, Visit>();
                        Dictionary<pl_pr, Visit> PlpriomVisitDictionary = new Dictionary<pl_pr, Visit>();

                        InitFirms(firms, slFirms, banks);
                        InitPatientCategories(cats, patientCategories);
                        InitPatients(fios, patients, patientCategories, firms, phoneNumbers, prioms);
                        InitPatientPhotos(fotos, photos, patients);
                        InitCashes(gotivkas, cashes, patients, firms);
                        InitParagraphs(rozList, paragraphs);
                        InitMatherials(materials, repository, matherials, paragraphs);
                        InitManipulations(ops, manipulations, paragraphs);
                        InitDoctors(likars, doctors, firms);
                        InitVisitsFromPrioms(prioms, visits, visitCategories, firms, doctors, patients,
                            PriomVisitDictionary);
                        InitVisitsFromPlprioms(plPrs, visits, visitCategories, firms, doctors, patients,
                            PlpriomVisitDictionary);
                        InitOperstionsFromOpers(opers, operations, manipulations, PriomVisitDictionary);
                        InitOperationsFromPlopers(pl_opers, operations, manipulations, PlpriomVisitDictionary);

                        tx.Commit();
                    }

                    Console.WriteLine("Succes read!!!\nWith Time: {0}", DateTime.Now - start);
                    Console.ReadLine();
                }

                firms.Add(new Firm("Загальна Фірма", "122", true));


                start = DateTime.Now;
               
                using (ISession mysqlSession = mysqDb.OpenSession())
                {
                    using (ITransaction transaction = mysqlSession.BeginTransaction())
                    {
                        Console.WriteLine("Configured MySQL");
                        DBQuery repo = new DBQuery(mysqlSession);

                        Console.WriteLine("Visit Categories: " + visitCategories.Count);
                        repo.Save(visitCategories);

                        Console.WriteLine("Firms: " + firms.Count);
                        repo.Save(firms);

                        Console.WriteLine("Banks: " + banks.Count);
                        repo.Save(banks);

                        Console.WriteLine("Patient Categories: " + patientCategories.Count);
                        repo.Save(patientCategories);

                        Console.WriteLine("Patients : " + patients.Count);
                        repo.Save(patients);

                        Console.WriteLine("PhoneNumbers : " + patients.Count);
                        repo.Save(phoneNumbers);

                        Console.WriteLine("Patient Photos: " + phoneNumbers.Count);
                        repo.Save(photos);

                        Console.WriteLine("Cashes: " + cashes.Count);
                        repo.Save(cashes);

                        Console.WriteLine("Paragraphs: " + paragraphs.Count);
                        repo.Save(paragraphs);

                        Console.WriteLine("Matherials: " + matherials.Count);
                        repo.Save(matherials);

                        Console.WriteLine("Manipulations: " + manipulations.Count);
                        repo.Save(manipulations);

                        Console.WriteLine("Doctors: " + doctors.Count);
                        repo.Save(doctors);

                        Console.WriteLine("Visits: " + visits.Count);
                        repo.Save(visits);

                        Console.WriteLine("Operations: " + operations.Count);
                        repo.Save(operations);

                        transaction.Commit();
                    }

                    Console.WriteLine("Succesfully wrote!!!\nWith Time: {0}", DateTime.Now - start);
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }


        public static ISessionFactory ConfigureMssql()
        {
            return new Configuration()
                .Configure(@"MSSQL_nhibernate.cfg.xml")
                .BuildSessionFactory();
        }

        public static ISessionFactory ConfigureMySql()
        {
            return new Configuration()
                .Configure(@"hibernate.cfg.xml")
                .BuildSessionFactory();
        }
        
        private static void InitOperationsFromPlopers(List<pl_oper> pl_opers, List<Operation> operations,
            List<Manipulation> manipulations,
            Dictionary<pl_pr, Visit> PlpriomVisitDictionary)
        {
            foreach (pl_oper pl_oper in pl_opers)
                if (pl_oper.oper != null && pl_oper.priom?.likar != null && PlpriomVisitDictionary.ContainsKey(pl_oper.priom))
                    operations.Add(
                        new Operation(
                            pl_oper,
                            manipulations.Find(manipulation => manipulation.Id == pl_oper.oper.id_op),
                            PlpriomVisitDictionary[pl_oper.priom]
                        )
                    );
        }

        private static void InitOperstionsFromOpers(List<oper> opers, List<Operation> operations,
            List<Manipulation> manipulations,
            Dictionary<priom, Visit> PriomVisitDictionary)
        {
            foreach (oper oper in opers)
                if (oper.sl_operId != null && oper.priom?.likar != null && PriomVisitDictionary.ContainsKey(oper.priom))
                    operations.Add(
                        new Operation(
                            oper,
                            manipulations.Find(manipulation => manipulation.Id == oper.sl_operId.id_op),
                            PriomVisitDictionary[oper.priom]
                        )
                    );
        }

        private static void InitVisitsFromPlprioms(List<pl_pr> plPrs, List<Visit> visits,
            List<VisitCategory> visitCategories, List<Firm> firms, List<Doctor> doctors,
            List<Patient> patients, Dictionary<pl_pr, Visit> PlpriomVisitDictionary)
        {
            int start = visits.Count;
            foreach (pl_pr pl_pr in plPrs)
                if (pl_pr.fio != null && pl_pr.firma != null && pl_pr.likar != null &&
                    firms.Find(firm => firm.Id == pl_pr.firma.id) != null &&
                    doctors.Find(doctor => doctor.Id == pl_pr.likar.id_likar) != null &&
                    patients.Find(patient => patient.Id == pl_pr.fio.id) != null)
                {
                    visits.Add(
                        new Visit(
                            pl_pr,
                            visitCategories.Find(cat => cat.Id == pl_pr.cat+1),
                            firms.Find(firm => firm.Id == pl_pr.firma.id),
                            doctors.Find(doctor => doctor.Id == pl_pr.likar.id_likar),
                            patients.Find(patient => patient.Id == pl_pr.fio.id)
                        )
                    );
                    PlpriomVisitDictionary.Add(pl_pr, visits.Last());
                }

            for (int i = start; i < visits.Count; i++)
                visits[i].Id = i + 1;
        }

        private static void InitVisitsFromPrioms(List<priom> prioms, List<Visit> visits,
            List<VisitCategory> visitCategories, List<Firm> firms, List<Doctor> doctors,
            List<Patient> patients, Dictionary<priom, Visit> PriomVisitDictionary)
        {
            foreach (priom pr in prioms)
                if (pr.fio != null && pr.firma != null && pr.likar != null &&
                    firms.Find(firm => firm.Id == pr.firma.id)!=null &&
                    doctors.Find(doctor => doctor.Id == pr.likar.id_likar)!=null &&
                    patients.Find(patient => patient.Id == pr.fio.id)!=null)
                {
                    visits.Add(
                        new Visit(
                            pr,
                            visitCategories.Find(cat => cat.Id == pr.cat+1),
                            firms.Find(firm => firm.Id == pr.firma.id),
                            doctors.Find(doctor => doctor.Id == pr.likar.id_likar),
                            patients.Find(patient => patient.Id == pr.fio.id)
                        )
                    );
                    PriomVisitDictionary.Add(pr, visits.Last());
                }

            for (int i = 0; i < visits.Count; i++)
                visits[i].Id = i + 1;
        }

        private static void InitDoctors(List<sl_likar> likars, List<Doctor> doctors, List<Firm> firms)
        {
            foreach (sl_likar likar in likars)
                doctors.Add(new Doctor(likar, firms[0]));
        }

        private static void InitManipulations(List<sl_op_op> ops, List<Manipulation> manipulations,
            List<Paragraph> paragraphs)
        {
            foreach (sl_op_op op in ops)
                if (op.id_rozd != null && op.n_op!=null)
                    manipulations.Add(
                        new Manipulation(
                            op,
                            paragraphs.Find(paragraph => paragraph.Id == op.id_rozd.id_roz)
                        )
                    );
        }

        private static void InitMatherials(List<material> materials, DBQuery repository, List<Matherial> matherials,
            List<Paragraph> paragraphs)
        {
            foreach (material material in materials)
                if (material.mat != null)
                {
                    sl_op_op operation = repository.FindOne<sl_op_op>(material.mat.id_op);
                    if (operation != null)
                        matherials.Add(
                            new Matherial(
                                material,
                                operation,
                                paragraphs.Find(paragraph => paragraph.Id == operation.id_rozd.id_roz)
                            )
                        );
                }
        }

        private static void InitParagraphs(List<sl_op_roz> rozList, List<Paragraph> paragraphs)
        {
            foreach (sl_op_roz roz in rozList)
                paragraphs.Add(new Paragraph(roz));
        }

        private static void InitCashes(List<gotivka> gotivkas, List<Cash> cashes, List<Patient> patients,
            List<Firm> firms)
        {
            foreach (gotivka gotivka in gotivkas)
                if (gotivka.fio != null && gotivka.firm != null && 
                    patients.Find(patient => patient.Id == gotivka.fio.id)!=null && 
                    firms.Find(firm => firm.Id == gotivka.firm.id)!=null)
                    cashes.Add(
                        new Cash(
                            gotivka,
                            patients.Find(patient => patient.Id == gotivka.fio.id),
                            firms.Find(firm => firm.Id == gotivka.firm.id)
                        )
                    );
        }

        private static void InitPatientPhotos(List<Foto> fotos, List<Photo> photos, List<Patient> patients)
        {
            foreach (Foto foto in fotos)
                if (foto.fio != null && patients.Find(pat => pat.Id == foto.fio.id)!=null)
                    photos.Add(new Photo(foto, patients.Find(pat => pat.Id == foto.fio.id)));
        }

        private static void InitPatients(List<fio> fios, List<Patient> patients,
            List<PatientCategory> patientCategories, List<Firm> firms, List<PhoneNumber> phoneNumbers, List<priom> prioms)
        {
            foreach (fio fio in fios)
            {
                if (fio.cat != null)
                {
                    patients.Add(
                        new Patient(
                            fio,
                            patientCategories.Find(cat => cat.Id == fio.cat.id_cat),
                            prioms.Exists(pr => pr.fio.id == fio.id) ? firms.Find(firm => firm.Id == prioms.First(pr => pr.fio.id == fio.id).firma.id) : firms.Last()
                        )
                    );
                    phoneNumbers.Add(new PhoneNumber(patients.Last(), fio, true));
                    phoneNumbers.Add(new PhoneNumber(patients.Last(), fio, false));
                }
            }
        }

        private static void InitPatientCategories(List<sl_cat> cats, List<PatientCategory> patientCategories)
        {
            foreach (sl_cat cat in cats)
                patientCategories.Add(new PatientCategory(cat));
        }

        private static void InitFirms(List<Firm> firms, List<sl_firm> slFirms, List<Bank> banks)
        {
            firms.Add(new Firm(9922, "Загальна", "null", true));

            foreach (sl_firm slFirm in slFirms)
                if(slFirm?.kod!=null){
                    firms.Add(new Firm(slFirm));
                    banks.Add(new Bank(firms.Last(), slFirm, true));
                    banks.Add(new Bank(firms.Last(), slFirm, false));
                }
        }

    }
}