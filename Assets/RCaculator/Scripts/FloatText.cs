using System;
using UnityEngine;
using UnityEngine.UI;

namespace RCaculator
{
    public class FloatText:UI,IText
    {
        public string text { get=>txt.text; set => txt.text=value; }
        public float value
        {
            get
            {
                return float.Parse(text);
            }
        }
        public Text txt { get; private set; }
        public override void LoadProperty(Transform transform)
        {
            base.LoadProperty(transform);
            txt = transform.GetComponent<Text>();
            text = "0";
        }
    }
}
