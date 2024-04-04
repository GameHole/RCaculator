using NUnit.Framework;
using RCaculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UnitTest
{
    class TestFloatText
    {
        private Transform clone;
        private FloatText ui;

        [SetUp]
        public void set()
        {
            ui = NewText();
        }

        private FloatText NewText()
        {
            clone = PrefabHelper.New("FloatText");
            ui = new FloatText();
            ui.LoadProperty(clone);
            return ui;
        }

        [Test]
        public void testText()
        {
            ui.LoadProperty(clone.transform);
            Assert.AreSame(clone.transform, ui.transform);
            Assert.AreEqual("txt", ui.txt.name);
            Assert.AreEqual(0, ui.value);
            Assert.AreEqual("0", ui.text);
            for (int i = 0; i < 10; i++)
            {
                ui.text = i.ToString();
                Assert.AreEqual(i.ToString(), ui.txt.text);
                Assert.AreEqual(i, ui.value);
            }
        }
        [Test]
        public void testClick()
        {
            Assert.AreEqual("btn", ui.btn.name);
            Assert.IsFalse(ui.tip.activeSelf);
        }
        [Test]
        public void testMgr()
        {
            var key = new VKeyBoard();
            var mgr = new FloatTextMgr(key);
            Assert.AreSame(key, mgr.keyboard);
            var texts = new FloatText[2];
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = NewText();
                mgr.Add(texts[i]);
            }
            Assert.AreEqual(2, mgr.Count);
            for (int i = 0; i < texts.Length; i++)
            {
                Assert.AreSame(texts[i], mgr[i]);
            }
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].btn.onClick.Invoke();
                for (int j = 0; j < texts.Length; j++)
                {
                    Assert.AreEqual(i == j, texts[j].tip.activeSelf);
                }
                Assert.AreSame(texts[i], key.text);
            }
        }
    }
}
