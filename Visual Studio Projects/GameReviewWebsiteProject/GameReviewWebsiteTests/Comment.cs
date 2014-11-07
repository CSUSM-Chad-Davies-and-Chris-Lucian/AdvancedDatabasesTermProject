//Authors: Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/6/2014
//Codesd UI Tests for the Comment Controller
//This class tests all functionality related to the Comments

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GameReviewWebsiteTests
{
    [CodedUITest]
    public class Comment
    {

        //This tests a comment with no title
        //Asserts that error message pops up
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

        //Writes a comment with a title thats too long
        //Asserts the check for max length and the error message
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

        //Checks a comment with no body
        //Asserts the error message shows
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

        //Checks a comment with content too long.
        //Asserts error message shows after typing in over 4000 letters
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

        //Checks the functionality of a valid comment
        //Asserts the entry and submission of a valid comment
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

        //Checks a deletion of a Comment
        //Asserts the Comment was deleted
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
        
        //Context used for Coded UI tests
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

        //Ui map for coded UI tests
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
