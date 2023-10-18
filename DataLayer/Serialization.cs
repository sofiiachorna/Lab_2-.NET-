using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.ComTypes;
using DataLayer.validators;
using DataLayer.classes;

namespace DataLayer
{
    public class Serialization: ISerialization
    {
        private readonly IValidation validator;

        public Serialization(IValidation validation)
        {
            this.validator = validation;
        }
        public List<Teacher> XmlserializeTeacher(string path)
        {
            if (validator.validate(path))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Teacher>), new XmlRootAttribute("teachers"));
                List<Teacher> Teachers = new List<Teacher>();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    Teachers = formatter.Deserialize(fs) as List<Teacher>;
                }
                TeacherValidator valid = new TeacherValidator();
                if (Teachers.TrueForAll(x => valid.Validate(x).IsValid))
                {
                    return Teachers;
                }
                else
                {
                    foreach (var i in Teachers)
                    {
                        foreach (var failure in valid.Validate(i).Errors)
                        {
                            Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                    }
                    return new List<Teacher>();
                }
            }
            else
                return new List<Teacher>();
            
        }
        public List<Subject> XmlserializeSubject(string path)
        {
            if (validator.validate(path))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Subject>), new XmlRootAttribute("subjects"));
                List<Subject> Subjects = new List<Subject>();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {

                    Subjects = formatter.Deserialize(fs) as List<Subject>;

                }
                SubjectValidator valid = new SubjectValidator();
                if (Subjects.TrueForAll(x => valid.Validate(x).IsValid))
                {
                    return Subjects;
                }
                else
                {
                    foreach (var i in Subjects)
                    {
                        foreach (var failure in valid.Validate(i).Errors)
                        {
                            Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                    }
                    return new List<Subject>();
                }
            }
            else
                return new List<Subject>();
            
        }
        public List<Specialty> XmlserializeSpecialty(string path)
        {
            if (validator.validate(path))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Specialty>), new XmlRootAttribute("specialties"));
                List<Specialty> adds = new List<Specialty>();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {

                    adds = formatter.Deserialize(fs) as List<Specialty>;

                }
                SpecialtyValidator valid = new SpecialtyValidator();
                if (adds.TrueForAll(x => valid.Validate(x).IsValid))
                {
                    return adds;
                }
                else
                {
                    foreach (var i in adds)
                    {
                        foreach (var failure in valid.Validate(i).Errors)
                        {
                            Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                    }
                    return new List<Specialty>();
                }
            }
            else
                return new List<Specialty>();
            
        }
        public List<SpecialtySubject> XmlserializeSpecialtySubject(string path)
        {
            if (validator.validate(path))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<SpecialtySubject>), new XmlRootAttribute("specialtysubjects"));
                List<SpecialtySubject> books = new List<SpecialtySubject>();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {

                    books = formatter.Deserialize(fs) as List<SpecialtySubject>;

                }
                SpecialtySubjectValidator valid = new SpecialtySubjectValidator();
                if (books.TrueForAll(x => valid.Validate(x).IsValid))
                {
                    return books;
                }
                else
                {
                    foreach (var i in books)
                    {
                        foreach (var failure in valid.Validate(i).Errors)
                        {
                            Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                    }
                    return new List<SpecialtySubject>();
                }
            }
            else
                return new List<SpecialtySubject>();
            
        }
    }
}
