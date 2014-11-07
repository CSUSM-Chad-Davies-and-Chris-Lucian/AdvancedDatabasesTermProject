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
        //Coded UI test Context
        public TestContext TestContext { get; set; }

        //Coded UI test UI map
        private UIMap map;
        public UIMap UiMap
        {
            get
            {
                if ((map == null))
                {
                    map = new UIMap();
                }

                return map;
            }
        }


        //Checks the search of a game
        //Assert the search succeeds
        [TestMethod]
        public void SearchForGameDestiny()
        {
            UiMap.OpenSite();
            UiMap.SwitchToGames();
            UiMap.TypeInSearchBox("Destiny");
            UiMap.PressSearch();
            UiMap.CheckGameDesitny();
        }

        //Checks a search for a game with a name too long
        //Asserts the warning displayed to the user
        [TestMethod]
        public void SearchForGameLong()
        {
            UiMap.OpenSite();
            UiMap.SwitchToGames();
            var content = new String('z', 51);
            UiMap.TypeInSearchBox(content);
            UiMap.PressSearch();
            UiMap.AssertGamesLongSearch();
        }

        //Searches for nothing
        //Asserts nothing happens
        [TestMethod]
        public void SearchForGameNothing()
        {
            UiMap.OpenSite();
            UiMap.SwitchToGames();
            UiMap.PressSearch();
            UiMap.AssertGamesNothing1();
        }

        //Searches for something that does not exist
        //Asserts error shows correctly
        [TestMethod]
        public void SearchForGameNotThere()
        {
            UiMap.OpenSite();
            UiMap.SwitchToGames();
            UiMap.TypeInSearchBox("pickles34");
            UiMap.PressSearch();
            UiMap.GamesNotThere1();
        }
    }
}