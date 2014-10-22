using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace GameReviewWebsiteTests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class GameReview
    {
        public GameReview()
        {
        }

//=========================================================================================
        // GAME REVIEW
        [TestMethod]
        public void SearchForLOLReviewAndVerifyTest()
        {
            this.UIMap.OpenSite();
            this.UIMap.TypeInSearchBox("lol");
            this.UIMap.SubmitLol();
            this.UIMap.AssertLoLSearchTest();
            this.UIMap.closesite();
        }

        [TestMethod]
        public void SearchForGameReviewLong()
        {
            this.UIMap.OpenSite();
            var Content = new String('z', 51);
            this.UIMap.TypeInSearchBox(Content);
            this.UIMap.SubmitLol();
            this.UIMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
"zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
" Name \r\n\r\nRating ", Content));
            this.UIMap.closesite();

        }
        [TestMethod]
        public void SearchForGameReviewNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.SubmitLol();
            this.UIMap.AssertEmptyGameReviewSearch();
            this.UIMap.closesite();
        }

        [TestMethod]
        public void SearchForGameReviewNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.SubmitLol();
            this.UIMap.AssertWrongReview();
            this.UIMap.closesite();
        }

//=========================================================================================
        // END GAME REVIEW

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
