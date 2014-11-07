namespace GameReviewWebsiteTests
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


    public partial class UIMap
    {
        public void TypeInSearchBox(string content)
        {
            #region Variable Declarations
            HtmlEdit uISearchEdit = this.UIGameReviewsGameRevieWindow1.UIGameReviewsGameRevieDocument.UISearchEdit;
            #endregion

            // Type 'lol' in 'search' text box
            uISearchEdit.Text = content;
        }
        public void AssertLinkContent(string content)
        {
            #region Variable Declarations
            HtmlHyperlink uILOLHyperlink = GetHyperLinkWithInnerText(content);
            #endregion

            // Verify that the 'InnerText' property of 'LOL' link equals 'LOL'
            Assert.AreEqual(content, uILOLHyperlink.InnerText);
        }
        public void AssertLong(string content)
        {
            string UIItemCustomInnerText = "Game Reviews!\r\n\r\n  \r\n\r\nYou are searching for zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz" +
         "zzzzzzzzzzzzzz\r\nSearch is limited to 50 characters \r\n\r\nGame Review Tite \r\n\r\nGame" +
         " Name \r\n\r\nRating ";
        }
        public HtmlHyperlink GetHyperLinkWithInnerText(string innerText)
        {
            var mUILOLHyperlink = new HtmlHyperlink();
            #region Search Criteria
            mUILOLHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = innerText;
            #endregion
            return mUILOLHyperlink;
        }

        public void TypeUserName(string userName)
        {
            var uIUsernameEdit = this.UIRegisterGameReviewSiWindow.UIRegisterGameReviewSiDocument.UIUsernameEdit;
            uIUsernameEdit.Text = userName;
        }

        /// <summary>
        /// AssertUserRegisterSuccess - Use 'AssertUserRegisterSuccessExpectedValues' to pass parameters into this method.
        /// </summary>
        /// <param name="expectedUserName"></param>
        public void AssertUserRegisterSuccess(string expectedUserName)
        {
            #region Variable Declarations
            HtmlCustom uILoginCustom = this.UIGameReviewsGameRevieWindow1.UIGameReviewsGameRevieDocument.UILoginCustom;
            #endregion

            // Verify that the 'InnerText' property of 'login' custom control equals 'Hello, replace with dynamic2  Log off  '
            Assert.AreEqual("Hello, " + expectedUserName + "  Log off  ", uILoginCustom.InnerText, "User did not log in");
        }

        public void AssertAuthorNotSearched()
        {

            HtmlDiv uIBodyPane1 = this.UIAuthorsGameReviewSitWindow.UIAuthorsGameReviewSitDocument.UIBodyPane1;
            Assert.IsTrue(!uIBodyPane1.InnerText.Contains("You are searching for"), "Something was searched for.");
        }
    }
}
