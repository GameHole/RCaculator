using NUnit.Framework;
using RCaculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class TestUICaculator
    {
        [Test]
        public void test()
        {
            var ui = PrefabHelper.New("UIDriver").GetComponent<UIDriver>();
            ui.Start();
            var c = ui.caculator;
            Assert.AreSame(ui.transform, c.transform);
            ui.Start();
            Assert.AreNotSame(c, ui.caculator);
        }
    }
}
