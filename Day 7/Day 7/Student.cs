using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class Student
    {
        public string Name { get; private set; }
        public int Id { get; private set; }

        public Student(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine(Name +", exam for " + e.Subject.Name + " has started.");
        }
    }
}
