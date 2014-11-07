using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Author
    {
        [TestMethod]
        public void SearchForAuthorSox()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            this.UIMap.TypeInSearchBox("Sox");
            this.UIMap.ClickSearchAuth();
            this.UIMap.AssertSox();
            
        }

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
        [TestMethod]
        public void SearchForAuthorNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            this.UIMap.ClickSearchAuth();
            this.UIMap.AssertAuthorNotSearched();
        }

        [TestMethod]
        public void SearchForAuthorNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.ClickSearchAuth();
            this.UIMap.AssertAuthorsNotThere1();

            
        }

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
