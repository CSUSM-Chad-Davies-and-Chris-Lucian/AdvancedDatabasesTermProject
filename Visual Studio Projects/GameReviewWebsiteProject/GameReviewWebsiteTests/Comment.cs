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
        //Context used for Coded UI tests
        public TestContext TestContext { get; set; }

        //Ui map for coded UI tests
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

        //This tests a comment with no title
        //Asserts that error message pops up
        [TestMethod]
        public void CommentNoTitle()
        {
            UiMap.OpenSite();
            UiMap.ChangeToLogIn();
            UiMap.TypeLoginCredentials();
            UiMap.HitLogin();
            UiMap.ChangeToDestiny();
            UiMap.TypeComment();
            UiMap.HitAddComment();
            UiMap.CheckForTitleFieldReq();
            UiMap.LogOffUserForNextTest();
        }

        //Writes a comment with a title thats too long
        //Asserts the check for max length and the error message
        [TestMethod]
        public void CommentLongTitle()
        {
            UiMap.OpenSite();
            UiMap.ChangeToLogIn();
            UiMap.TypeLoginCredentials();
            UiMap.HitLogin();
            UiMap.ChangeToDestiny();
            UiMap.InputLongTitle();
            UiMap.AddTestComment();
            UiMap.CheckTitleMaxLength();
            UiMap.LogOffUserForNextTest();
        }

        //Checks a comment with no body
        //Asserts the error message shows
        [TestMethod]
        public void CommentNoContent()
        {
            UiMap.OpenSite();
            UiMap.ChangeToLogIn();
            UiMap.TypeLoginCredentials();
            UiMap.HitLogin();
            UiMap.ChangeToDestiny();
            UiMap.EnterCommentTitle();
            UiMap.AddCommentButton();
            UiMap.CheckContentReq();
            UiMap.LogOffUserForNextTest();
        }

        //Checks a comment with content too long.
        //Asserts error message shows after typing in over 4000 letters
        [TestMethod]
        public void CommentLongContent()
        {
            UiMap.OpenSite();
            UiMap.ChangeToLogIn();
            UiMap.TypeLoginCredentials();
            UiMap.HitLogin();
            UiMap.ChangeToDestiny();
            UiMap.TypeTitleComment();
            UiMap.Enter4001ContentTest();
            UiMap.AssertCommentContentTest();
            UiMap.LogOffUserForNextTest();
        }

        //Checks the functionality of a valid comment
        //Asserts the entry and submission of a valid comment
        [TestMethod]
        public void CommentValid()
        {
            UiMap.OpenSite();
            UiMap.ChangeToLogIn();
            UiMap.TypeLoginCredentials();
            UiMap.HitLogin();
            UiMap.ChangeToDestiny();
            UiMap.EnterTitleAndCommentGood();
            UiMap.HitAddComment1();
            UiMap.CheckGoodComment1();
            UiMap.LogOffUserForNextTest();
        }

        //Checks a deletion of a Comment
        //Asserts the Comment was deleted
        [TestMethod]
        public void DeletePost()
        {
            UiMap.OpenSite();
            UiMap.SwitchToLogin();
            UiMap.TypeFrank();
            UiMap.TypeCorrectPassword();
            UiMap.PressLogIn();
            UiMap.SelectDestiny();
            UiMap.SelectDelete();
            UiMap.ConfirmDelete();
            UiMap.AddDeleteInsertion();
            UiMap.LogOffUserForNextTest();
        }
    }
}
