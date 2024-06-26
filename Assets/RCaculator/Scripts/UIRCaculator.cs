﻿using UnityEngine;
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
        public Button resetBtn { get; private set; }

        public override void LoadProperty(Transform transform)
        {
            base.LoadProperty(transform);
            keyboard.LoadProperty(transform.Find(nameof(keyboard)));
            mgr = new FloatTextMgr(keyboard);
            var parent = transform.Find("texts");
            targetTxt.LoadProperty(parent.Find(nameof(targetTxt)));
            mgr.Add(targetTxt);
            for (int i = 0; i < usedTxts.Length; i++)
            {
                var item = new FloatText();
                item.LoadProperty(parent.Find($"usedTxt{i}"));
                mgr.Add(item);
                usedTxts[i] = item;
            }
            caculateBtn = transform.GetChildComponent<Button>(nameof(caculateBtn));
            caculateBtn.onClick.AddListener(() =>
            {
                float result = caculator.CaculateNeed(targetTxt.value, getFloats());
                if (result >= 0)
                    resultTxt.text = result.ToString("F3");
                else
                    resultTxt.text = "不存在";
            });
            resultTxt = transform.GetChildComponent<Text>(nameof(resultTxt));
            reset();
            mgr.Select(0);
            resetBtn = transform.GetChildComponent<Button>(nameof(resetBtn));
            resetBtn.onClick.AddListener(() =>
            {
                for (int i = 0; i < mgr.Count; i++)
                {
                    mgr[i].Reset();
                }
                reset();
            });
        }

        private void reset()
        {
            resultTxt.text = "0";
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
