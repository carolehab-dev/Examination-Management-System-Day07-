using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class Subject
    {
        public string Name { get; private set; }

        private Student[] _students;
        private int _count;

        public Student[] EnrolledStudents
        {
            get { return _students; }
        }

        public Subject(string name)
        {
            Name = name;
            _students = new Student[10];
            _count = 0;
        }

        public void Enroll(Student student)
        {
            _students[_count] = student;
            _count++;
        }
    }
}
