//Authors: Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/6/2014
//Codesd UI Tests for the Gamers Controller
//This class tests all functionality related to the Gamers

using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Gamer
    {
        //Searches for Frank
        //Asserts Frank is in the search result
        [TestMethod]
        public void SearchForGamerFrank()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToGamers();
            this.UIMap.TypeInSearchBox("Frank");
            this.UIMap.PressSearch();
            this.UIMap.clickFrank();
            this.UIMap.AssertFrankWasFound();

        }

        //Searches for Gamer with too many charecters
        //Asserts proper warning shows
        [TestMethod]
        public void SearchForGamerLong()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToGamers();
            var content = new String('z', 51);
            this.UIMap.TypeInSearchBox(content);
            this.UIMap.PressSearch();
            this.UIMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
"zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
" Name \r\n\r\nRating ", content));
        }

        //Searches for nothing
        //Asserts nothing happens
        [TestMethod]
        public void SearchForGamerNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToGamers();
            this.UIMap.PressSearch();
            this.UIMap.AssertMMOMan();
            
        }

        //Searches for gamer not there
        //Asserts the proper error shows
        [TestMethod]
        public void SearchForGamerNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToGamers();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.PressSearch();
            this.UIMap.GamerCheckNotThere();

            
        }

        //Test Context for Coded UI tests
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

        //UI map for coded UI tests
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
