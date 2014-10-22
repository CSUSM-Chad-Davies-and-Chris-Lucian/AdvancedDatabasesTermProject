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
    public class Register
    {
        public Register()
        {
        }

//=========================================================================================
        // Register
        [TestMethod]
        public void RegisterBadPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            this.UIMap.TypeUserName();
            this.UIMap.TypePasswords();
            this.UIMap.TypeAvBio();
            this.UIMap.PressRegister();
            this.UIMap.CheckPasswordShort();
            this.UIMap.closesite();
        }

        [TestMethod]
        public void RegisterGoodPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            this.UIMap.TypeUserName();
            this.UIMap.TypeGoodPasswords1();
            this.UIMap.TypeAvBio();
            this.UIMap.PressRegister();
            this.UIMap.RegisterAlreadyExist();

            //this.UIMap.CheckUserNameRegistered();
            this.UIMap.closesite();

        }
        [TestMethod]
        public void RegisterNoValue()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            this.UIMap.PressRegister();
            this.UIMap.UserFieldReqReg();
            this.UIMap.PasswordReqReg();
            this.UIMap.AvatarReqReg();
            this.UIMap.BioReqReg();
            this.UIMap.closesite();
        }

        [TestMethod]
        public void RegisterTooLongValue()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            this.UIMap.RegFillFieldsFull();
            // breaks after filling fields
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
