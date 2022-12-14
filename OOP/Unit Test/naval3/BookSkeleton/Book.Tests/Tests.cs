namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void Book_Creation() 
        {
            Book book = new Book("m", "C");
            Assert.AreEqual("m", book.BookName);
            Assert.AreEqual("C", book.Author);
        
        
        }
        [Test]
        public void Book_Count()
        {
            Book book = new Book("m", "C");
            Assert.AreEqual("m", book.BookName);
            Assert.AreEqual("C", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);


        }
        [Test]
        public void Book_Name_Creation_With_Null()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(null, "ma");

            });


        }
        [Test]
        public void Book_Name_Creation_With_Empty_String()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("", "ma");

            });


        }
        [Test]
        public void Book_Name_Add_Footnote_Work()
        {
            Book book = new Book("m", "C");
            var footnote = new Book("c", "C");
            book.AddFootnote(1, ("alabala"));
            Assert.AreEqual(1, book.FootnoteCount);

            


        }
       
        [Test]
        public void Book_Name_Find_Footnote_Work()
        {
            Book book = new Book("m", "C");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(1));


        }
        [Test]
        public void Book_Name_Alter_Footnote_Work()
        {
            Book book = new Book("m", "C");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(1, "Da"));


        }
    }
}