using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.classes;

namespace DataLayer
{
    public interface ICreateXmlDocument
    {
        List<Teacher> TeacherFromXml(string path);
        List<Subject> SubjectFromXml(string path);
        List<Specialty> SpecialtyFromXml(string path);
        List<SpecialtySubject> SpecialtySubjectFromXml(string path);
    }
}
