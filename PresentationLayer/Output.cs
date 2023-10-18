using ProcessingLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace PresentationLayer
{
    public class Output : IOutput
    {
        private readonly IQuery queries;
        public Output(IQuery queries)
        {
            this.queries = queries;
        }
        private void write<T>(IEnumerable<T> query)
        {
            foreach (var i in query)
            {
                Console.WriteLine(i);
            }
        }
        public void showAllQueries()
        {
            var q = queries.allQueries().ToList();
            for (int i = 1; i <= q.Count; i++)
            {
                Console.WriteLine($"{i}. {q[i - 1]}");
            }
        }
        public void showSelectedsubjectToCourse()
        {
            Console.WriteLine("Введіть курс викладання:");
            int с = int.Parse(Console.ReadLine());
            var q = queries.selectSubjectToCourse(с);
            write(q);
        }
        public void showSelectedSubjectToControlType()
        {
            Console.WriteLine("Назвіть тип контролю:");
            string a = Console.ReadLine();
            var q = queries.selectSubjectToControlType(a);

            write(q);
        }
        public void showSelectedSubjectsToTeacher()
        {
            Console.WriteLine("Введіть ПІБ викладача:");
            string n = Console.ReadLine();
            var q = queries.selectSubjectsToTeacher(n);
     
            write(q);
        }
        public void showSelectedSubjectForHours()
        {
            Console.WriteLine("Введіть курс викладання:");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть кількість годин:");
            int o = int.Parse(Console.ReadLine());
            var q = queries.selectSubjectForHours(i, o);
            write(q);
        }
        public void showSelectedSubjectsForSpecialty()
        {
            Console.WriteLine("Введіть код спеціальності:");
            int i = int.Parse(Console.ReadLine());
            var q = queries.selectSubjectsForSpecialty(i);
            write(q);
        }
        public void showSpecialtyName()
        {
            Console.WriteLine("Введіть код спеціальності:");
            int i = int.Parse(Console.ReadLine());
            var q = queries.specialtyName(i);
            Console.WriteLine(q);
            
        }
        public void showTeacherSubjectsCount()
        {
            Console.WriteLine("Введіть ПІБ викладача:");
            string n = Console.ReadLine();
            var q = queries.teacherSubjectsCount(n);
            Console.WriteLine("Кількість дисциплін:");
            Console.WriteLine(q);
        }
        public void showSubjectInfo()
        {
            Console.WriteLine("Введіть назву предмета:");
            string s = Console.ReadLine();
            var q = queries.subjectInfo(s);
            write(q);
        }
        public void showTotalHoursForTeacher()
        {
            Console.WriteLine("Введіть ПІБ викладача:");
            string n = Console.ReadLine();
            var q = queries.totalHoursForTeacher(n);
            Console.WriteLine("К-сть годин викладання:");
            Console.WriteLine(q);

        }
        public void showspecialtyForSubject()
        {
            Console.WriteLine("Введіть назву предмета:");
            string s = Console.ReadLine();
            var q = queries.specialtyForSubject(s);
            Console.WriteLine("Код спеціальності:");
            write(q);
        }
        public void showSelectedTeachersToControlType()
        {
            Console.WriteLine("Введіть контрольний захід:");
            string c = Console.ReadLine();
            var q = queries.selectTeachersToControlType(c);
            write(q); ;
        }
        public void showSelectedSpecialties()
        {
            var q = queries.selectSpecialties();
            write(q);
        }
        public void showSelectedTeacherByCourseCount()
        {
            Console.WriteLine("Введіть код спеціальності");
            int code = int.Parse(Console.ReadLine());
            var q = queries.selectTeacherBySpecialtyCode(code);
            write(q);
        }
        public void showCheckMyExams()
        {
            Console.WriteLine("Введіть курс викладання:");
            int c1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть контрольний захід:");
            string c2 = Console.ReadLine();
            var q = queries.checkMyExams(c1,c2);
            write(q);
        }
        public void showTeacherWithMaxHours()
        {
            var q = queries.teacherWithMaxHours();
            write(q);
        }
    }
}
