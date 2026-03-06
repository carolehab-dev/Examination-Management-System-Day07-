using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string header, string body, int marks)
            : base(header, body, marks)
        {
        }

        public void SetCorrectAnswer(int id)
        {
            CorrectAnswer = Answers.GetById(id);
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
