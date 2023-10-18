using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DataLayer.validators;
using DataLayer.classes;


namespace DataLayer
{
   public  class CreateXmlDocument: ICreateXmlDocument
    {
        private readonly IValidation validator;

        public CreateXmlDocument(IValidation validator)
        {
            this.validator = validator;
        }
        public List<Teacher> TeacherFromXml(string path)
        {
            if (validator.validate(path))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlElement xRoot = xDoc.DocumentElement;
                List<Teacher> data = new List<Teacher>();
                foreach (XmlNode elem in xRoot.GetElementsByTagName("Teacher"))
                {
                    data.Add(new Teacher(
                        int.Parse(elem["TeacherId"].InnerText),
                        elem["TeacherName"].InnerText));
                }
                TeacherValidator valid = new TeacherValidator();
                if (data.TrueForAll(x => valid.Validate(x).IsValid))
                {
                    return data;
                }
                else
                {
                    foreach (var i in data)
                    {
                        foreach (var failure in valid.Validate(i).Errors)
                        {
                            Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                    }
                    return new List<Teacher>();
                }
                return data;
            }
            else 
                return new List<Teacher>();
            
        }
        public List<Subject> SubjectFromXml(string path)
        {
            if (validator.validate(path))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlElement xRoot = xDoc.DocumentElement;
                List<Subject> data = new List<Subject>();
                foreach (XmlNode elem in xRoot.GetElementsByTagName("Subject"))
                {
                    data.Add(new Subject(
                        int.Parse(elem["SubjectId"].InnerText),
                        elem["SubjectName"].InnerText,
                        int.Parse(elem["TeacherId"].InnerText),
                        elem["TeacherName"].InnerText,
                        (ControlTypeEnum) Enum.Parse(typeof(ControlTypeEnum), elem["ControlType"].InnerText),
                        int.Parse(elem["Hours"].InnerText),
                        int.Parse(elem["SpecialtyId"].InnerText),
                        int.Parse(elem["Course"].InnerText)));
                }
                SubjectValidator valid = new SubjectValidator();
                if (data.TrueForAll(x => valid.Validate(x).IsValid))
                {
                    return data;
                }
                else
                {
                    foreach (var i in data)
                    {
                        foreach (var failure in valid.Validate(i).Errors)
                        {
                            Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                    }
                    return new List<Subject>();
                }
                return data;
            }
            else
                return new List<Subject>();
            
        }
        public List<Specialty> SpecialtyFromXml(string path)
        {
            if (validator.validate(path))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlElement xRoot = xDoc.DocumentElement;
                List<Specialty> data = new List<Specialty>();
                foreach (XmlNode elem in xRoot.GetElementsByTagName("Specialty"))
                {
                    data.Add(new Specialty(
                        int.Parse(elem["SpecialtyId"].InnerText),
                        elem["SpecialtyName"].InnerText));
                }
                SpecialtyValidator valid = new SpecialtyValidator();
                if (data.TrueForAll(x => valid.Validate(x).IsValid))
                {
                    return data;
                }
                else
                {
                    foreach (var i in data)
                    {
                        foreach (var failure in valid.Validate(i).Errors)
                        {
                            Console.WriteLine("Property " + failure.PropertyName + " fSpecialtySubjectailed validation. Error was: " + failure.ErrorMessage);
                        }
                    }
                    return new List<Specialty>();
                }
                return data;
            }
            else
                return new List<Specialty>();
            
        }
        public List<SpecialtySubject> SpecialtySubjectFromXml(string path)
        {
            if (validator.validate(path))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlElement xRoot = xDoc.DocumentElement;
                List<SpecialtySubject> data = new List<SpecialtySubject>();
                foreach (XmlNode elem in xRoot.GetElementsByTagName("SpecialtySubject"))
                {
                    data.Add(new SpecialtySubject(
                        int.Parse(elem["SpecialtyId"].InnerText),
                        int.Parse(elem["SubjectId"].InnerText)));
                }
                SpecialtySubjectValidator valid = new SpecialtySubjectValidator();
                if (data.TrueForAll(x => valid.Validate(x).IsValid))
                {
                    return data;
                }
                else
                {
                    foreach (var i in data)
                    {
                        foreach (var failure in valid.Validate(i).Errors)
                        {
                            Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                    }
                    return new List<SpecialtySubject>();
                }
                return data;
            }
            else
                return new List<SpecialtySubject>();
            
        }
    }
}
