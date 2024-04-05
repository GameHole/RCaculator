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
            Assert.AreEqual("0", ui.resultTxt.text);
            Assert.AreEqual("targetTxt", ui.targetTxt.transform.name);
            Assert.AreEqual(5, ui.mgr.Count);
            for (int i = 0; i < ui.usedTxts.Length; i++)
            {
                Assert.AreEqual($"usedTxt{i}", ui.usedTxts[i].transform.name);
                Assert.AreSame(ui.usedTxts[i],ui.mgr[i+1]);
            }
            Assert.AreSame(ui.keyboard, ui.mgr.keyboard);
            Assert.AreSame(ui.targetTxt, ui.mgr[0]);
            Assert.AreEqual("keyboard", ui.keyboard.transform.name);
            Assert.AreEqual(0, ui.mgr.selectIndex);
        }
        [Test]
        public void tesCaculate()
        {
            Assert.AreEqual("caculateBtn", ui.caculateBtn.name);
            Assert.AreEqual(typeof(Caculator), ui.caculator.GetType());
            var test = new TCaculator();
            ui.caculator = test;
            ui.targetTxt.text = "10";
            for (int i = 0; i < ui.usedTxts.Length; i++)
            {
                ui.usedTxts[i].text = (i + 1).ToString();
            }
            ui.caculateBtn.onClick.Invoke();
            Assert.AreEqual("1.234", ui.resultTxt.text);
            Assert.AreEqual(10,test.target);
            Assert.AreEqual(4, test.used.Length);
            for (int i = 0; i < test.used.Length; i++)
            {
                Assert.AreEqual(i+1, test.used[i]);
            }
        }
        [Test]
        public void testReset()
        {
            for (int i = 0; i < ui.mgr.Count; i++)
            {
                ui.mgr[i].text = "1";
            }
            ui.resultTxt.text = "999";
            ui.resetBtn.onClick.Invoke();
            for (int i = 0; i < ui.mgr.Count; i++)
            {
                Assert.AreEqual("0", ui.mgr[i].text);
            }
            ui.resultTxt.text = "0";
        }
    }
}
