using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("me", "i");
        }

        [Test]
        public void When_Cell_Does_Not_Exist_Shoud_Throw_Exception()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {

                vault.AddItem("go nqma", item);
            });
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }
        [Test]
        public void When_Cell_Is_Allready_Taken_Shoud_Throw_Exception()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {

                vault.AddItem("A2", item);
                vault.AddItem("A2", new Item("Pesho", "3"));
            });
            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }
        [Test]
        public void When_Item_Is_Allready_Taken_Shoud_Throw_Exception()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {

                vault.AddItem("A1", item);
                vault.AddItem("B3", item);
            });
            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }
        [Test]
        public void When_Item_Is_Added_Taken_Shoud_Return_Corekt()
        {
            string result = vault.AddItem("A1", item);
            Assert.AreEqual(result, "Item:i saved successfully!");
        }
        [Test]
        public void When_Remove_Cell_And_Cell_Does_Not_Exist_Shoud_Throw_Exception()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {

                vault.RemoveItem("go nqma", item);
            });
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }
        [Test]
        public void When_Remove_Cell_And_Item_Does_Not_Exist_Shoud_Throw_Exception()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {

                vault.RemoveItem("A2", item);
            });
            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }
        [Test]
        public void When_Item_Is_Removed_Shoud_Return_Corekt()
        {
            vault.AddItem("A1", item);
            string result = vault.RemoveItem("A1", item);
            Assert.AreEqual(result, "Remove item:i successfully!");
        }

    }
}