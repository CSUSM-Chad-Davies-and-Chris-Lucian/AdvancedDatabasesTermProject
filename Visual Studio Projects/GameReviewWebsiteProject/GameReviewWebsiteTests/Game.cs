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
    public class Game
    {
        public Game()
        {
        }

//=========================================================================================
        // GAME
        [TestMethod]
        public void SearchForGameDestiny()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            this.UIMap.TypeInSearchBox("Destiny");
            this.UIMap.SubmitLol();
            this.UIMap.AssertDestiny();
            this.UIMap.closesite();
        }

        [TestMethod]
        public void SearchForGameLong()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            var Content = new String('z', 51);
            this.UIMap.TypeInSearchBox(Content);
            this.UIMap.SubmitLol();
            this.UIMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
"zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
" Name \r\n\r\nRating ", Content));
            this.UIMap.closesite();

        }
        [TestMethod]
        public void SearchForGameNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            this.UIMap.SubmitLol();
            this.UIMap.AssertGamesNothing1();
            this.UIMap.closesite();
        }

        [TestMethod]
        public void SearchForGameNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.SubmitLol();
            this.UIMap.AssertNotThereGames();
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
