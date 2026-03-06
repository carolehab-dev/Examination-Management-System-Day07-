using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int marks, bool correct)
            : base(header, body, marks)
        {
            Answers.Add(new Answer(1, "True"));
            Answers.Add(new Answer(2, "False"));

            if (correct)
                CorrectAnswer = Answers.GetById(1);
            else
                CorrectAnswer = Answers.GetById(2);
        }

        public override void Display()
        {
            Console.WriteLine(ToString());

            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine(Answers[i]);
            }
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.Equals(CorrectAnswer);
        }
    }
}
