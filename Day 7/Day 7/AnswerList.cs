using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class AnswerList
    {
        private Answer[] _answers;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public AnswerList(int capacity = 5)
        {
            _answers = new Answer[capacity];
            _count = 0;
        }

        public void Add(Answer answer)
        {
            if (_count >= _answers.Length)
                Array.Resize(ref _answers, _answers.Length * 2);

            _answers[_count] = answer;
            _count++;
        }

        public Answer GetById(int id)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_answers[i].Id == id)
                    return _answers[i];
            }

            return null;
        }

        public Answer this[int index]
        {
            get { return _answers[index]; }
        }
    }
}
