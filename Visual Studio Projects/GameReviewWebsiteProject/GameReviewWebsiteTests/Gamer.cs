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
    public class Gamer
    {
        public Gamer()
        {
        }

//=========================================================================================
        // GAME
        [TestMethod]
        public void SearchForGamerFrank()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToGamers();
            this.UIMap.TypeInSearchBox("Frank");
            this.UIMap.PressSearch();
            //this.UIMap.AssertLinkContent("Frank");
            this.UIMap.clickFrank();
            //this.UIMap.closesite();
        }

        [TestMethod]
        public void SearchForGamerLong()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToGamers();
            var Content = new String('z', 51);
            this.UIMap.TypeInSearchBox(Content);
            this.UIMap.PressSearch();
            this.UIMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
"zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
" Name \r\n\r\nRating ", Content));
            //this.UIMap.closesite();

        }
        [TestMethod]
        public void SearchForGamerNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToGamers();
            this.UIMap.PressSearch();
            this.UIMap.AssertMMOMan();
            //this.UIMap.closesite();
        }

        [TestMethod]
        public void SearchForGamerNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToGamers();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.PressSearch();
            this.UIMap.GamerCheckNotThere();

            //this.UIMap.closesite();
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
