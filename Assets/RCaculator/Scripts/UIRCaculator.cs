using UnityEngine;
using UnityEngine.UI;

namespace RCaculator
{
    public class UIRCaculator:UI
    {
        public FloatText targetTxt { get; } = new FloatText();
        public FloatText[] usedTxts { get; } = new FloatText[4];
        public FloatTextMgr mgr { get; private set; }
        public VKeyBoard keyboard { get; } = new VKeyBoard();
        public Button caculateBtn { get;private set; }
        public ACaculator caculator { get; set; } = new Caculator();
        public Text resultTxt { get; private set; }

        public override void LoadProperty(Transform transform)
        {
            base.LoadProperty(transform);
            keyboard.LoadProperty(transform.Find(nameof(keyboard)));
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
            caculateBtn = transform.GetChildComponent<Button>(nameof(caculateBtn));
            caculateBtn.onClick.AddListener(() =>
            {
                resultTxt.text = caculator.CaculateNeed(targetTxt.value, getFloats()).ToString("F3");
            });
            resultTxt = transform.GetChildComponent<Text>(nameof(resultTxt));
        }

        private float[] getFloats()
        {
            var array = new float[usedTxts.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = usedTxts[i].value;
            }
            return array;
        }
    }
}
