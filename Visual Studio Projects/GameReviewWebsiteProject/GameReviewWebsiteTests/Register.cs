using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Register
    {
        public Register()
        {
        }

        [TestMethod]
        public void RegisterBadPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            UIMap tempQualifier = this.UIMap;
            this.UIMap.TypeUserName(tempQualifier.TypeUserNameParams.UIUsernameEditText);
            this.UIMap.TypePasswords();
            this.UIMap.TypeBio();
            this.UIMap.PressRegister();
            this.UIMap.CheckPassConfShort();
            
        }


        [TestMethod]
        public void RegisterGoodPassword()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            UIMap tempQualifier = this.UIMap;
            var userName = tempQualifier.TypeUserNameParams.UIUsernameEditText + DateTime.Now.ToString();
            this.UIMap.TypeUserName(userName);
            this.UIMap.TypeGoodPasswords1();
            this.UIMap.TypeBio();
            this.UIMap.PressRegister();
            this.UIMap.AssertUserRegisterSuccess(userName);
            this.UIMap.LogOffUserForNextTest();
        }

        [TestMethod]
        public void RegisterCheckDuplicate()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToRegister();
            UIMap tempQualifier = this.UIMap;
            this.UIMap.TypeUserName(tempQualifier.TypeUserNameParams.UIUsernameEditText);
            this.UIMap.TypeGoodPasswords1();
            this.UIMap.TypeBio();
            this.UIMap.PressRegister();
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
        }

        [TestMethod
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
