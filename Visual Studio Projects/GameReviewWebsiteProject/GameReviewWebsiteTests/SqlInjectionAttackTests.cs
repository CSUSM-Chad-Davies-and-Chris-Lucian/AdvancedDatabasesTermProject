using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class SqlInjectionAttackTests
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


        [TestMethod]
        public void TestAuthorSearchInjectionAttack()
        {
            UiMap.OpenSite();
            UiMap.SwitchToAuthors();
            const string injectionAttack = "' ESCAPE N'~' or 1=1";
            UiMap.TypeInSearchBox(injectionAttack);
            UiMap.ClickSearchAuth();
            UiMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
                                           "zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
                                           " Name \r\n\r\nRating ", injectionAttack));
        }


        [TestMethod]
        public void TestGamesSearchInjectionAttack()
        {
            UiMap.OpenSite();
            UiMap.SwitchToGames(); 
            const string injectionAttack = "' ESCAPE N'~' or 1=1";
            UiMap.TypeInSearchBox(injectionAttack);
            UiMap.PressSearch();
            UiMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
                                           "zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
                                           " Name \r\n\r\nRating ", injectionAttack));
        }


        [TestMethod]
        public void TestGamersSearchInjectionAttack()
        {
            UiMap.OpenSite();
            UiMap.SwitchToGamers(); 
            const string injectionAttack = "' ESCAPE N'~' or 1=1";
            UiMap.TypeInSearchBox(injectionAttack);
            UiMap.PressSearch();
            UiMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
                                           "zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
                                           " Name \r\n\r\nRating ", injectionAttack));
        }


        [TestMethod]
        public void TestGameReviewsSearchInjectionAttack()
        {
            UiMap.OpenSite();
            const string injectionAttack = "' ESCAPE N'~' or 1=1";
            UiMap.TypeInSearchBox(injectionAttack);
            UiMap.PressSearch();
            UiMap.AssertLong(string.Format("Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for {0}" +
                                           "zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
                                           " Name \r\n\r\nRating ", injectionAttack));
        }

        [TestMethod]
        public void LoginSqlInjectPastPassword()
        {
            UiMap.OpenSite();
            UiMap.SwitchToLogin();
            UiMap.TypeUserName("Frank' or 1=1 or ");
            UiMap.TypeWrongPassword(); 
            UiMap.PressLogIn();
            UiMap.WrongPassword();
        }
    }
}
