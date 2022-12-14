using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void Garje_Construktor_Validation ()
            {
                Garage garage = new Garage("Ceco", 20);
                Assert.AreEqual(garage.Name, "Ceco");
                Assert.AreEqual(garage.MechanicsAvailable, 20);
            
            }
            [Test]
            public void Garje_Get_Name_Validation()
            {
                Garage garage = new Garage("dam", 3);
                Assert.AreEqual(garage.Name, "dam");


            }
            [Test]
            public void Garje_Add_Name_Validation()
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(null, 1));
                Assert.Throws<ArgumentNullException>(() => new Garage(string.Empty, 1));

            }
            [Test]
            public void Garje_Mechaniker_Available_Validation()
            {
                Assert.Throws<ArgumentException>(() => new Garage("Meri", -1));
                

            }
            [Test]
            public void Garje_Mechaniker_Get_Available_Validation()
            {
                Garage garage = new Garage("dam", 3);
                Assert.AreEqual(garage.MechanicsAvailable, 3);


            }
            [Test]
            public void Garje_Cars_Counter()
            {
                Garage garage = new Garage("Ceco", 1);
                int expectedCount = 1;
                var Car = new Car("BMV", 5);
                garage.AddCar(Car);
                Assert.IsTrue(expectedCount > 0);


            }

           
            [Test]
            public void Garje_Cars_To_Fix()
            {
                Garage garage = new Garage("Ceco", 1);
                Assert.Throws<InvalidOperationException>(() => garage.FixCar(null));



            }
            [Test]
            public void Garje_Cars_To_Remove()
            {
                Garage garage = new Garage("Ceco", 1);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());



            }
            [Test]
            public void Garje_Cars_To_Report()
            {
                Garage garage = new Garage("Ceco", 1);
                garage.AddCar(new Car("dam", 2));
                var report = garage.Report();
                Assert.AreEqual($"There are 1 which are not fixed: dam.", garage.Report());



            }
        }
    }
}