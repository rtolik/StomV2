using System;
using DataBaseCloner.NewDB;
using System.Collections.Generic;
using System.Collections;
using DataBaseCloner.NewDB.Enum;

namespace DataBaseCloner.Init.NewDB
{
    public static class NewInitializer
    {
        public static List<Firm> InitFirms()
        {
            List<Firm> firms = new List<Firm>
            {
                new Firm("Стоматологія", "1123", false),
                new Firm("МаксСтом", "2143", false),
                new Firm("Експрес Зуби", "3323", true)
            };

            return firms;
        }

        public static List<Doctor> InitDoctors()
        {
            List<Doctor> doctors = new List<Doctor>
            {
                new Doctor("Курчмановський Петро Омарович", 1),
                new Doctor("Кучма Іван Олексійович", 1),
                new Doctor("Іваниця Роман Олександрович", 2),
                new Doctor("Меркурій Іван Петрович", 2),
                new Doctor("Ситник Іван Леонтійович", 3),
                new Doctor("Микитюк Леся Володимирівна", 3),
                new Doctor("Трубич Олексій Петрович", 3),
                new Doctor("Паляниця Катерина Федорівна", 1)
            };

            return doctors;
        }

        public static List<PatientCategory> InitPatientCats()
        {
            List<PatientCategory> patientCats = new List<PatientCategory>
            {
                new PatientCategory("Простий", 0),
                new PatientCategory("Друзі",10),
                new PatientCategory("Сім'я", 15),
                new PatientCategory("Інвалід", 12)
            };

            return patientCats;
        }

        public static List<Patient> InitPatients()
        {

            List<Patient> patients = new List<Patient>
            {
                new Patient("1111", new DateTime(2018,11,19), "Романюк Анатолій Миколайович", 1, 1, "Пр. Червоної Калини 88 24", 10, "", "Алергій нема", @"D:\proj\Stom_2_0\DB\Diag.png", false ),
                new Patient("2222", new DateTime(2017,12,13), "Марусевич Євгеній Петрович", 2, 1, "Пр. Червоної Калини 14 9", 0, "проблемний пацієнт", "Алергій нема", @"D:\proj\Stom_2_0\DB\Diag.png", false ),
                new Patient("3333", new DateTime(2018,09,22), "Кункевич Марк Олегович", 3, 2, "Наукова 6А 133", 0, "", "Алергія на Ібупрофен", @"D:\proj\Stom_2_0\DB\Diag.png", true ),
                new Patient("4444", new DateTime(2018,04,11), "Керита Михайло Іванович", 4, 2,"пр. Шевченка 15 62", 0, "Любить поговорити", "Алергія на Анастезію" ,@"D:\proj\Stom_2_0\DB\Diag.png", false ),
                new Patient("5555", new DateTime(2018,01,05), "Кромкевич Остап Ігорович", 1, 3, "пр. Свободи 55 76", 0, "", "Алергій нема", @"D:\proj\Stom_2_0\DB\Diag.png", false )
            };

            return patients;
        }

        public static List<PhoneNumber> InitPhoneNumbers()
        {
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>
            {
                new PhoneNumber("0938119806", 1),
                new PhoneNumber("0664378596", 1),
                new PhoneNumber("0673406614", 2),
                new PhoneNumber("0676708823", 2),
                new PhoneNumber("0938119804", 3),
                new PhoneNumber("0504495051", 4),
                new PhoneNumber("0997645411", 5)
            };

            return phoneNumbers;
        }

        public static List<Photo> InitPhotos()
        {
            List<Photo> photos = new List<Photo>
            {
                new Photo(@"D:\proj\Stom_2_0\Img\Photo_Black.png", 1, "Рентген 05 зуба від 12.05.2018"),
                new Photo(@"D:\proj\Stom_2_0\Img\Photo_White.png", 1, "Рентген нижньої щелепи від 07.10.2018"),
                new Photo(@"D:\proj\Stom_2_0\Img\PersonalCard_Black.png", 2, "Загальний знімок"),
                new Photo(@"D:\proj\Stom_2_0\Img\PersonalCard_White.png", 3, "Знімок після проведення операції"),
                new Photo(@"D:\proj\Stom_2_0\Img\Add_Black.png", 4, "Рентген 25 зуба від 22.11.1999"),
                new Photo(@"D:\proj\Stom_2_0\Img\Add_White.png", 5, "Загальний знімок нижньої щелепи"),

            };

            return photos;
        }

        public static List<Cash> InitCashes()
        {
            List<Cash> cashes = new List<Cash>
            {
                new Cash(1, 1, new DateTime(2018,11,25), 300, "Оплата пломбування"),
                new Cash(1, 1, new DateTime(2018,12,05), 700, "Оплата операції"),
                new Cash(2, 1, new DateTime(2018,09,15), 150, "Оплата планового огляду"),
                new Cash(3, 2, new DateTime(2018,05,12), 450, "Оплата виготовлення протезу"),
                new Cash(4, 2, new DateTime(2018,01,02), 1500, "Оплата встановлення штифтів"),
                new Cash(5, 3, new DateTime(2018,03,30), 650, "Оплата лікування карієсу")
            };

            return cashes;
        }


        public static List<Bank> InitFirmsWithBanks()
        {
//            List<Bank> banks = new List<Bank>
//            {
//                new Bank("splitAccount", "Приватбанк", "092341", "12345", "12345", InitFirms()[0]),
//                new Bank("splitAccount2", "Альфабанк", "6543", "54321", "54321",InitFirms()[0]),
//                new Bank("Розрахунковий", "Ощадбанк", "номер", "09876", "67890",InitFirms()[1]),
//                new Bank("Другий раx", "Дельтабанк", "092341", "12345", "12345",InitFirms()[2]),
//                new Bank("Account", "Райфайзенд банк Аваль", "092341", "12345", "12345",InitFirms()[2])
//            };

//            return banks;
            return null;
        }

        public static List<VisitCategory> InitVisitCategories()
        {
            List<VisitCategory> visitCategories = new List<VisitCategory>
            {
                new VisitCategory("Плановий"),
                new VisitCategory("Лікування"),
                new VisitCategory("Протезування"),
                new VisitCategory("Чистка")
            };

            return visitCategories;
        }

        public static List<Paragraph> InitParagraphs()
        {
            List<Paragraph> paragraphs = new List<Paragraph>
            {
                new Paragraph("Пломбування", true),
                new Paragraph("Ортодонтія", false)
            };

            return paragraphs;
        }

        public static List<Manipulation> InitManipulations()
        {
            List<Manipulation> manipulations =  new List<Manipulation>
            {
                new Manipulation("Очистка", 20,2),
                new Manipulation("Пломбування", 900,1)
            };

            return manipulations;
        }

        public static List<Matherial> InitMatherials()
        {
            List<Matherial> matherials = new List<Matherial>
            {
                new Matherial("Паста", MatherialType.Arrival, DateTime.Now, 15, 150f,1),
                new Matherial("Фотополімерний матеріал", MatherialType.Arrival, DateTime.Now, 25, 100f,2),
                new Matherial("Набір інстркментів для дослідження зуба", MatherialType.Arrival, new DateTime(2018,11,17), 1, 7000f,2)
            };

            return matherials;
        }

        public static List<Visit> InitVisits()
        {
            List<Visit> visits = new List<Visit>
            {
                new Visit("c 24", "терапія", 0, 1, 0, 1, 1, 1, DateTime.Now),
                new Visit("c 08", "терапія", 0, 2, 0, 1, 2, 1, DateTime.Now),
                new Visit("b 66", "терапія", 0, 3, 10, 2, 4, 3, DateTime.Now),
                new Visit("a 12", "терапія", 0, 4, 0, 3, 5, 7, DateTime.Now),
                new Visit("c 24", "терапія", 0, 3, 0, 3, 5, 6, DateTime.Now)
            };

            return visits;
        }

        public static List<Operation> InitOperations()
        {
            List<Operation> operations = new List<Operation>
            {
                new Operation(1, 1, 2, 0, 0, false),
                new Operation(2, 2, 1, 0, 0, true),
                new Operation(3, 1, 4, 0, 0, false),
                new Operation(4, 2, 2, 0, 0, true),
                new Operation(5, 1, 6, 0, 0, false),
                
            };

            return operations;
        }
    }
}