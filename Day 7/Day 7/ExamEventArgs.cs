using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class ExamEventArgs : EventArgs
    {
        public Subject Subject { get; private set; }
        public Exam Exam { get; private set; }

        public ExamEventArgs(Subject subject, Exam exam)
        {
            Subject = subject;
            Exam = exam;
        }

    }
    // public delegate void ExamStartedHandler(object sender, ExamEventArgs e);
}
