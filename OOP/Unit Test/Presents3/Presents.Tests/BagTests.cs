using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presents.Tests
{
    public class BagTests
    {
        [Test]
        public void Bag_Test_Creation() 
        {
         Bag bag = new Bag();
            
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        
        }
        [Test]
        public void Remove_Test_Method()
        {
            Bag bag = new Bag();
            Present present = new Present("Mariela", 15);
            bag.Create(present);
            Assert.True(bag.Remove(present));
            

        }
        [Test]
        public void Get_Present_With_MagicTest_Method()
        {
            Bag bag = new Bag();
            Present present = new Present("Mariela", 15);
            Present present1 = new Present("Mariela", 16);
            Present present2 = new Present("Mariela", 19);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present);
            Present actual = bag.GetPresentWithLeastMagic();
            Assert.AreSame(present, actual);


        }
        [Test]
        public void Get_Present_Method()
        {
            Bag bag = new Bag();
            Present present1 = new Present("dada", 16);
            bag.Create(present1);
            Present expected = bag.GetPresent("dada");
            Assert.AreEqual(expected, present1);


        }

    }
}
