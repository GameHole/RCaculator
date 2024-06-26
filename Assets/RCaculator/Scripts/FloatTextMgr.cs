﻿using System;
using System.Collections.Generic;

namespace RCaculator
{
    public class FloatTextMgr
    {
        List<FloatText> texts = new List<FloatText>();
        public int Count => texts.Count;
        public FloatText this[int index]=>texts[index];

        public VKeyBoard keyboard { get;private set; }
        public int selectIndex { get; private set; } = -1;

        public FloatTextMgr(VKeyBoard key)
        {
            this.keyboard = key;
        }
        public void Add(FloatText floatText)
        {
            int index = texts.Count;
            floatText.btn.onClick.AddListener(() =>
            {
                Select(index);
            });
            texts.Add(floatText);
        }
        public void Select(int index)
        {
            selectIndex = index;
            for (int i = 0; i < texts.Count; i++)
            {
                bool isActive = i == index;
                var item = texts[i];
                if (isActive)
                    keyboard.text = item;
                item.tip.SetActive(isActive);
            }
        }
    }
}
