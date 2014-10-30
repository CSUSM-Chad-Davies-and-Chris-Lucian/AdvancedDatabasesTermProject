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
    public class Comment
    {
        public Comment()
        {
        }

//=========================================================================================
        // Comment
        // Need to finish Not Started
        [TestMethod]
        public void CommentNoTitle()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToLogIn();
            this.UIMap.TypeLoginCredentials();
            this.UIMap.HitLogin();
            this.UIMap.ChangeToDestiny();
            this.UIMap.TypeComment();
            this.UIMap.HitAddComment();
            this.UIMap.CheckForTitleFieldReq();
            ////this.UIMap.closesite();
        }

        [TestMethod]
        public void CommentLongTitle()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToLogIn();
            this.UIMap.TypeLoginCredentials();
            this.UIMap.HitLogin();
            this.UIMap.ChangeToDestiny();
            this.UIMap.InputLongTitle();
            this.UIMap.AddTestComment();
            this.UIMap.CheckTitleMaxLength();
            ////this.UIMap.closesite();
        }

        [TestMethod]
        public void CommentNoContent()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToLogIn();
            this.UIMap.TypeLoginCredentials();
            this.UIMap.HitLogin();
            this.UIMap.ChangeToDestiny();
            this.UIMap.EnterCommentTitle();
            this.UIMap.AddCommentButton();
            this.UIMap.CheckContentReq();
            ////this.UIMap.closesite();
        }

        // Very Long Content 
        [TestMethod]
        public void CommentLongContent()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToLogIn();
            this.UIMap.TypeLoginCredentials();
            this.UIMap.HitLogin();
            this.UIMap.ChangeToDestiny();
            this.UIMap.TypeTitleComment();
            this.UIMap.Enter4001ContentTest();
            this.UIMap.AssertCommentContentTest();

            ////this.UIMap.closesite();
        }

        [TestMethod]
        public void CommentValid()
        {
            this.UIMap.OpenSite();
            this.UIMap.ChangeToLogIn();
            this.UIMap.TypeLoginCredentials();
            this.UIMap.HitLogin();
            this.UIMap.ChangeToDestiny();
            this.UIMap.EnterTitleAndCommentGood();
            this.UIMap.HitAddComment1();
            this.UIMap.CheckGoodComment1();

            //////this.UIMap.closesite();
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
