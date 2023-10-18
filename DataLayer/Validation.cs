using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;

namespace DataLayer
{
    public class Validation : IValidation
    {
        private List<string> schemes => new List<string>()
        {
            "D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\specialties.xsd",
            "D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\specialtysubjects.xsd",
            "D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\teachers.xsd",
            "D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\subjects.xsd",
            "D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\queryDescs.xsd"
        };

        public bool validate(string path)
        {
            XmlSchemaSet schemaset = new XmlSchemaSet();
            foreach (var scheme in schemes)
            {
                schemaset.Add("", scheme);
            }
            XDocument document = XDocument.Load(path);
            bool errors = false;
            
            document.Validate(schemaset, (o, e) =>
            {
                Console.WriteLine(e.Message);
                errors = true;
            });
            
            if (errors)
            {
                Console.WriteLine("Doc did not validate");
            }
            return !errors;
            
        }

    }
}
