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
        //Searches for a review "lol"
        //Asserts the game LOL was found
        [TestMethod]
        public void SearchForLolReviewAndVerifyTest()
        {
            this.UIMap.OpenSite();
            this.UIMap.TypeInSearchBox("lol");
            this.UIMap.PressSearch();
            this.UIMap.AssertLoLSearchTest();
            
        }

        //Searches for a game review thats too long
        //Assserts the appropriate message shows
        [TestMethod]
        public void SearchForGameReviewLong()
        {
            this.UIMap.OpenSite();
            var Content = new String('z', 51);
            this.UIMap.TypeInSearchBox(Content);
            this.UIMap.PressSearch();
            this.UIMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
"zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
" Name \r\n\r\nRating ", Content));
        }

        //Searches for No game review
        // Asserts nothing happens
        [TestMethod]
        public void SearchForGameReviewNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.PressSearch();
            this.UIMap.AssertEmptyGameReviewSearch();
            
        }

        //Searches for game review thats not there
        //Asserts nothing happens
        [TestMethod]
        public void SearchForGameReviewNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.PressSearch();
            this.UIMap.GameReveiewNotThere();
        }

        //Test context for the Coded UI tests
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

        //UI Map for Coded UI tests
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
