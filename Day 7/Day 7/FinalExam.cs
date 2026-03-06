using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, Question[] questions, Subject subject)
            : base(time, questions, subject)
        {
        }

        public override void ShowExam()
        {
            DateTime startTime = DateTime.Now;

            for (int i = 0; i < Questions.Length; i++)
            {
                TimeSpan elapsed = DateTime.Now - startTime;

                if (elapsed.TotalSeconds >= Time)
                {
                    Console.WriteLine("Time is up!");
                    break;
                }

                Questions[i].Display();

                Console.Write("Enter your answer ID: ");
                int answerId = int.Parse(Console.ReadLine());

                Answer studentAnswer =
                    Questions[i].Answers.GetById(answerId);

                QuestionAnswerDictionary.Add(
                    Questions[i],
                    studentAnswer);
            }

            Console.WriteLine("Exam submitted.");
        }
    }
}
