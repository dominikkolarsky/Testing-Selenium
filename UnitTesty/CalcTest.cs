
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestedClasses3;

namespace UnitTesty {
    [TestClass]
    public class CalcTest {
        Calculator calc;
        [TestInitialize]
        public void Init() {
            calc = new Calculator();
        }
        [TestMethod]
        public void Add2and3is5() {
            int actual = calc.Add(2,3);
            Assert.AreEqual(5, actual);
        }
        [TestMethod]
        public void AddMinus2andMinus3isMinus1() {
            int actual = calc.Add(-3,2);
            Assert.AreEqual(-1, actual);
        }
        [TestMethod]
        public void Divide5and0isDicideByZeroException() {
            Assert.ThrowsException<DivideByZeroException>(()=>calc.Divide(5,0));
        }
    }
}