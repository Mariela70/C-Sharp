namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public  void Test_Aquarium_Exist() 
        {
            Aquarium aquarium = new Aquarium("Mariela", 50);
            Assert.AreEqual("Mariela", aquarium.Name);
            Assert.AreEqual(aquarium.Capacity, 50);
        
        }
        [Test]
        public void Test_Aquarium_Exist_With_Null_Name_Throes()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {

                Aquarium aquarium = new Aquarium(null, 50);

            });

        }
        [Test]
        public void Test_Aquarium_Exist_With_Negative_Capacity_Throes()
        {
            Assert.Throws<ArgumentException>(() =>
            {

                Aquarium aquarium = new Aquarium("Mariela", -50);

            });

        }
        [Test]
        public void Test_Aquarium_Add_Fish_Works()
        {
            Aquarium aquarium = new Aquarium("Mariela", 50);
            var fish = new Fish("Ceco");
            var fish1 = new Fish("Mari");
            aquarium.Add(fish);
            aquarium.Add(fish1);
            Assert.AreEqual(2, aquarium.Count);
            
           

        }
        [Test]
        public void Test_Aquarium_Add_Fish_With_Capacity_Throes()
        {
            Aquarium aquarium = new Aquarium("Mariela", 0);
            var fish = new Fish("Ceco");
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            
            });

        }
        [Test]
        public void Test_Aquarium_Remove_Fish_Works()
        {
            Aquarium aquarium = new Aquarium("Mariela", 1);
            var fish = new Fish("Ceco");
            aquarium.Add(fish);
            aquarium.RemoveFish("Ceco");
            Assert.AreEqual(aquarium.Count, 0);



        }
        [Test]
        public void Test_Aquarium_Remove_Fish_With_Capacity_Throes()
        {
            
            Aquarium aquarium = new Aquarium("Mariela", 1);
            var fish = new Fish("Ceco");
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(null);

            });

        }
        [Test]
        public void Test_Self_Fish_Throes()
        {
            Aquarium aquarium = new Aquarium("Mariela", 1);
            var fish = new Fish("Ceco");
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish(null);

            });

        }
        [Test]
        public void Test_Self_Fish_Works()
        {
            Aquarium aquarium = new Aquarium("Mariela", 1);
            
            aquarium.Add(new Fish("dadada"));
            Fish fish = aquarium.SellFish("dadada");
            Assert.AreEqual(fish.Name, "dadada");
            Assert.AreEqual(fish.Available, false);
        }
        [Test]
        public void Report()
        {
            Aquarium aquarium = new Aquarium("dada", 1);
            aquarium.Add(new Fish("dam"));
            var report = aquarium.Report(); 
            Assert.AreEqual($"Fish available at dada: dam", aquarium.Report());
        }
    }
}
