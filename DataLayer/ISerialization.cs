using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.classes;
namespace DataLayer
{
    public interface ISerialization
    {
        List<Teacher> XmlserializeTeacher(string path);
        List<Subject> XmlserializeSubject(string path);
        List<Specialty> XmlserializeSpecialty(string path);
        List<SpecialtySubject> XmlserializeSpecialtySubject(string path);
    }
}
