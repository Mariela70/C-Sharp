using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void Hero_Creation() 
    {
        Hero hero = new Hero("m", 1);
        Assert.AreEqual(hero.Name, "m");
        Assert.AreEqual(hero.Level, 1);
        
    }
    [Test]
    public void Hero_Creation_Construktor_List_is_No_Null()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.IsNotNull(heroRepository);

    }

    [Test]
    public void Hero_Repository_Create_Name()
    {
        HeroRepository heroRepository = new HeroRepository();
        var hero = new Hero("m", 1);
        heroRepository.Create(hero);
        Assert.AreSame(heroRepository, heroRepository);
       
        
    }
    
    
    [Test]
    public void Hero_Get_Hero_Creation_()
    {

        Hero hero = new Hero("m", 1);
        Assert.AreEqual(true, hero.Name.Equals("m"));
    }
    [Test]
    public void Hero_Repository_Hero_Creation_Name_Null()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {

            heroRepository.Create(null);

        });
    }
    [Test]
    public void Hero_Repository_Hero_Creation_Name_Exist()
    {
        HeroRepository heroRepository = new HeroRepository();
        var hero = new Hero("M", 2);
        heroRepository.Create(hero);
        Assert.Throws<InvalidOperationException>(() =>
        {

            heroRepository.Create(hero);

        });

    }
    [Test]
    public void Hero_Repository_Hero_Creation_Name_Exist_valid_Messages()
    {
        HeroRepository heroRepository = new HeroRepository();
        var hero = new Hero("M", 2);
        var messages =heroRepository.Create(hero);
        var expectedMessages = "Successfully added hero M with level 2";
        Assert.AreEqual(1, heroRepository.Heroes.Count);
        Assert.AreEqual(expectedMessages, messages);

    }
    [Test]
    public void Hero_Repository_Remove_Throw()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }
    [Test]
    public void Hero_Repository_Hero_Removed_valid_Messages()
    {
        HeroRepository heroRepository = new HeroRepository();
        var isRemoved = heroRepository.Remove("M");
        Assert.IsFalse(isRemoved);
        Assert.AreEqual(0, heroRepository.Heroes.Count);
        

    }
    [Test]
    public void Hero_Get_Hero_With_Highest_Level()
    {
        HeroRepository heroRepository = new HeroRepository();
        var meri = new Hero("M", 2);
        var ceco = new Hero("C", 5);
        heroRepository.Create(meri);
        heroRepository.Create(ceco);

        var hero = heroRepository.GetHeroWithHighestLevel();
        Assert.AreSame(ceco, hero);

    }
    [Test]
    public void Hero_Get_Hero_()
    {
        HeroRepository heroRepository = new HeroRepository();
        var meri = new Hero("M", 2);
        var ceco = new Hero("C", 5);
        heroRepository.Create(meri);
        heroRepository.Create(ceco);

        var hero = heroRepository.GetHero("M");
        Assert.AreSame(meri, hero);

    }

}