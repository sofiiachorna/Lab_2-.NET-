using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ProgramExecute : IProgramExecute
    {
        private readonly IOutput output;
        private readonly IInput input;
        private readonly IShowXml show;
        private readonly IShowConsole showConsole;
        public ProgramExecute(IOutput output,IInput input, IShowXml show, IShowConsole showConsole)
        {
            this.output = output;
            this.input = input;
            this.show = show;
            this.showConsole = showConsole;
        }

        private enum methods
        {
            inputFromConsole,
            showFromConsole,
            showXml,
            showSelectedsubjectToCourse,
            showSelectedSubjectToControlType,
            showSelectedSubjectsToTeacher,
            showSelectedSubjectForHours,
            showSelectedSubjectsForSpecialty,
            showSpecialtyName,
            showTeacherSubjectsCount,
            showSubjectInfo,
            showTotalHoursForTeacher,
            showspecialtyForSubject,
            showSelectedTeachersToControlType,
            showSelectedSpecialties,
            showSelectedTeacherByCourseCount,
            showCheckMyExams,
            showTeacherWithMaxHours
    }
        public void start()
        {
            Dictionary<methods, Action> methodsOutput = new Dictionary<methods, Action>()
            {
                 {methods.inputFromConsole,input.input },
                 {methods.showFromConsole,showConsole.show },
                 {methods.showXml,show.chooseXml },
                 {methods.showSelectedsubjectToCourse,output.showSelectedsubjectToCourse},
                 {methods.showSelectedSubjectToControlType,output.showSelectedSubjectToControlType},
                 {methods.showSelectedSubjectsToTeacher,output.showSelectedSubjectsToTeacher},
                 {methods.showSelectedSubjectForHours,output.showSelectedSubjectForHours},
                 {methods.showSelectedSubjectsForSpecialty,output.showSelectedSubjectsForSpecialty},
                 {methods.showSpecialtyName,output.showSpecialtyName},
                 {methods.showTeacherSubjectsCount,output.showTeacherSubjectsCount},
                 {methods.showSubjectInfo,output.showSubjectInfo},
                 {methods.showTotalHoursForTeacher,output.showTotalHoursForTeacher},
                 {methods.showspecialtyForSubject,output.showspecialtyForSubject},
                 {methods.showSelectedTeachersToControlType,output.showSelectedTeachersToControlType},
                 {methods.showSelectedSpecialties,output.showSelectedSpecialties},
                 {methods.showSelectedTeacherByCourseCount,output.showSelectedTeacherByCourseCount},
                 {methods.showCheckMyExams,output.showCheckMyExams},
                 {methods.showTeacherWithMaxHours,output.showTeacherWithMaxHours},
            };
            Console.OutputEncoding = Encoding.UTF8;
            string answer = "так";
            output.showAllQueries();
            while (answer.Equals("так"))
            {
                Console.WriteLine("Оберіть номер запиту для виконання:");
                int num = int.Parse(Console.ReadLine());
                num -= 1;
                if (Enum.TryParse((num).ToString(), out methods method) && methodsOutput.ContainsKey(method))
                {
                    methodsOutput[method]();
                }
                else
                {
                    Console.WriteLine("Цей запит недоступний.");
                }
                Console.WriteLine("Бажаєте продовжити?");
                answer = Console.ReadLine();
            }

        }

    }
}
