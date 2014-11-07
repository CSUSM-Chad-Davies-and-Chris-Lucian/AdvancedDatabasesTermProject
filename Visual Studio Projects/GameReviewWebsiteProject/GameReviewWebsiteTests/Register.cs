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
        //Coded UI test context
        public TestContext TestContext { get; set; }

        //Coded UI UI map
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

        //Attempts Register with bad password
        //Asserts error messages show
        [TestMethod]
        public void RegisterBadPassword()
        {
            UiMap.OpenSite();
            UiMap.SwitchToRegister();
            var tempQualifier = UiMap;
            UiMap.TypeUserName(tempQualifier.TypeUserNameParams.UIUsernameEditText);
            UiMap.TypePasswords();
            UiMap.TypeBio();
            UiMap.PressRegister();
            UiMap.CheckPassConfShort();
        }

        //Register with good password
        //Registers a new user, using the date/time to create a unique user 
        //Asserts the new user is logged in after registration
        [TestMethod]
        public void RegisterGoodPassword()
        {
            UiMap.OpenSite();
            UiMap.SwitchToRegister();
            var tempQualifier = UiMap;
            var userName = tempQualifier.TypeUserNameParams.UIUsernameEditText + DateTime.Now.ToString();
            UiMap.TypeUserName(userName);
            UiMap.TypeGoodPasswords1();
            UiMap.TypeBio();
            UiMap.PressRegister();
            UiMap.AssertUserRegisterSuccess(userName);
            UiMap.LogOffUserForNextTest();
        }

        //Attempts to register a duplicate user
        //Asserts proper error message shows
        [TestMethod]
        public void RegisterCheckDuplicate()
        {
            UiMap.OpenSite();
            UiMap.SwitchToRegister();
            var tempQualifier = UiMap;
            UiMap.TypeUserName(tempQualifier.TypeUserNameParams.UIUsernameEditText);
            UiMap.TypeGoodPasswords1();
            UiMap.TypeBio();
            UiMap.PressRegister();
            UiMap.CheckUserAlreadyExist();
        }

        //Attempts to register a blank user
        //Asserts proper error messages
        [TestMethod]
        public void RegisterNoValue()
        {
            UiMap.OpenSite();
            UiMap.SwitchToRegister();
            UiMap.PressRegister();
            UiMap.UserFieldReqReg();
            UiMap.PasswordReqReg();
            UiMap.BioReqReg();
        }

        //Attempts Register too long value
        //Assers proper errors are shown 
        [TestMethod]
        public void RegisterTooLongValue()
        {
            UiMap.OpenSite();
            UiMap.SwitchToRegister();
            UiMap.FillUserName();
            UiMap.FillPasswordFull();
            UiMap.FillBioTest();
            UiMap.PressRegister();
            UiMap.CheckAllFieldsLong();
        }
    }
}