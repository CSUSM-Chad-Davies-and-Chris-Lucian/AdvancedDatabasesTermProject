using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Game
    {
        public Game()
        {
        }

        [TestMethod]
        public void SearchForGameDestiny()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            this.UIMap.TypeInSearchBox("Destiny");
            this.UIMap.PressSearch();
            this.UIMap.CheckGameDesitny();


            
        }

        [TestMethod]
        public void SearchForGameLong()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            var Content = new String('z', 51);
            this.UIMap.TypeInSearchBox(Content);
            this.UIMap.PressSearch();
            this.UIMap.AssertGamesLongSearch();

            

        }
        [TestMethod]
        public void SearchForGameNothing()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            this.UIMap.PressSearch();
            this.UIMap.AssertGamesNothing1();
            
        }

        [TestMethod]
        public void SearchForGameNotThere()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToGames();
            this.UIMap.TypeInSearchBox("pickles34");
            this.UIMap.PressSearch();
            this.UIMap.GamesNotThere1();

            
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
