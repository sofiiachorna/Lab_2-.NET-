using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DataLayer;

namespace ProcessingLayer

{
    public class CreateXML: ICreateXML
    {
    
        public void XmlwriterTeacher(string path,List<string> items)
        {
          
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(path, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("teachers");
                    writer.WriteStartElement("Teacher");
                    writer.WriteStartElement("TeacherName");
                    writer.WriteString(items[0]);
                    writer.WriteEndElement();
                    writer.WriteStartElement("TeacherId");
                    writer.WriteString(items[1]);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }  
        }
        public void XmlwriterSubject(string path , List<string> items)
        {
            
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(path, settings))
                {
                     writer.WriteStartElement("subjects");
                     writer.WriteStartDocument();
                     writer.WriteStartElement("Subject");
                     writer.WriteStartElement("SubjectName");
                     writer.WriteString(items[0]);
                     writer.WriteEndElement();
                     writer.WriteStartElement("SubjectId");
                     writer.WriteString(items[1]);
                     writer.WriteEndElement();
                     writer.WriteStartElement("TeacherId");
                     writer.WriteString(items[2]);
                     writer.WriteEndElement();
                     writer.WriteStartElement("TeacherName");
                     writer.WriteString(items[3]);
                     writer.WriteEndElement();
                     writer.WriteStartElement("ControlType");
                     writer.WriteString(items[4]);
                     writer.WriteEndElement();
                     writer.WriteStartElement("Hours");
                     writer.WriteString(items[5]);
                     writer.WriteEndElement();
                     writer.WriteStartElement("SpecialtyId");
                     writer.WriteString(items[6]);
                     writer.WriteEndElement();
                     writer.WriteStartElement("Course");
                     writer.WriteString(items[7]);
                     writer.WriteEndElement();
                     writer.WriteEndElement();
                     writer.WriteEndElement();
                     writer.WriteEndDocument();
                }
            
        }
        public void XmlwriterSpecialty(string path, List<string> items)
        {
            
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(path, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("specialties");
                    writer.WriteStartElement("Specialty");
                    writer.WriteStartElement("SpecialtyName");
                    writer.WriteString(items[0]);
                    writer.WriteEndElement();
                    writer.WriteStartElement("SpecialtyId");
                    writer.WriteString(items[1]);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            
        }
        public void XmlwriterSpecialtySubject(string path, List<string> items)
        {
            
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(path, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("specialtysubjects");
                    writer.WriteStartElement("SpecialtySubject");
                    writer.WriteStartElement("SpecialtyId");
                    writer.WriteString(items[0]);
                    writer.WriteEndElement();
                    writer.WriteStartElement("SubjectId");
                    writer.WriteString(items[1]);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
          

        }
    }
}
