using System;
using System.Collections.Generic;
using CSCodeCompiler.Data;
using CSCodeCompiler.Procedures;
using CSCodeCompiler.Extentions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ExtentionTests
    {
        [TestMethod]
        public void EXT_NoBreaksOrSpacesInString()
        {
            string s = "    1-2-  \n\r  \r\r \n\n      3 -4  \r \n\n -5   "; 
            string expected = "1-2-3-4-5";
            string actual = s.RemoveWhiteAndBreaks();
            Assert.AreEqual(expected, actual); 
        }
  
    }
}
