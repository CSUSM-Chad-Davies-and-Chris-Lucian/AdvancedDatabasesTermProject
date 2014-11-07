//Authors: Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/6/2014
//Codesd UI Tests for the Games Controller
//This class tests all functionality related to the Games

using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Game
    {

        //Checks the search of a game
        //Assert the search succeeds
        [TestMethod]
        public void SearchForGameDestiny()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            this.UIMap.TypeInSearchBox("Destiny");
            this.UIMap.PressSearch();
            this.UIMap.CheckGameDesitny();
        }

        //Checks a search for a game with a name too long
        //Asserts the warning displayed to the user
        [TestMethod]
        public void SearchForGameLong()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            var content = new String('z', 51);
            this.UIMap.TypeInSearchBox(content);
            this.UIMap.PressSearch();
            this.UIMap.AssertGamesLongSearch();
        }

        //Searches for nothing
        //Asserts nothing happens
        [TestMethod]
        public void SearchForGameNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            this.UIMap.PressSearch();
            this.UIMap.AssertGamesNothing1();
        }

        //Searches for something that does not exist
        //Asserts error shows correctly
        [TestMethod]
        public void SearchForGameNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.PressSearch();
            this.UIMap.GamesNotThere1();

            
        }

        //Coded UI test Context
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        //Coded UI test UI map
        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
