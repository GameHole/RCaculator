using NUnit.Framework;
using RCaculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class TestCaculator
    {
        private Caculator caculator;
        private float[] needs;
        private LogCaculator log;

        [SetUp]
        public void set()
        {
            caculator = new Caculator();
            needs = new float[4];
            log = new LogCaculator();
        }
        [Test]
        public void testDefault()
        {
            Assert.AreEqual(0,caculator.CaculateNeed(0, needs));
        }
        [Test]
        public void testTarget()
        {
            Assert.AreEqual(1, caculator.CaculateNeed(1, needs));
        }
        [Test]
        public void testTargetNeeds()
        {
            needs[0] = 1;
            Assert.AreEqual(0, caculator.CaculateNeed(1, needs));
            for (int i = 0; i < 4; i++)
            {
                needs = new float[4];
                needs[i] = 1;
                Assert.AreEqual(0, caculator.CaculateNeed(1, needs));
            }
        }
        [Test]
        public void testOneNeed()
        {
            needs[0] = 2;
            Assert.AreEqual(2, caculator.CaculateNeed(1, needs));
            for (int i = 0; i < 4; i++)
            {
                needs = new float[4];
                needs[i] = 2;
                Assert.AreEqual(2, caculator.CaculateNeed(1, needs));
            }
        }
        [Test]
        public void testNeeds()
        {
            for (int i = 0; i < 3; i++)
            {
                needs[i] = 3;
            }
            Assert.AreEqual(0, caculator.CaculateNeed(1, needs));
        }
        [Test]
        public void testInvailed()
        {
            needs[0] = 2;
            needs[1] = 1.5f;
            Assert.AreEqual(-6f, caculator.CaculateNeed(1, needs),1e-5);
        }
        [Test]
        public void testFunc()
        {
            Assert.AreEqual(12, caculator.CaculateNeed(4f, new float[] { 6 }), 1e-4);
            Assert.AreEqual(-24f, caculator.CaculateNeed(4f, new float[] { 6, 8 }), 1e-4);
            Assert.AreEqual(60, caculator.CaculateNeed(4f, new float[] { 6, 15 }), 1e-4);
            //Assert.AreEqual(0, caculator.CaculateNeed(1.1f, new float[] { 2.1f,2.31f }), 1e-4);
        }
        [Test]
        public void testFloat()
        {
            Assert.IsTrue(float.IsInfinity(1f / 0));
            Assert.AreEqual(0,1 / (1f / 0));
        }
        [Test]
        public void testGetNeeds()
        {
            log.useds = 1;
            Assert.AreEqual(0, log.CaculateNeed(1, needs));
            Assert.AreEqual(-2, log.CaculateNeed(2, needs));
            Assert.AreEqual(0, log.TGetUseds(needs));
            for (int i = 1; i <= 4; i++)
            {
                needs = new float[4];
                for (int j = 0; j < i; j++)
                {
                    needs[j] = 2;
                }
                Assert.AreEqual(i * 0.5f, log.TGetUseds(needs));
            }
        }
        [Test]
        public void testIsZero()
        {
            Assert.IsTrue(log.TisZero(0));
            Assert.IsFalse(log.TisZero(0.00009f));
        }
    }
}
