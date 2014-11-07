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
        //Test Context for Coded UI tests
        public TestContext TestContext { get; set; }

        //UI map for coded UI tests
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

        //Searches for Frank
        //Asserts Frank is in the search result
        [TestMethod]
        public void SearchForGamerFrank()
        {
            UiMap.OpenSite();
            UiMap.ChangeToGamers();
            UiMap.TypeInSearchBox("Frank");
            UiMap.PressSearch();
            UiMap.clickFrank();
            UiMap.AssertFrankWasFound();
        }

        //Searches for Gamer with too many charecters
        //Asserts proper warning shows
        [TestMethod]
        public void SearchForGamerLong()
        {
            UiMap.OpenSite();
            UiMap.ChangeToGamers();
            var content = new String('z', 51);
            UiMap.TypeInSearchBox(content);
            UiMap.PressSearch();
            UiMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
                                           "zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
                                           " Name \r\n\r\nRating ", content));
        }

        //Searches for nothing
        //Asserts nothing happens
        [TestMethod]
        public void SearchForGamerNothing()
        {
            UiMap.OpenSite();
            UiMap.ChangeToGamers();
            UiMap.PressSearch();
            UiMap.AssertMMOMan();
        }

        //Searches for gamer not there
        //Asserts the proper error shows
        [TestMethod]
        public void SearchForGamerNotThere()
        {
            UiMap.OpenSite();
            UiMap.ChangeToGamers();
            UiMap.TypeInSearchBox("pickles34");
            UiMap.PressSearch();
            UiMap.GamerCheckNotThere();
        }
    }
}