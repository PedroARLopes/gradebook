using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void AverageLetterGradeComputation()
        {
            var book = new Book("grades");
            book.AddGrade(89.0);

            Assert.Equal('B', book.LetterGrade(89.0));
        }

        [Fact]
        public void AddGradeDoesNotAddNegative()
        {
            var grade = -13.0;

            var book = new Book("grades");
            Assert.Throws<ArgumentException>(() => book.AddGrade(grade));
        }

        [Fact]
        public void TestGetStatistics()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(88.1);
            book.AddGrade(90.6);
            book.AddGrade(85.6);

            // act
            var statistics = book.GetStatistics();

            // asert
            Assert.Equal(85.6, statistics.Low, 1);
            Assert.Equal(90.6, statistics.High, 1);
            Assert.Equal(88.1, statistics.Average, 1);
        }
    }
}
