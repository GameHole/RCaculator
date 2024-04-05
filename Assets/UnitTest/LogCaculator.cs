using RCaculator;

namespace UnitTest
{
    internal class LogCaculator: Caculator
    {
        public float useds;

        protected override float getUseds(float[] used)
        {
            return useds;
        }
        public float TGetUseds(float[] used)
        {
            return base.getUseds(used);
        }
        public float TgetReciprocal(float v)
        {
            return base.getReciprocal(v);
        }
        public bool TisZero(float v)
        {
            return base.isZero(v);
        }
    }
}