using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using RCaculator;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace UnitTest
{
    public class TestVKeyBoard
    {
        private IText text;
        private Transform clone;
        private VKeyBoard ui;

        [SetUp]
        public void set()
        {
            var floatTxt= new FloatText();
            floatTxt.LoadProperty(PrefabHelper.New("FloatText"));
            text = floatTxt;
            clone = PrefabHelper.New("VKeyBoard");
            ui = new VKeyBoard();
            ui.LoadProperty(clone);
            ui.text = text;
        }

        [Test]
        public void TestNew()
        {
            Assert.AreSame(clone, ui.transform);
            Assert.AreEqual("0", text.text);
            ui = new VKeyBoard();
            Assert.AreEqual(typeof(NoneText), ui.text.GetType());
        }
        [Test]
        public void testClear()
        {
            text.text = "9";
            Assert.AreEqual("clearBtn", ui.clearBtn.name);
            ui.clearBtn.onClick.Invoke();
            Assert.AreEqual("0",text.text);
        }
        [Test]
        public void testNumber()
        {
            Assert.AreEqual(10,ui.numberBtns.Length);
            for (int i = 0; i < ui.numberBtns.Length; i++)
            {
                var btn = ui.numberBtns[i];
                Assert.AreEqual(i.ToString(), btn.name);
                var numTxt = btn.transform.GetComponentInChildren<Text>().text;
                Assert.AreEqual(i.ToString(), numTxt);
                btn.onClick.Invoke();
            }
            Assert.AreEqual("123456789", text.text);
        }
        [Test]
        public void testNumberZero()
        {
            var zero = ui.numberBtns[0];
            zero.onClick.Invoke();
            Assert.AreEqual("0", text.text);
            ui.numberBtns[1].onClick.Invoke();
            Assert.AreEqual("1", text.text);
            zero.onClick.Invoke();
            Assert.AreEqual("10", text.text);
        }
        [Test]
        public void testDot()
        {
            Assert.AreEqual("dotBtn", ui.dotBtn.name);
            Assert.AreEqual(".", ui.dotBtn.GetComponentInChildren<Text>().text);
            for (int i = 0; i < 2; i++)
            {
                ui.dotBtn.onClick.Invoke();
                Assert.AreEqual("0.", text.text);
            }
            ui.numberBtns[0].onClick.Invoke();
            Assert.AreEqual("0.0", text.text);
            ui.numberBtns[1].onClick.Invoke();
            Assert.AreEqual("0.01", text.text);
            ui.dotBtn.onClick.Invoke();
            Assert.AreEqual("0.01", text.text);
        }
        [Test]
        public void testBack()
        {
            text.text = "1.11";
            ui.backBtn.onClick.Invoke();
            Assert.AreEqual("1.1", text.text);
            ui.backBtn.onClick.Invoke();
            Assert.AreEqual("1.", text.text);
            ui.backBtn.onClick.Invoke();
            Assert.AreEqual("1", text.text);
            for (int i = 0; i < 3; i++)
            {
                ui.backBtn.onClick.Invoke();
                Assert.AreEqual("0", text.text);
            }
        }
        [Test]
        public void testException()
        {
            ui.text = null;
            Assert.AreEqual(typeof(NoneText), ui.text.GetType());
            Assert.DoesNotThrow(ClockAllBtns);
            ui.text = new NoneText();
            Assert.DoesNotThrow(ClockAllBtns);
        }

        private void ClockAllBtns()
        {
            for (int i = 0; i < 10; i++)
            {
                ui.backBtn.onClick.Invoke();
                ui.dotBtn.onClick.Invoke();
                ui.clearBtn.onClick.Invoke();
            }
            foreach (var item in ui.numberBtns)
            {
                item.onClick.Invoke();
            }
        }
    }
}
