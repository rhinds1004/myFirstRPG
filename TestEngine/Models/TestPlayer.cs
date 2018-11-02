using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Models.Tests
{
    [TestClass()]
    public class TestPlayer
    {
       

        [TestMethod()]
        public void CreatePlayerTest()
        {
            int xp = 9, maxHp = 8, currHp = 7, myGold = 100;
            string testPlayerName = "testTwerp";
            string testPlayerClass = "twerpClass";
            Player testPlayer = new Player(testPlayerName, testPlayerClass, xp, maxHp, currHp, myGold);
            Assert.AreEqual(testPlayerName, testPlayer.Name);
            Assert.AreEqual(testPlayerClass, testPlayer.CharacterClass);
            Assert.AreEqual(xp, testPlayer.ExperiencePoints);
            Assert.AreEqual(maxHp, testPlayer.MaximumHitPoints);
            Assert.AreEqual(currHp, testPlayer.CurrentHitPoints);
            Assert.AreEqual(myGold, testPlayer.Gold);
        }

        [TestMethod()]
        public void HasAllTheseItemsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddExperienceTest()
        {
            Assert.Fail();
        }
    }
}

