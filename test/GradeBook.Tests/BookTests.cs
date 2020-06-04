using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void AddGradeDoesNotAddNegative()
        {
            var grade = -13.0;

            var book = new Book("grades");
            book.AddGrade(grade);

            Assert.Equal(0.0, book.GetLastGrade());
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
