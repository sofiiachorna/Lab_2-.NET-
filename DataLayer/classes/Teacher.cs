using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.classes
{
    [Serializable]
    public class Teacher
    { 
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public Teacher (int TeacherId, string TeacherName)
        {
            this.TeacherId = TeacherId;
            this.TeacherName = TeacherName;
        }
        public Teacher () { }
        public override string ToString()
        {
            return $"ПІБ викладача: {TeacherName},Id викладача: {TeacherId} ";
        }
    }
}
