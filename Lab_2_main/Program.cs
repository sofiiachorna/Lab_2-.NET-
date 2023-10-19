using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.DependencyInjection;
using DataLayer;
using PresentationLayer;
using ProcessingLayer;

namespace Lab_2_main
{
    class Program
    {
        private static IServiceProvider Configure()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IQuery, Queries>();
            serviceCollection.AddTransient<IOutput, Output>();
            serviceCollection.AddTransient<IProgramExecute, ProgramExecute>();
            serviceCollection.AddTransient<ICreateXML, CreateXML>();
            serviceCollection.AddTransient<IInput, Input>();
            serviceCollection.AddTransient<ICreateXmlDocument, CreateXmlDocument>();
            serviceCollection.AddTransient<ISerialization, Serialization>();
            serviceCollection.AddTransient<IShowXml, ShowXml>();
            serviceCollection.AddTransient<IXDocumentData, XDocumentData>();
            serviceCollection.AddTransient<IValidation, Validation>();
            serviceCollection.AddTransient<IRead, ReadConsoleXml>();
            serviceCollection.AddTransient<IShowConsole, ShowConsole>();
            return serviceCollection.BuildServiceProvider();
        }
        static void Main(string[] args)
        {
            var service = Configure();
            var runner = service.GetService<IProgramExecute>();
            runner.start();
        }
        
    }
}
