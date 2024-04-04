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
        [Test]
        public void test()
        {
            var tet = new GameObject().AddComponent<Text>();
            var text = new FloatText();
            text.LoadProperty(tet.transform);
            Assert.AreSame(tet.transform, text.transform);
            Assert.AreSame(tet, text.txt);
            Assert.AreEqual(0, text.value);
            Assert.AreEqual("0", text.text);
            for (int i = 0; i < 10; i++)
            {
                text.text = i.ToString();
                Assert.AreEqual(i.ToString(), tet.text);
                Assert.AreEqual(i, text.value);
            }
        }
    }
}
