using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class ChooseAllQuestion : Question
    {
        private Answer[] _correctAnswers;
        private int _correctCount;

        public ChooseAllQuestion(string header, string body, int marks)
            : base(header, body, marks)
        {
            _correctAnswers = new Answer[5];
            _correctCount = 0;
        }

        public void AddCorrectAnswer(int id)
        {
            _correctAnswers[_correctCount] = Answers.GetById(id);
            _correctCount++;
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
            for (int i = 0; i < _correctCount; i++)
            {
                if (_correctAnswers[i].Equals(studentAnswer))
                    return true;
            }

            return false;
        }
    }
}
