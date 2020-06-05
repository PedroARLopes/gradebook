using System;
using System.Collections.Generic;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        private ILetterGrade _letterGrade;

        protected Book(string name, ILetterGrade letterGrade) : base(name)
        {
            _letterGrade = letterGrade;
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public void AddGrade(char grade)
        {
            AddGrade(_letterGrade.ConvertToDouble(grade));
        }

        public abstract double GetLastGrade();

        public abstract IEnumerable<double> GetGrades();
    }
}