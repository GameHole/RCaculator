using RCaculator;
using System.Collections.Generic;

namespace UnitTest
{
    internal class TCaculator: ACaculator
    {
        internal float target;
        internal float[] used;
        public float output = 1.23356f;

        public override float CaculateNeed(float target, float[] used)
        {
            this.target = target;
            this.used = used;
            return output;
        }
    }
}