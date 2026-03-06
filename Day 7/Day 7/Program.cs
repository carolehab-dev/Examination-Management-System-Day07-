namespace Day_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Subject
            Subject subject = new Subject("Database");

            //Students & Enroll
            Student s1 = new Student("Ali", 1);
            Student s2 = new Student("Sara", 2);

            subject.Enroll(s1);
            subject.Enroll(s2);

            // QuestionList 
            QuestionList questionList =new QuestionList("DatabaseQuestions.txt");

            
            // Create Questions & Add to List
            Question q1 = new TrueFalseQuestion("Q1","SQL stands for Structured Query Language?",5,true);
            questionList.Add(q1);   // logs to file
            ChooseOneQuestion q2 = new ChooseOneQuestion("Q2","Which of the following is a DBMS?",5);
            q2.Answers.Add(new Answer(1, "MySQL"));
            q2.Answers.Add(new Answer(2, "HTML"));
            q2.Answers.Add(new Answer(3, "CSS"));
            q2.Answers.Add(new Answer(4, "JavaScript"));

            q2.SetCorrectAnswer(1);

            questionList.Add(q2);   

            ChooseAllQuestion q3 = new ChooseAllQuestion("Q3","Which of the following are SQL commands?",10);

            q3.Answers.Add(new Answer(1, "SELECT"));
            q3.Answers.Add(new Answer(2, "INSERT"));
            q3.Answers.Add(new Answer(3, "DELETE"));
            q3.Answers.Add(new Answer(4, "COLOR"));
            q3.AddCorrectAnswer(1);
            q3.AddCorrectAnswer(2);
            q3.AddCorrectAnswer(3);
            questionList.Add(q3);   

            // Convert QuestionList to Array
            Question[] questions = questionList.GetAll();

      
            // Create Exams
            PracticeExam practiceExam =new PracticeExam(10, questions, subject);
            FinalExam finalExam =new FinalExam(10, questions, subject);
            practiceExam.ExamStarted += s1.OnExamStarted;
            practiceExam.ExamStarted += s2.OnExamStarted;
            finalExam.ExamStarted += s1.OnExamStarted;
            finalExam.ExamStarted += s2.OnExamStarted;

           
            Console.WriteLine("Select Exam Type:");
            Console.WriteLine("1 - Practice");
            Console.WriteLine("2 - Final");

            int choice = int.Parse(Console.ReadLine());
            Exam selectedExam;
            if (choice == 1)
                selectedExam = practiceExam;
            else
                selectedExam = finalExam;
            selectedExam.Start();
            selectedExam.ShowExam();
            selectedExam.Finish();
        }
    }
}
