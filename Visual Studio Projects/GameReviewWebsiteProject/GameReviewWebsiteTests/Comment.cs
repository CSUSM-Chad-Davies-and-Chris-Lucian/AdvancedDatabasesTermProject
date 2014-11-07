using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Comment
    {
        public Comment()
        {
        }

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
            this.UIMap.LogOffUserForNextTest();
            
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
            this.UIMap.LogOffUserForNextTest();
            
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
            this.UIMap.LogOffUserForNextTest();
            
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
            this.UIMap.LogOffUserForNextTest();
            
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
            this.UIMap.LogOffUserForNextTest();
        }

        [TestMethod]
        public void DeletePost()
        {
            this.UIMap.OpenSite();
            this.UIMap.SwitchToLogin();
            this.UIMap.TypeFrank();
            this.UIMap.TypeCorrectPassword();
            this.UIMap.PressLogIn();
            this.UIMap.SelectDestiny();
            this.UIMap.SelectDelete();
            this.UIMap.ConfirmDelete();
            this.UIMap.AddDeleteInsertion();
            this.UIMap.LogOffUserForNextTest();
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
