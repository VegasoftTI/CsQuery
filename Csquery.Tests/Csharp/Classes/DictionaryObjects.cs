﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Description = NUnit.Framework.DescriptionAttribute;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
using CsQuery;
using CsQuery.Utility;
using CsQuery.EquationParser;


namespace CsqueryTests.Csharp
{

    [TestFixture, TestClass, Description("Special purpose dictionaries")]
    public class DictionaryObjects_ : CsQueryTest
    {
     

        [TestFixtureSetUp,ClassInitialize]
        public static void Setup(TestContext context) {

        }
        [Test,TestMethod]
        public void SmallDictionary()
        {
            IDictionary<string, int> dict = new SmallDictionary<string, int>();
            DoTests(dict);
        }

        [Test,TestMethod]
        public void OrderedDictionary()
        {
            OrderedDictionary<string, int> dict = new OrderedDictionary<string, int>();
            DoTests(dict);
            Assert.AreEqual(3, dict. Count, "Has 3 records left");
            Assert.AreEqual(2, dict.IndexOf("test4"), "IndexOf works");
            Assert.AreEqual(dict[1], 30, "Access by numeric index appears to work");
            Assert.AreEqual(dict.Values[1], 30, "Access to values by index is good");
            Assert.AreEqual(dict.Keys[1], "test3", "Access to values by index is good");

            Assert.Throws<NotSupportedException>(Del(()=>{dict.Values[1]=333;}),"Can't set value when accessing it from the Values list");

            dict.Insert(0, 100);

            // indicies should have moved
            Assert.AreEqual(4, dict.Count, "Has 3 records left");
            Assert.AreEqual(3, dict.IndexOf("test4"), "IndexOf works");
            Assert.AreEqual(dict[2], 30, "Access by numeric index appears to work");
            Assert.AreEqual(dict[0], 100);
            // check for autocreated key
            Assert.AreEqual(dict.Keys[0],"0", "Autogenerated a key.");
            dict.Insert(0, 100);
            Assert.AreEqual(dict.Keys[0], "1", "Autogenerated another key.");

        }
        protected void DoTests(IDictionary<string,int> dict)
        {
            dict.Add("test1", 10);
            dict.Add("test2", 20);
            dict.Add("test3",30);
            dict.Add("test4", 40);

            Assert.AreEqual(4, dict.Count, "Correct # of elements");
            Assert.IsTrue(dict.ContainsKey("test2"), "Contains");
            Assert.IsFalse(dict.ContainsKey("xxx"), "!Contains");

            Assert.AreEqual(20, dict["test2"], "Got a value");
            dict["test2"] = 45;
            Assert.AreEqual(45, dict["test2"], "Updated a value");
            Assert.AreEqual(4, dict.Count, "Correct # of elements still");

            dict.Remove("test2");
            Assert.AreEqual(3, dict.Count, "Correct # of elements still");
            Assert.IsFalse(dict.ContainsKey("test2"), "Contains");

            Assert.AreEqual(dict["test3"], 30, "Access by indexer: key works");

        }

        
    }
}