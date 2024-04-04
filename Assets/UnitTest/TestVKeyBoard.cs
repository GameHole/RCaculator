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
        private FloatText text;
        private Transform clone;
        private VKeyBoard ui;

        [SetUp]
        public void set()
        {
            text = new FloatText();
            var tet = new GameObject().AddComponent<Text>();
            text.LoadProperty(tet.transform);
            clone = NewKeyBoard();
            ui = new VKeyBoard();
            ui.LoadProperty(clone);
            ui.text = text;
        }
        private Transform NewKeyBoard()
        {
            return UnityEngine.Object.Instantiate(Resources.Load<Transform>("VKeyBoard"));
        }
        [Test]
        public void TestNew()
        {
            Assert.AreSame(clone, ui.transform);
            Assert.AreEqual("0", text.text);
            ui = new VKeyBoard();
            Assert.AreEqual(typeof(NullText), ui.text.GetType());
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
            for (int i = 0; i < 2; i++)
            {
                ui.backBtn.onClick.Invoke();
                Assert.AreEqual("0", text.text);
            }
        }
        [Test]
        public void testException()
        {
            ui.text = null;
            Assert.AreEqual(typeof(NullText), ui.text.GetType());
            List<Button> buttons = new List<Button>();
            buttons.AddRange(ui.numberBtns);
            buttons.Add(ui.backBtn);
            buttons.Add(ui.dotBtn);
            buttons.Add(ui.clearBtn);
            Assert.DoesNotThrow(() =>
            {
                foreach (var item in buttons)
                {
                    item.onClick.Invoke();
                }
            });
        }
    }
}
