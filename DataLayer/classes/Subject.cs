using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.classes
{
    [Serializable]
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public ControlTypeEnum ControlType { get; set; }
        public int Hours { get; set; }
        public int SpecialtyId { get; set; }
        public int Course { get; set; }
        public Subject (int SubjectId, string SubjectName,int TeacherId, string TeacherName, ControlTypeEnum ControlType, int Hours, int SpecialtyId, int Course)
        {
            this.SubjectId = SubjectId;
            this.SubjectName = SubjectName;
            this.TeacherId = TeacherId;
            this.TeacherName = TeacherName;
            this.ControlType = ControlType;
            this.Hours = Hours;
            this.SpecialtyId = SpecialtyId;
            this.Course = Course;
        }
        public Subject() { }
        public override string ToString()
        {
            return $"Предмет: {SubjectName}, Викладач: {TeacherName}, Контрольний захід: {ControlType}, Кількість годин: {Hours}, Код спеціальності: {SpecialtyId}, Курс викладання: {Course}";
        }
    }
}
