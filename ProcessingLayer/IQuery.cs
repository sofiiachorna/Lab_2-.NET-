using DataLayer;
using DataLayer.classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessingLayer
{
    public interface IQuery
    {
        IEnumerable<string> allQueries();
        IEnumerable<string> selectSubjectToCourse(int course);
        IEnumerable<string> selectSubjectToControlType(string control);
        IEnumerable<string> selectSubjectsToTeacher(string teacher);
        IEnumerable<string> selectSubjectForHours(int c, int h);
        IEnumerable<string> selectSubjectsForSpecialty(int SpecialtyId);
        string specialtyName(int sc);
        int teacherSubjectsCount(string teacherName);
        IEnumerable<Subject> subjectInfo(string s);
        int totalHoursForTeacher(string teacherName);
        IEnumerable<int> specialtyForSubject(string subjectName);
        IEnumerable<string> selectTeachersToControlType(string control);
        IEnumerable<Specialty> selectSpecialties();
        IEnumerable<string> selectTeacherBySpecialtyCode(int code);
        IEnumerable<string> checkMyExams(int c1, string c2);
        IEnumerable<string> teacherWithMaxHours();
    }
}
