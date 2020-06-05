using System;

namespace GradeBook
{
    public class BookEventArgs : EventArgs
    {
        public double grade { get; set; }

        public BookEventArgs(double grade)
        {
            this.grade = grade;
        }
    }
}