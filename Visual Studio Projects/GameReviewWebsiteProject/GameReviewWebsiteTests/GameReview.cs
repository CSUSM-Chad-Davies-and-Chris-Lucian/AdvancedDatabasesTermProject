//Authors: Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/6/2014
//Codesd UI Tests for the Game Reviews Controller
//This class tests all functionality related to the Game Reviews

using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class GameReview
    {
        //Test context for the Coded UI tests
        public TestContext TestContext { get; set; }

        //UI Map for Coded UI tests
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

        //Searches for a review "lol"
        //Asserts the game LOL was found
        [TestMethod]
        public void SearchForLolReviewAndVerifyTest()
        {
            UiMap.OpenSite();
            UiMap.TypeInSearchBox("lol");
            UiMap.PressSearch();
            UiMap.AssertLoLSearchTest();
        }

        //Searches for a game review thats too long
        //Assserts the appropriate message shows
        [TestMethod]
        public void SearchForGameReviewLong()
        {
            UiMap.OpenSite();
            var content = new String('z', 51);
            UiMap.TypeInSearchBox(content);
            UiMap.PressSearch();
            UiMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
                                           "zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
                                           " Name \r\n\r\nRating ", content));
        }

        //Searches for No game review
        // Asserts nothing happens
        [TestMethod]
        public void SearchForGameReviewNothing()
        {
            UiMap.OpenSite();
            UiMap.PressSearch();
            UiMap.AssertEmptyGameReviewSearch();
        }

        //Searches for game review thats not there
        //Asserts nothing happens
        [TestMethod]
        public void SearchForGameReviewNotThere()
        {
            UiMap.OpenSite();
            UiMap.TypeInSearchBox("pickles34");
            UiMap.PressSearch();
            UiMap.GameReveiewNotThere();
        }
    }
}