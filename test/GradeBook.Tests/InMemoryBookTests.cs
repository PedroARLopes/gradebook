using System;
using Xunit;

namespace GradeBook.Tests
{
    public class InMemoryBookTests
    {

        [Fact]
        public void GetGrades()
        {
            var book = new InMemoryBook("grades", new LetterGrade());
            book.AddGrade(100);
            book.AddGrade(70);
            book.AddGrade(80);

            var grades = book.GetGrades();
            Assert.Contains(100, grades);
            Assert.Contains(70, grades);
            Assert.Contains(80, grades);
        }

        [Fact]
        public void GetGradesReturnsEmptyEnumerableIfGradesIsEmpty()
        {
            var book = new InMemoryBook("grades", new LetterGrade());

            var grades = book.GetGrades();
            Assert.Empty(grades);
        }

        [Fact]
        public void GetLastGrade()
        {
            var grade = 90;
            var book = new InMemoryBook("grades", new LetterGrade());
            book.AddGrade(grade);

            var lastGrade = book.GetLastGrade();
            Assert.Equal(grade, lastGrade);
        }

        [Fact]
        public void GetLastGradeDoesNotThrowExceptionIfGradesIsEmpty()
        {
            var book = new InMemoryBook("grades", new LetterGrade());

            var lastGrade = book.GetLastGrade();
            Assert.Equal(0, lastGrade);
        }

        [Fact]
        public void AddGrade()
        {
            var grade = 90;
            var book = new InMemoryBook("grades", new LetterGrade());

            book.AddGrade(grade);
            Assert.Equal(90, book.GetLastGrade());
        }

        [Fact]
        public void AddGradeOutOfRangeThrowsException()
        {
            var grade = 125;
            var book = new InMemoryBook("grades", new LetterGrade());

            Assert.Throws<ArgumentException>(() => book.AddGrade(grade));
        }

        [Fact]
        public void AddGradeDoesNotAddNegative()
        {
            var grade = -13.0;
            var book = new InMemoryBook("grades", new LetterGrade());

            Assert.Throws<ArgumentException>(() => book.AddGrade(grade));
        }

        [Fact]
        public void TestGetStatistics()
        {
            // arrange
            var book = new InMemoryBook("", new LetterGrade());
            book.AddGrade(88.1);
            book.AddGrade(90.6);
            book.AddGrade(85.6);

            // act
            var low = book.GetLow();
            var high = book.GetHigh();
            var average = book.GetAverage();

            // asert
            Assert.Equal(85.6, low, 1);
            Assert.Equal(90.6, high, 1);
            Assert.Equal(88.1, average, 1);
        }
    }
}
