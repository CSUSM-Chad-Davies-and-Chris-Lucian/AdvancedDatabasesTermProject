//Authors: Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/6/2014
//Codesd UI Tests for the Logins Controller
//This class tests all functionality related to the Logins
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Login
    {

        //Attempts a login with a bad password
        //Asserts proper error was shown
        [TestMethod]
        public void LoginBadPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToLogin();
            this.UIMap.TypeFrank();
            this.UIMap.TypeWrongPassword();
            this.UIMap.PressLogIn();
            this.UIMap.WrongPassword();
            
        }

        //Attempts a login with a good password
        //Asserts that frank logged in correctly
        [TestMethod]
        public void LoginGoodPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToLogin();
            this.UIMap.TypeFrank();
            this.UIMap.TypeCorrectPassword();
            this.UIMap.PressLogIn();
            this.UIMap.EnsureFrankLogIn();
            this.UIMap.LogOffUserForNextTest();
        }

        //Attempts a login with no value
        //Asserts the proper errors show
        [TestMethod]
        public void LoginNoValue()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToLogin();
            this.UIMap.PressLogIn1();
            this.UIMap.CheckUserNameFieldEmpty();
            this.UIMap.CheckPasswordFieldEmpty();
            
        }

        //Attempts a login with too many charecters
        // Asserts the proper message shows
        [TestMethod]
        public void LoginTooLongValue()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToLogin();
            this.UIMap.UserZs();
            this.UIMap.PassLong();
            this.UIMap.PressLogIn1();
            this.UIMap.UserNameTooLong();
        }

        //Test context for the Coded UI tests
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

        //UI Map for Coded UI tests
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
