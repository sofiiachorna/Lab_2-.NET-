using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using DataLayer.classes;

namespace ProcessingLayer
{
    public class Queries : IQuery
    {
        private readonly IXDocumentData data; 
        public Queries(IXDocumentData data)
        {
            this.data = data;
        }
        public IEnumerable<string> allQueries()
        {
            return from desc in data.queryDescriptions.Descendants("desc")
                   select desc.Value;
        }
        public IEnumerable<string> selectSubjectToCourse(int course)
        {
            return from sub in data.subjects.Descendants("Subject")
                   where int.Parse(sub.Element("Course")?.Value).Equals(course)
                   select sub.Element("SubjectName")?.Value;
        }
        public IEnumerable<string> selectSubjectToControlType(string control)
        {
            return from sub in data.subjects.Descendants("Subject")
                   where (bool) sub.Element("ControlType")?.Value.Equals(control)
                   select sub.Element("SubjectName")?.Value;
        }
        public IEnumerable<string> selectSubjectsToTeacher(string teacher)
        {
            return from sub in data.subjects.Descendants("Subject")
                   join t in data.teachers.Descendants("Teacher") 
                   on new { id = sub.Element("TeacherId")?.Value,name = sub.Element("TeacherName")?.Value } 
                   equals new { id = t.Element("TeacherId")?.Value, name = t.Element("TeacherName")?.Value }
                   where (bool) t.Element("TeacherName")?.Value.Equals(teacher)
                   select sub.Element("SubjectName")?.Value;
        }
        public IEnumerable<string> selectSubjectForHours(int c, int h)
        {
            return from sub in data.subjects.Descendants("Subject")
                   where (bool)int.Parse(sub.Element("Course")?.Value).Equals(c) &&
                   int.Parse(sub.Element("Hours")?.Value).Equals(h)
                   select sub.Element("SubjectName")?.Value;
        }
        public IEnumerable<string> selectSubjectsForSpecialty(int SpecialtyId)
        {
            return data.subjects.Descendants("Subject")
                 .Where(g => (bool)(int.Parse(g.Element("SpecialtyId")?.Value).Equals(SpecialtyId)))
                 .Select(g => g.Element("SubjectName")?.Value);
        }
        public string specialtyName(int sc)
        {
            return data.specialties.Descendants("Specialty")
                   .Where(c => int.Parse(c.Element("SpecialtyId")?.Value).Equals(sc))
                   .Select(x => x.Element("SpecialtyName")?.Value).FirstOrDefault();
        }
        public int teacherSubjectsCount(string teacherName)
        {
            return data.subjects.Descendants("Subject")
                .Join(data.teachers.Descendants("Teacher"),
                    sub => new { Id = sub.Element("TeacherId")?.Value, Name = sub.Element("TeacherName")?.Value },
                    t => new { Id = t.Element("TeacherId")?.Value, Name = t.Element("TeacherName")?.Value },
                    (sub, t) => new { Subject = sub, Teacher = t })
                .Where(x => x.Teacher.Element("TeacherName")?.Value == teacherName)
                .GroupBy(x => x.Teacher.Element("TeacherName").Value)
                .Select(g => g.Count()).FirstOrDefault();
        }

        public IEnumerable<Subject> subjectInfo(string s)
        {
            return from sub in data.subjects.Descendants("Subject")
                   where (bool) sub.Element("SubjectName")?.Value.Equals(s)
                   select new Subject(int.Parse(sub.Element("SubjectId")?.Value), sub.Element("SubjectName")?.Value,
                   int.Parse(sub.Element("TeacherId")?.Value), sub.Element("TeacherName")?.Value, (ControlTypeEnum)Enum.Parse(typeof(ControlTypeEnum),sub.Element("ControlType")?.Value),
                   int.Parse(sub.Element("Hours")?.Value), int.Parse(sub.Element("SpecialtyId")?.Value),int.Parse(sub.Element("Course")?.Value));
        }

       public int totalHoursForTeacher (string teacherName)
       { 
            return data.subjects.Descendants("Subject")
                .Where(d => d.Element("TeacherName").Value == teacherName)
                .Sum(d => int.Parse(d.Element("Hours").Value));
       }
            
        public IEnumerable<int> specialtyForSubject(string subjectName)
        {
            return data.subjects.Descendants("Subject")
                .Join(data.specialties.Descendants("Specialty"),
                      sub => sub.Element("SpecialtyId")?.Value,
                      sp => sp.Element("SpecialtyId")?.Value,
                      (sub, sp) => new { Subject = sub, Specialty = sp })
                .Where(joinResult => (bool)(joinResult.Subject.Element("SubjectName")?.Value.Equals(subjectName)))
                .Select(joinResult => int.Parse(joinResult.Specialty.Element("SpecialtyId")?.Value));
        }

        public IEnumerable<string> selectTeachersToControlType(string control)
        {
            return from sub in data.subjects.Descendants("Subject")
                   where sub.Element("ControlType").Value.Equals(control)
                   select sub.Element("TeacherName")?.Value;
        }
        
        public IEnumerable<Specialty> selectSpecialties()
        {
            return from sp in data.specialties.Descendants("Specialty")
                   orderby int.Parse(sp.Element("SpecialtyId")?.Value)
                   select new Specialty(int.Parse(sp.Element("SpecialtyId").Value), sp.Element("SpecialtyName").Value);
        }
        public IEnumerable<string> selectTeacherBySpecialtyCode(int code)
        {
            return  data.subjects.Descendants("Subject")
                    .Where(s => int.Parse(s.Element("SpecialtyId")?.Value).Equals(code))
                    .OrderBy(s => s.Element("TeacherName")?.Value)
                    .Select(s => s.Element("TeacherName")?.Value);
        }
        public IEnumerable<string> checkMyExams (int c1, string c2)
        {
            return from sub in data.subjects.Descendants("Subject")
            where int.Parse(sub.Element("Course")?.Value).Equals(c1) && (bool) sub.Element("ControlType")?.Value.Equals(c2)
            select sub.Element("SubjectName")?.Value;

        }
        public IEnumerable<string> teacherWithMaxHours ()
        {
            var maxHours = data.subjects.Descendants("Subject")
                  .Max(d => int.Parse(d.Element("Hours").Value));
            return  data.subjects.Descendants("Subject")
                                        .Where(d => int.Parse(d.Element("Hours").Value) == maxHours)
                                        .Select(d => d.Element("TeacherName").Value);
        }

    }
}
