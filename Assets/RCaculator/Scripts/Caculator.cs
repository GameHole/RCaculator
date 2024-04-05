using UnityEngine;

namespace RCaculator
{
    public class Caculator : ACaculator
    {
        public override float CaculateNeed(float target, float[] used)
        {
            return getReciprocal(1/target - getUseds(used));
        }

        protected virtual float getUseds(float[] used)
        {
            float c = 0;
            for (int i = 0; i < used.Length; i++)
            {
                c += getReciprocal(used[i]);
            }
            return c;
        }
        protected virtual float getReciprocal(float v)
        {
            if (isZero(v))
                return 0;
            return 1 / v;
        }

        protected virtual bool isZero(float v)
        {
            return v==0;
        }
    }
}