using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class GameReview
    {
        public GameReview()
        {
        }

        [TestMethod]
        public void SearchForLOLReviewAndVerifyTest()
        {
            this.UIMap.OpenSite();
            this.UIMap.TypeInSearchBox("lol");
            this.UIMap.PressSearch();
            this.UIMap.AssertLoLSearchTest();
            
        }

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
        [TestMethod]
        public void SearchForGameReviewNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.PressSearch();
            this.UIMap.AssertEmptyGameReviewSearch();
            
        }

        [TestMethod]
        public void SearchForGameReviewNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.PressSearch();
            this.UIMap.GameReveiewNotThere();

            
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
