using NUnit.Framework;
using RCaculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class TestRCaculator
    {
        private UIRCaculator ui;

        [SetUp]
        public void set()
        {
            var clone = PrefabHelper.New("RCaculator");
            ui = new UIRCaculator();
            ui.LoadProperty(clone);
        }
        [Test]
        public void testTexts()
        {
            Assert.AreEqual("targetTxt", ui.targetTxt.transform.name);
            Assert.AreEqual(5, ui.mgr.Count);
            for (int i = 0; i < ui.usedTxts.Length; i++)
            {
                Assert.AreEqual($"usedTxt{i}", ui.usedTxts[i].transform.name);
                Assert.AreSame(ui.usedTxts[i],ui.mgr[i+1]);
            }
            Assert.AreSame(ui.keyboard, ui.mgr.keyboard);
            Assert.AreSame(ui.targetTxt, ui.mgr[0]);
        }
        [Test]
        public void tesCaculate()
        {
            Assert.AreEqual("caculateBtn", ui.caculateBtn.name);
            Assert.DoesNotThrow(ui.caculateBtn.onClick.Invoke);
        }
    }
}
