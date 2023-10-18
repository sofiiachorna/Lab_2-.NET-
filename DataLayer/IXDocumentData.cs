using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;


namespace DataLayer
{
    public interface IXDocumentData
    {
        XDocument queryDescriptions { get; }
        XDocument teachers { get; }
        XDocument subjects { get; }
        XDocument specialties { get; }
        XDocument specialtysubjects { get; }
    }
}
