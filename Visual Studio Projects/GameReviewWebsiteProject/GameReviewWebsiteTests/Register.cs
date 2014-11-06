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
            this.UIMap.TypeBio();
            this.UIMap.PressRegister();
            this.UIMap.CheckPassConfShort();
            //this.UIMap.closesite();
        }

        /*
        [TestMethod]
        public void RegisterGoodPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            this.UIMap.TypeUserName();
            this.UIMap.TypeGoodPasswords1();
            this.UIMap.TypeBio();
            this.UIMap.PressRegister();

            //must test with new username otherwise just check for already exist
            this.UIMap.CheckUserAlreadyExist();
            //this.UIMap.closesite();
        }*/

        [TestMethod]
        public void RegisterCheckDuplicate()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            this.UIMap.TypeUserName();
            this.UIMap.TypeGoodPasswords1();
            this.UIMap.TypeBio();
            this.UIMap.PressRegister();

            //must test with new username otherwise just check for already exist
            this.UIMap.CheckUserAlreadyExist();
        }

        [TestMethod]
        public void RegisterNoValue()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            this.UIMap.PressRegister();
            this.UIMap.UserFieldReqReg();
            this.UIMap.PasswordReqReg();
            this.UIMap.BioReqReg();
            //this.UIMap.closesite();
        }

        // Very Long Value
        [TestMethod]
        public void RegisterTooLongValue()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            this.UIMap.FillUserName();
            this.UIMap.FillPasswordFull();
            this.UIMap.FillBioTest();
            this.UIMap.PressRegister();
            this.UIMap.CheckAllFieldsLong();
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
