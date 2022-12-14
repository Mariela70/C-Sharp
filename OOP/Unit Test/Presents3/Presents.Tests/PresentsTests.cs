namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Present_Constructor_Validation() 
        {
            Present present = new Present("Tesst", 15);
            Assert.AreEqual("Tesst", present.Name);
            Assert.AreEqual(15, present.Magic);
        
        }
        

    }
}
