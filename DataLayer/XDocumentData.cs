using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DataLayer
{
    public class XDocumentData: IXDocumentData
    {
        private readonly IValidation validator;
        public XDocumentData(IValidation validator)
        {
            this.validator = validator;
            checkDoc();
        }
        public XDocument queryDescriptions => validator.validate("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\queryDescs.xml") ?
            XDocument.Load("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\queryDescs.xml") : null;
        public XDocument subjects => validator.validate("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\subjects.xml") ?
            XDocument.Load("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\subjects.xml") : null;
        public XDocument teachers => validator.validate("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\teachers.xml") ? 
            XDocument.Load("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\teachers.xml") : null;
        public XDocument specialties => validator.validate("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\specialties.xml") ?
            XDocument.Load("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\specialties.xml") : null;
        public XDocument specialtysubjects => validator.validate("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\specialtysubjects.xml") ?
            XDocument.Load("D:\\kpi\\2 KURS\\.NET labs\\Lab #2\\DataLayer\\specialtysubjects.xml") : null;

        private void checkDoc()
        {
            bool count = false;
            if(queryDescriptions == null || subjects == null || teachers == null || specialties == null || specialtysubjects == null)
                count = true;
            if(count == true)
            {
                Console.WriteLine("Перевірте ваші файли!");
                Environment.Exit(0);
            }
        
        }
    }
}
