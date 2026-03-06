using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public abstract class Question
    {
        public string Header { get; private set; }
        public string Body { get; private set; }
        public int Marks { get; private set; }
        public AnswerList Answers { get; private set; }
        public Answer CorrectAnswer { get; protected set; }

        protected Question(string header, string body, int marks)
        {
            if (string.IsNullOrWhiteSpace(header))
                throw new ArgumentException("Header required");

            if (string.IsNullOrWhiteSpace(body))
                throw new ArgumentException("Body required");

            if (marks <= 0)
                throw new ArgumentException("Marks must be greater than zero");

            Header = header;
            Body = body;
            Marks = marks;
            Answers = new AnswerList();
        }

        public abstract void Display();
        public abstract bool CheckAnswer(Answer studentAnswer);

        public override string ToString()
        {
            return Header + " - " + Body + " (" + Marks + " marks)";
        }

        public override bool Equals(object obj)
        {
            Question other = obj as Question;
            if (other == null)
                return false;

            return this.Body == other.Body;
        }

        public override int GetHashCode()
        {
            return Body.GetHashCode();
        }
    }
}
