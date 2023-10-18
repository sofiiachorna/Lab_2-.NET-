using ProcessingLayer;
using System;

namespace PresentationLayer
{
    public interface IOutput
    {
        void showAllQueries();
        void showSelectedsubjectToCourse();
        void showSelectedSubjectToControlType();
        void showSelectedSubjectsToTeacher();
        void showSelectedSubjectForHours();
        void showSelectedSubjectsForSpecialty();
        void showSpecialtyName();
        void showTeacherSubjectsCount();
        void showSubjectInfo();
        void showTotalHoursForTeacher();
        void showspecialtyForSubject();
        void showSelectedTeachersToControlType();
        void showSelectedSpecialties();
        void showSelectedTeacherByCourseCount();
        void showCheckMyExams();
        void showTeacherWithMaxHours();
        

    }
}
