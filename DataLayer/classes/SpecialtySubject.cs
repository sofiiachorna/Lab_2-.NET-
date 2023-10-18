using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.classes
{
    public class SpecialtySubject
    {
        public int SpecialtyId { get; set; }
        public int SubjectId { get; set; }
        public SpecialtySubject(int specialtyId, int subjectId)
        {
            this.SpecialtyId = specialtyId;
            this.SubjectId = subjectId;
        }
        public SpecialtySubject() { }

        public override string ToString()
        {
            return $"Код спеціальності:{SpecialtyId}, код дисципліни: {SubjectId}";
        }
    }
}
