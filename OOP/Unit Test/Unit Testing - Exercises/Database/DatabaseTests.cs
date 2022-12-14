namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { -1 })]
        [TestCase(new int[] { 1, 56, 10000, 231231, 54 })]
        [TestCase(new int[] { int.MaxValue, int.MinValue })]
        [TestCase(new int[] { 0 })]
        public void Constructor_With_Valid_Data_Should_Pass(int[] parameters)
        {

            Database database = new Database(parameters);

            Assert.AreEqual(parameters.Length, database.Count);
        }

        [TestCase(new int[] { 1, 2 },
            new int[] { 10, 15 },
            4)]
        [TestCase(new int[0],
            new int[] { int.MaxValue, int.MinValue, 331213 },
            3)]
        [TestCase(new int[0],
            new int[] { int.MaxValue, int.MinValue, 331213, 4, 5, 6, 7, 8, 9, 12, 10, 11, 41, 123, 21312, 3 },
            16)]

        public void Add_WithValidData_Possitive(int[] ctorParams,
            int[] paramsToAdd,
            int expectedCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }


            Assert.AreEqual(expectedCount, database.Count);
        }
        [TestCase(
            new int[0],
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            1)]
        public void Add_WithInvalidData_Negative(
            int[] ctorParams,
            int[] paramsToAdd,
            int errorParam)
        {

            Database database = new Database(ctorParams);
            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }
            Assert.Throws<InvalidOperationException>(()
                => database.Add(errorParam)
            );
        }

        [TestCase(
          new int[] { 1, 2, 3 },
          new int[] { 1, 2, 3, 4, 5 },
          3,
          5)]
        [TestCase(
          new int[0],
          new int[] { 1, 2, 3, 4, 5 },
          5,
          0)]
        [TestCase(
          new int[] { 1 },
          new int[] { 5 },
          1,
          1)]
        public void Remove_WithValidData_PositiveTest(
            int[] ctorParams,
            int[] paramsToAdd,
            int removeCount,
            int expectedCount)
        {
            //Arrange
            Database database = new Database(ctorParams);


            foreach (var item in paramsToAdd)
            {
                database.Add(item);
            }

            //Act

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();

            }

            //Assert
            Assert.AreEqual(expectedCount, database.Count);
        }


        [TestCase(
       new[] { 1 },
       1)]
        [TestCase(
       new[] { 1, 2, 3, 4, 5 },
       5)]
        [TestCase(
       new int[0],
       0)]

        public void Remove_WithInvalidData_NegativeTest(
            int[] ctorParams,
            int toRemove)
        {
            //Arrange
            Database database = new Database(ctorParams);
            //Act

            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
            }
            //Assert
            Assert.Throws<InvalidOperationException>(
                () => database.Remove());

        }
        [TestCase(
            new int[] { 10, 10, 20 },
            new int[] { 50, 40, 1000 },
             2,
            new int[] {10,10,20,50})]
        public void Fetch_With_Valid_Data_Possitive_Test(
            int[] ctorParams,
            int[] paramsToAdd,
            int removeCount,
            int[] expectedArray)
        {
            //Arrange
            Database database = new Database(ctorParams);

            foreach (var item in paramsToAdd)
            {
                database.Add(item);
            }
            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }
            //Act
            int[] actualData = database.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedArray,actualData);

        }
    }
}
