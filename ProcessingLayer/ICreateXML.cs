using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingLayer
{
    public interface ICreateXML
    {
        void XmlwriterTeacher(string path, List<string> items);
        void XmlwriterSubject(string path, List<string> items);
        void XmlwriterSpecialty(string path, List<string> items);
        void XmlwriterSpecialtySubject(string path, List<string> items);
    }
}
