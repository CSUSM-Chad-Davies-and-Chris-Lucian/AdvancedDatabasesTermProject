//Authors: Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/6/2014
//Coded UI Tests for the Author Controller
//This class tests all functionality related to the Author

using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Author
    {
        //Test context code for the coded UI test
        public TestContext TestContext { get; set; }

        //UI map code for the coded UI tests
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

        //Searches for the author named Sox
        //Then verifies it exists
        [TestMethod]
        public void SearchForAuthorSox()
        {
            UiMap.OpenSite();
            UiMap.SwitchToAuthors();
            UiMap.TypeInSearchBox("Sox");
            UiMap.ClickSearchAuth();
            UiMap.AssertSox();
        }

        //Searches for a author with a name too long
        // Asserts that the search is reduced in length and a warning is displayed to the user
        [TestMethod]
        public void SearchForAuthorLong()
        {
            UiMap.OpenSite();
            UiMap.SwitchToAuthors();
            var content = new String('z', 51);
            UiMap.TypeInSearchBox(content);
            UiMap.ClickSearchAuth();
            UiMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
                                           "zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
                                           " Name \r\n\r\nRating ", content));
        }

        //Searches for nothing
        //Asserts that nothing happens
        [TestMethod]
        public void SearchForAuthorNothing()
        {
            UiMap.OpenSite();
            UiMap.SwitchToAuthors();
            UiMap.ClickSearchAuth();
            UiMap.AssertAuthorNotSearched();
        }

        //Searches for authors that dont exist
        //Asserts appropriate warning is displayed
        [TestMethod]
        public void SearchForAuthorNotThere()
        {
            UiMap.OpenSite();
            UiMap.SwitchToAuthors();
            UiMap.TypeInSearchBox("pickles34");
            UiMap.ClickSearchAuth();
            UiMap.AssertAuthorsNotThere1();
        }
    }
}