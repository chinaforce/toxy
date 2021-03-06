﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toxy.Test
{
     [TestClass]
    public class CsvParserTest
    {
         [TestMethod]
         public void TestParseToxySpreadsheet()
         {
             string path = TestDataSample.GetFilePath("countrylist.csv");

            ParserContext context=new ParserContext(path);
            context.Properties.Add("HasHeader", "1");
            ISpreadsheetParser parser = (ISpreadsheetParser)ParserFactory.CreateSpreadsheet(path);
            ToxySpreadsheet ss= parser.Parse(context);
            Assert.AreEqual(1, ss.Tables.Count);
            Assert.AreEqual(14, ss.Tables[0].ColumnHeaders.Count);
            Assert.AreEqual("Sort Order", ss.Tables[0].ColumnHeaders[0]);
            Assert.AreEqual("Sub Type", ss.Tables[0].ColumnHeaders[4]);
            Assert.AreEqual(272, ss.Tables[0].Rows.Count);
            Assert.AreEqual("Kingdom of Bahrain", ss.Tables[0].Rows[12].Cells[2]);
            Assert.AreEqual(".bo", ss.Tables[0].Rows[20].Cells[13]);
         }
    }
}

