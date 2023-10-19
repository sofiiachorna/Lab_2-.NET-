using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using DataLayer.classes;
using DataLayer;

namespace ProcessingLayer
{
    public class ReadConsoleXml: IRead
    {
        private XDocument consoleFile;
        public List<object> read()
        {
            consoleFile = XDocument.Load("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\XmlWriter\\console_input.xml");
            Dictionary<string, List<object>> items = new Dictionary<string, List<object>>()
            {
                {"teachers", getTeachers()},
                {"subjects", getSubjects() },
                {"specialties", getSpecialties() },
                {"specialtysubjects", getSpecialtySubjects()}

            };
            return items[consoleFile.Root.Name.ToString()];
        }
        private List<object> getTeachers()
        {
            var items = consoleFile.Descendants("Teacher");
            return (from item in items
                   select new Teacher(int.Parse(item.Element("TeacherId").Value), item.Element("TeacherName").Value)).ToList<object>();

        }
        private List<object> getSubjects()
        {
            var items = consoleFile.Descendants("Subject");
            return (from item in items
                    select new Subject(int.Parse(item.Element("SubjectId")?.Value), item.Element("SubjectName")?.Value,
                   int.Parse(item.Element("TeacherId")?.Value), item.Element("TeacherName")?.Value, (ControlTypeEnum)Enum.Parse(typeof(ControlTypeEnum), item.Element("ControlType")?.Value),
                   int.Parse(item.Element("Hours")?.Value), int.Parse(item.Element("SpecialtyId")?.Value), int.Parse(item.Element("Course")?.Value))).ToList<object>();

        }
        private List<object> getSpecialties()
        {
            var items = consoleFile.Descendants("Specialty");
            return (from item in items
                    select new Specialty(int.Parse(item.Element("SpecialtyId").Value), item.Element("SpecialtyName").Value)).ToList<object>();

        }
        private List<object> getSpecialtySubjects()
        {
            var items = consoleFile.Descendants("SpecialtySubject");
            return (from item in items
                    select new SpecialtySubject(int.Parse(item.Element("SpecialtyId").Value), int.Parse(item.Element("SubjectId").Value))).ToList<object>();

        }
    }
}
