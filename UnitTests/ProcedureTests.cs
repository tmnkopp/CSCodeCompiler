using System;
using System.Collections.Generic;
using CSCodeCompiler.Data;
using CSCodeCompiler.Procedures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ProcedureTests
    {
        [TestMethod]
        public void ContextExtractReturnsExpectedResult()
        {
            string parseme = "1-2-3-4-5-6-7-8-9-01-2-3-4-5-6-7-8-9-0";
            ContextExtract extract = new ContextExtract("4-5-6",2,2);
            string expected = "3-4-5-6-7\n3-4-5-6-7\n";
            string actual = extract.Execute(parseme);
            Assert.AreEqual(expected, actual); 
        }
        [TestMethod]
        public void KeyValDBReaderNotNull()
        {
            SqlKeyValCompile KVCompile = new SqlKeyValCompile("[dir]data.sql");
            //Dictionary<string, string> dict = KVCompile.Data;
            string actual = KVCompile.Execute("[HW]");
            string expected = "HELLO WORLD";
            Assert.AreEqual(expected, actual);
        } 
    }
}
