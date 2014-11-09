//Authors: Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/6/2014
//Coded UI Tests for the Logins Controller
//This class tests all functionality related to the Logins

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Login
    {
        //Test context for the Coded UI tests
        public TestContext TestContext { get; set; }

        //UI Map for Coded UI tests
        private UIMap map;
        public UIMap UIMap
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

        //Attempts a login with a bad password
        //Asserts proper error was shown
        [TestMethod]
        public void LoginBadPassword()
        {
            UIMap.OpenSite();
            UIMap.SwitchToLogin();
            UIMap.TypeFrank();
            UIMap.TypeWrongPassword();
            UIMap.PressLogIn();
            UIMap.WrongPassword();
        }

        //Attempts a login with a good password
        //Asserts that frank logged in correctly
        [TestMethod]
        public void LoginGoodPassword()
        {
            UIMap.OpenSite();
            UIMap.SwitchToLogin();
            UIMap.TypeFrank();
            UIMap.TypeCorrectPassword();
            UIMap.PressLogIn();
            UIMap.EnsureFrankLogIn();
            UIMap.LogOffUserForNextTest();
        }

        //Attempts a login with no value
        //Asserts the proper errors show
        [TestMethod]
        public void LoginNoValue()
        {
            UIMap.OpenSite();
            UIMap.SwitchToLogin();
            UIMap.PressLogIn1();
            UIMap.CheckUserNameFieldEmpty();
            UIMap.CheckPasswordFieldEmpty();
        }

        //Attempts a login with too many charecters
        // Asserts the proper message shows
        [TestMethod]
        public void LoginTooLongValue()
        {
            UIMap.OpenSite();
            UIMap.SwitchToLogin();
            UIMap.UserZs();
            UIMap.PassLong();
            UIMap.PressLogIn1();
            UIMap.UserNameTooLong();
        }
    }
}