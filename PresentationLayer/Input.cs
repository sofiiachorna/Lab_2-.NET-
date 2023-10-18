using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ProcessingLayer;

namespace PresentationLayer
{
   public class Input : IInput
    {
        private readonly ICreateXML create;
        private readonly string path = "../../../../DataLayer/XmlWriter/";
        public Input(ICreateXML create)
        {
            this.create = create;
        }
        public void input()
        {
            Dictionary<string, Action> elements = new Dictionary<string, Action>()
            {
                {"subject",subjectInput},
                {"teacher",teacherInput},
                {"specialty",specialtyInput},
                {"specialtysubject",specialtysubjectInput},

            };
            Console.WriteLine("Введіть елемент,який потрібно додати до файлу:");
            string e = Console.ReadLine();
            elements[e]();
        }
        private void subjectInput()
        {
            List<string> items = new List<string>();
            Console.WriteLine("Введіть назву предмета:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть id предмета:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть id вчителя:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть ПІБ вчителя:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть контрольний захід:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть кількість годин:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть код спеціальності:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть курс викладання:");
            items.Add(Console.ReadLine());
            create.XmlwriterSubject(path + "subjects.xml", items);
        }
        private void teacherInput()
        {
            List<string> items = new List<string>();
            Console.WriteLine("Введіть ПІБ викладача:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть id викладача:");
            items.Add(Console.ReadLine());
            create.XmlwriterTeacher(path + "teachers.xml", items);
        }
        private void specialtyInput()
        {
            List<string> items = new List<string>();
            Console.WriteLine("Введіть назву спеціальності:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть код спеціальності:");
            items.Add(Console.ReadLine());
            create.XmlwriterSpecialty(path + "specialties.xml", items);
        }
        private void specialtysubjectInput()
        {
            List<string> items = new List<string>();
            Console.WriteLine("Введіть код спеціальності:");
            items.Add(Console.ReadLine());
            Console.WriteLine("Введіть id диципліни:");
            items.Add(Console.ReadLine());
            create.XmlwriterSpecialtySubject(path + "specialtysubjects.xml", items);
        }
    }
}
