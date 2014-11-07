using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Login
    {
        public Login()
        {
        }

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
        [TestMethod]
        public void LoginNoValue()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToLogin();
            this.UIMap.PressLogIn1();
            this.UIMap.CheckUserNameFieldEmpty();
            this.UIMap.CheckPasswordFieldEmpty();
            
        }

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
