using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public abstract class Exam : ICloneable, IComparable<Exam>     //, IExamBehavior later
    {
        public int Time { get; private set; }
        public Question[] Questions { get; private set; }
        public Subject Subject { get; private set; }
        public ExamMode Mode { get; protected set; }

        public int NumberOfQuestions
        {
            get { return Questions.Length; }
        }

        public Dictionary<Question, Answer> QuestionAnswerDictionary
        { get; private set; }

        public event EventHandler<ExamEventArgs> ExamStarted;

        protected Exam(int time, Question[] questions, Subject subject)
        {
            Time = time;
            Questions = questions;
            Subject = subject;
            Mode = ExamMode.Queued;

            QuestionAnswerDictionary = new Dictionary<Question, Answer>();
        }

       
        public virtual void Start()
        {
            Mode = ExamMode.Starting;

            if (ExamStarted != null)
            {
                ExamStarted(this, new ExamEventArgs(Subject, this));
            }

            Console.WriteLine("Exam started.");
            Console.WriteLine("You have " + Time + " seconds.");
        }

        public virtual void Finish()
        {
            Mode = ExamMode.Finished;
            SaveResults();
        }

        public virtual void CorrectExam()
        {
            int grade = 0;

            foreach (KeyValuePair<Question, Answer> pair in QuestionAnswerDictionary)
            {
                if (pair.Key.CheckAnswer(pair.Value))
                    grade += pair.Key.Marks;
            }

            Console.WriteLine("Final Grade: " + grade);
        }

    
        private void SaveResults()
        {
            using (StreamWriter sw = new StreamWriter("ExamResults.txt", true))
            {
                sw.WriteLine("=================================");
                sw.WriteLine("Subject: " + Subject.Name);
                sw.WriteLine("Exam Time: " + DateTime.Now);
                sw.WriteLine("Exam Type: " + this.GetType().Name);
                sw.WriteLine("---------------------------------");

                int grade = 0;

                foreach (KeyValuePair<Question, Answer> pair in QuestionAnswerDictionary)
                {
                    bool isCorrect = pair.Key.CheckAnswer(pair.Value);

                    sw.WriteLine("Question: " + pair.Key.Body);
                    sw.WriteLine("Student Answer: " + pair.Value.Text);
                    sw.WriteLine("Correct: " + isCorrect);
                    sw.WriteLine();

                    if (isCorrect)
                        grade += pair.Key.Marks;
                }

                sw.WriteLine("Final Grade: " + grade);
                sw.WriteLine("=================================");
                sw.WriteLine();
            }
        }

        public abstract void ShowExam();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Exam other)
        {
            int result = this.Time.CompareTo(other.Time);

            if (result == 0)
            {
                result = this.NumberOfQuestions
                    .CompareTo(other.NumberOfQuestions);
            }

            return result;
        }
    }
}
