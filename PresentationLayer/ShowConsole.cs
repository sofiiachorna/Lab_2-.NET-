using System;
using System.Collections.Generic;
using System.Text;
using ProcessingLayer;

namespace PresentationLayer
{
    public class ShowConsole : IShowConsole
    {
        private readonly IRead reader;
        public ShowConsole(IRead reader)
        {
            this.reader = reader;
        }

        public void show()
        {
            foreach (object obj in reader.read()) 
            {
                Console.WriteLine(obj);
            }
        }
    }
}
