﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalcLibrary;

namespace MyCalcTest
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "dataAdd.csv", "dataAdd#csv",
         DataAccessMethod.Sequential), 
         DeploymentItem("dataAdd.csv"), TestMethod]
        public void Add_xy_ReturnResultZ()
        {
            var calc = new MyCalcClass();
            int x = Int32.Parse(this.TestContext.DataRow[0].ToString());
            int y = Int32.Parse(this.TestContext.DataRow[1].ToString());
            int z = Int32.Parse(this.TestContext.DataRow[2].ToString());
            Assert.AreEqual(z, calc.Add(x,y));
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "dataSub.csv", "dataSub#csv",
       DataAccessMethod.Sequential),
       DeploymentItem("dataSub.csv"), TestMethod]
        public void Sub_xy_ReturnResultZ()
        {
            var calc = new MyCalcClass();
            int x = Int32.Parse(this.TestContext.DataRow[0].ToString());
            int y = Int32.Parse(this.TestContext.DataRow[1].ToString());
            int z = Int32.Parse(this.TestContext.DataRow[2].ToString());
            Assert.AreEqual(z, calc.Substract(x, y));
        }


    }
}
