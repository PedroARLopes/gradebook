using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            //log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage; // C# can assume this
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message.ToLower();
        }


        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Pedro";
            var upper = MakeUpperCase(name);

            Assert.Equal("PEDRO", upper);
        }

        private string MakeUpperCase(string s)
        {
            return s.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref Int32 x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CShartpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New book Name");

            Assert.Equal("New book Name", book1.Name);
        }

        //  out can be used instead of ref but it's assumed that
        // it is not initialised so it must be initialised in the
        // function before it's returned
        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name, new LetterGrade());
        }

        [Fact]
        public void CanNotSetNameFromValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New book Name", new LetterGrade());

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name, ILetterGrade letterGrade)
        {
            book = new InMemoryBook(name, letterGrade);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New book Name");

            Assert.Equal("New book Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name, new LetterGrade());
        }
    }
}
