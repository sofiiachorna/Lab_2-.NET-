using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ShowXml : IShowXml
    {
        private readonly ISerialization serialized;
        private readonly ICreateXmlDocument create;
        public ShowXml(ISerialization serialized, ICreateXmlDocument create)
        {
            this.serialized = serialized;
            this.create = create;
        }

        private string teachers { get; } = "D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\teachers.xml";
        private string subjects { get; } = "D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\subjects.xml";
        private string specialtysubjects { get; } = "D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\specialtysubjects.xml";
        private string specialties { get; } = "D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\specialties.xml";
        public void chooseXml()
        {
            Console.WriteLine("Оберіть метод виведення:");
            Console.WriteLine("d - якщо XmlDocument, s - якщо XmlSerializer");
            string m = Console.ReadLine();
            if(m.StartsWith("d"))
            {
                checklistsXmlDocument();
                showDocument();
            }
            else
            {
                checklistsSerialized();
                showSerialized();
            }
        }
        private void showDocument()
        {
            Console.WriteLine("Список викладачів:");
            foreach(var Teacher in create.TeacherFromXml(teachers))
            {
                Console.WriteLine(Teacher);
            }
            Console.WriteLine("____________________________");
            Console.WriteLine("Список спеціальностей:");
            foreach (var Specialty in create.SpecialtyFromXml(specialties))
            {
                Console.WriteLine(Specialty);
            }
            Console.WriteLine("____________________________");
            Console.WriteLine("Список дисциплін:");
            foreach (var Subject in create.SubjectFromXml(subjects))
            {
                Console.WriteLine(Subject);
            }
            Console.WriteLine("____________________________");
            Console.WriteLine("Список зв'язків між спеціальністю і предметом:");
            foreach (var SpecialtySubject in create.SpecialtySubjectFromXml(specialtysubjects))
            {
                Console.WriteLine(SpecialtySubject);
            }
        }
        private void showSerialized()
        {
            Console.WriteLine("Список викладачів:");
            foreach(var Teacher in serialized.XmlserializeTeacher(teachers))
            {
                Console.WriteLine(Teacher);
            }
            Console.WriteLine("____________________________");
            Console.WriteLine("Список дисциплін:");
            foreach (var Subject in serialized.XmlserializeSubject(subjects))
            {
                Console.WriteLine(Subject);
            }
            Console.WriteLine("____________________________");
            Console.WriteLine("Список спеціальностей:");
            foreach (var add in serialized.XmlserializeSpecialty(specialties))
            {
                Console.WriteLine(add);
            }
            Console.WriteLine("____________________________");
            Console.WriteLine("Список зв'язків між спеціальністю і предметом:");
            foreach (var book in serialized.XmlserializeSpecialtySubject(specialtysubjects))
            {
                Console.WriteLine(book);
            }
        }

        private void checklistsXmlDocument()
        {
            int count = 0;
            if (create.SpecialtySubjectFromXml(specialtysubjects).Count.Equals(0))
                count++;
            if (create.SpecialtyFromXml(specialties).Count.Equals(0))
                count++;
            if (create.SubjectFromXml(subjects).Count.Equals(0))
                count++;
            if (create.TeacherFromXml(teachers).Count.Equals(0))
                count++;

            if(count > 0)
            {
                Console.WriteLine("Перевірте ваші файли!");
                Environment.Exit(0);
            }

        }

        private void checklistsSerialized()
        {
            int count = 0;
            if (serialized.XmlserializeTeacher(teachers).Count.Equals(0))
                count++;
            if (serialized.XmlserializeSubject(subjects).Count.Equals(0))
                count++;
            if (serialized.XmlserializeSpecialtySubject(specialtysubjects).Count.Equals(0))
                count++;
            if (serialized.XmlserializeSpecialty(specialties).Count.Equals(0))
                count++;

            if (count > 0)
            {
                Console.WriteLine("Перевірте ваші файли!");
                Environment.Exit(0);
            }

        }
    }
}
