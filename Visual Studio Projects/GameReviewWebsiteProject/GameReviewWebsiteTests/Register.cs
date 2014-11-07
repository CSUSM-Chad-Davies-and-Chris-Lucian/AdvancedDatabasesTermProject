//Authors: Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/6/2014
//Codesd UI Tests for the Registration Controller
//This class tests all functionality related to the Registration

using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Register
    {

        //Attempts Register with bad password
        //Asserts error messages show
        [TestMethod]
        public void RegisterBadPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            var tempQualifier = this.UIMap;
            this.UIMap.TypeUserName(tempQualifier.TypeUserNameParams.UIUsernameEditText);
            this.UIMap.TypePasswords();
            this.UIMap.TypeBio();
            this.UIMap.PressRegister();
            this.UIMap.CheckPassConfShort();
        }

        //Register with good password
        //Registers a new user, using the date/time to create a unique user 
        //Asserts the new user is logged in after registration
        [TestMethod]
        public void RegisterGoodPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            var tempQualifier = this.UIMap;
            var userName = tempQualifier.TypeUserNameParams.UIUsernameEditText + DateTime.Now.ToString();
            this.UIMap.TypeUserName(userName);
            this.UIMap.TypeGoodPasswords1();
            this.UIMap.TypeBio();
            this.UIMap.PressRegister();
            this.UIMap.AssertUserRegisterSuccess(userName);
            this.UIMap.LogOffUserForNextTest();
        }

        //Attempts to register a duplicate user
        //Asserts proper error message shows
        [TestMethod]
        public void RegisterCheckDuplicate()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            var tempQualifier = this.UIMap;
            this.UIMap.TypeUserName(tempQualifier.TypeUserNameParams.UIUsernameEditText);
            this.UIMap.TypeGoodPasswords1();
            this.UIMap.TypeBio();
            this.UIMap.PressRegister();
            this.UIMap.CheckUserAlreadyExist();
        }

        //Attempts to register a blank user
        //Asserts proper error messages
        [TestMethod]
        public void RegisterNoValue()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            this.UIMap.PressRegister();
            this.UIMap.UserFieldReqReg();
            this.UIMap.PasswordReqReg();
            this.UIMap.BioReqReg();
        }

        //Attempts Register too long value
        //Assers proper errors are shown 
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
        }

        //Coded UI test context
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

        //Coded UI UI map
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
