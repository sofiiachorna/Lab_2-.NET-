using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.classes
{
    [Serializable]
    public class Specialty
    {
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set;}
        public Specialty(int specialtyId, string specialtyName)
        {
            this.SpecialtyId = specialtyId;
            this.SpecialtyName = specialtyName;
        }
        public Specialty() { }
        public override string ToString()
        {
            return $"Код спеціальності: {SpecialtyId}, Назва спеціальності: {SpecialtyName}";
        }
    }
}
