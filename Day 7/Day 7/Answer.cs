using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    using System;

    public class Answer : IComparable<Answer>
    {
        public int Id { get; private set; }
        public string Text { get; private set; }

        public Answer(int id, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be empty.");

            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return Id + ". " + Text;
        }

        public override bool Equals(object obj)
        {
            Answer other = obj as Answer;
            if (other == null)
                return false;

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int CompareTo(Answer other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
