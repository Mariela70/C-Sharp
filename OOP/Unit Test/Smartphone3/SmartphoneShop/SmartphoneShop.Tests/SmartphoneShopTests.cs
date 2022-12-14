using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test_Smartphone_Creation() 
        {

            Smartphone smartphone = new Smartphone("M", 5);
            Assert.AreEqual("M", smartphone.ModelName);
            Assert.AreEqual(5, smartphone.CurrentBateryCharge);
            Assert.AreEqual(5, smartphone.MaximumBatteryCharge);


        }
        [Test]
        public void Test_Shop_Creation()
        {

            Shop shop = new Shop(5);
            Assert.AreEqual(5, shop.Capacity);
            Assert.AreEqual(0, shop.Count);


        }
        [Test]
        public void Test_Shop_Capacity_With_Throws()
        {

            Assert.Throws<ArgumentException>(()=> new Shop(-5));


        }
        [Test]
        public void Test_Shop_Add_Works()
        {

            Shop shop = new Shop(5);
            var smartphone = new Smartphone("M", 5);
            var smartphone2 = new Smartphone("C", 4);
            shop.Add(smartphone);
            shop.Add(smartphone2);
            Assert.AreEqual(2, shop.Count);


        }
        [Test]
        public void Test_Shop_Remove_Works()
        {

            Shop shop = new Shop(5);
            var smartphone = new Smartphone("M", 5);
            var smartphone2 = new Smartphone("C", 4);
            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.Remove(smartphone.ModelName);
            Assert.AreEqual(1, shop.Count);


        }
        [Test]
        public void Test_Shop_Remove_Throws()
        {

            Shop shop = new Shop(5);
            Assert.Throws<InvalidOperationException>(()=> shop.Remove(null));


        }
        [Test]
        public void Test_Shop_Test_Charging_Phone_Works()
        {

            Shop shop = new Shop(5);
            var smartphone = new Smartphone("M", 5);
            var smartphone2 = new Smartphone("C", 4);
            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.ChargePhone(smartphone.ModelName);
            Assert.AreEqual(2, shop.Count);


        }
       
        [Test]
        public void Test_Shop_Test_Phone_Throws()
        {

            Shop shop = new Shop(5);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(null, 50));
          

        }
        [Test]
        public void Test_Shop_Charge_Phone_Throws()
        {

            Shop shop = new Shop(5);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone(null));



        }


    }
}