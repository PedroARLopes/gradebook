using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void AddGradeToInMemoryBookDoesNotAddNegative()
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
