//Authors: Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/6/2014
//Codesd UI Tests for the Author Controller
//This class tests all functionality related to the Author

using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Author
    {

        //Searches for the author named Sox
        //Then verifies it exists
        [TestMethod]
        public void SearchForAuthorSox()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            this.UIMap.TypeInSearchBox("Sox");
            this.UIMap.ClickSearchAuth();
            this.UIMap.AssertSox();
            
        }

        //Searches for a author with a name too long
        // Asserts that the search is reduced in length and a warning is displayed to the user
        [TestMethod]
        public void SearchForAuthorLong()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            var Content = new String('z', 51);
            this.UIMap.TypeInSearchBox(Content);
            this.UIMap.ClickSearchAuth();
            this.UIMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
"zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
" Name \r\n\r\nRating ", Content));
            

        }

        //Searches for nothing
        //Asserts that nothing happens
        [TestMethod]
        public void SearchForAuthorNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            this.UIMap.ClickSearchAuth();
            this.UIMap.AssertAuthorNotSearched();
        }

        //Searches for authors that dont exist
        //Asserts appropriate warning is displayed
        [TestMethod]
        public void SearchForAuthorNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.ClickSearchAuth();
            this.UIMap.AssertAuthorsNotThere1();

            
        }

        //Test context code for the coded UI test
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

        //UI map code for the coded UI tests
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
