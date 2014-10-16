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
            HtmlHyperlink uILOLHyperlink = this.UIGameReviewsGameRevieWindow1.UIGameReviewsGameRevieDocument.UIBodyPane.UILOLHyperlink;
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
    }
}
