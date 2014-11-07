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
    public class Login
    {
        public Login()
        {
        }

//=========================================================================================
        // Login
        [TestMethod]
        public void LoginBadPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToLogin();
            this.UIMap.TypeFrank();
            this.UIMap.TypeWrongPassword();
            this.UIMap.PressLogIn();
            this.UIMap.WrongPassword();
            //this.UIMap.closesite();
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

            //this.UIMap.closesite();

        }
        [TestMethod]
        public void LoginNoValue()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToLogin();
            this.UIMap.PressLogIn1();
            this.UIMap.CheckUserNameFieldEmpty();
            this.UIMap.CheckPasswordFieldEmpty();
            //this.UIMap.closesite();
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
