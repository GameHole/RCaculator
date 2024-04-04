using UnityEngine;

namespace RCaculator
{
    public class UIRCaculator:UI
    {
        public FloatText targetTxt { get; } = new FloatText();
        public FloatText[] usedTxts { get; } = new FloatText[4];
        public FloatTextMgr mgr { get; private set; }
        public VKeyBoard keyboard { get; } = new VKeyBoard();

        public override void LoadProperty(Transform transform)
        {
            base.LoadProperty(transform);
            mgr = new FloatTextMgr(keyboard);
            targetTxt.LoadProperty(transform.Find(nameof(targetTxt)));
            mgr.Add(targetTxt);
            for (int i = 0; i < usedTxts.Length; i++)
            {
                var item = new FloatText();
                item.LoadProperty(transform.Find($"usedTxt{i}"));
                mgr.Add(item);
                usedTxts[i] = item;
            }
        }
    }
}
