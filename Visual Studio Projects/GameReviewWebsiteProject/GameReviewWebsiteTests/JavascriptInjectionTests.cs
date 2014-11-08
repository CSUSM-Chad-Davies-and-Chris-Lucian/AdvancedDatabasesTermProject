using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class JavascriptInjectionTests
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
        public void RegisterWithJavascriptInjectionNameAndGoodPassword()
        {
            UiMap.OpenSite();
            UiMap.SwitchToRegister();
            var userName = "Frank<script>alert('Injected!');</script> " + DateTime.Now.ToString();
            UiMap.TypeUserName(userName);
            UiMap.TypeGoodPasswords1();
            UiMap.TypeBio();
            UiMap.AssertUserRegisterFail(userName);

        }
    }
}
