using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class QuestionList
    {
        private Question[] _questions;
        private int _count;
        private string _fileName;

        public int Count
        {
            get { return _count; }
        }

        public QuestionList(string fileName)
        {
            _questions = new Question[10];
            _count = 0;
            _fileName = fileName;
        }

        public void Add(Question question)
        {
            if (_count >= _questions.Length)
                Array.Resize(ref _questions, _questions.Length * 2);

            _questions[_count] = question;
            _count++;

            using (StreamWriter sw = new StreamWriter(_fileName, true))
            {
                sw.WriteLine(question.ToString());
            }
        }

        public Question[] GetAll()
        {
            //return _questions;
            Question[] result = new Question[_count];

            for (int i = 0; i < _count; i++)
            {
                result[i] = _questions[i];
            }

            return result;
        }
    }
}
