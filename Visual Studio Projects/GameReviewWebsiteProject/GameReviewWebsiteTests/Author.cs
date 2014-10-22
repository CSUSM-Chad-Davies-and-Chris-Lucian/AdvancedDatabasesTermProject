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
    public class Author
    {
        public Author()
        {
        }

//=========================================================================================
        // Author
        [TestMethod]
        public void SearchForAuthorSox()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            this.UIMap.TypeInSearchBox("Sox");
            this.UIMap.SubmitLol();
            this.UIMap.AssertSox();
            this.UIMap.closesite();
        }

        [TestMethod]
        public void SearchForAuthorLong()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            var Content = new String('z', 51);
            this.UIMap.TypeInSearchBox(Content);
            this.UIMap.SubmitLol();
            this.UIMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
"zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
" Name \r\n\r\nRating ", Content));
            this.UIMap.closesite();

        }
        [TestMethod]
        public void SearchForAuthorNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            this.UIMap.SubmitLol();
            this.UIMap.AssertAuthorsNothing();
            this.UIMap.closesite();
        }

        [TestMethod]
        public void SearchForAuthorNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToAuthors();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.SubmitLol();
            this.UIMap.AssertAuthorsNotThere();
            this.UIMap.closesite();
        }

//=========================================================================================
        // END

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
