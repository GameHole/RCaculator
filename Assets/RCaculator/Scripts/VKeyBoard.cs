using UnityEngine;
using UnityEngine.UI;

namespace RCaculator
{
    public class VKeyBoard: UI
    {
        private static readonly IText nullText = new NoneText();
        private IText _text = nullText;
        public IText text
        {
            get => _text;
            set
            {
                _text = value == null ? nullText : value;
            }
        }
        public Button[] numberBtns { get; } = new Button[10];

        public Button clearBtn { get;private set; }
        public Button dotBtn { get; private set; }
        public Button backBtn { get; private set; }
        public override void LoadProperty(Transform transform)
        {
            base.LoadProperty(transform);
            clearBtn = transform.GetChildComponent<Button>(nameof(clearBtn));
            clearBtn.onClick.AddListener(() =>
            {
                text.text = "0";
            });
            dotBtn = transform.GetChildComponent<Button>(nameof(dotBtn));
            dotBtn.onClick.AddListener(() =>
            {
                if (!text.text.Contains("."))
                    text.text += ".";
            });
            backBtn = transform.GetChildComponent<Button>(nameof(backBtn));
            backBtn.onClick.AddListener(() =>
            {
                var str = text.text;
                str = str.Remove(str.Length - 1);
                if (string.IsNullOrEmpty(str))
                    str = "0";
                text.text = str;
            });
            for (int i = 0; i < numberBtns.Length; i++)
            {
                var num = i.ToString();
                int index = i;
                var btn = transform.GetChildComponent<Button>(num);
                btn.GetComponentInChildren<Text>().text = num;
                btn.onClick.AddListener(() =>
                {
                    var str = text.text;
                    if (str == "0")
                        str = null;
                    str += index;
                    text.text = str;
                });
                numberBtns[i] = btn;
            }
        }
    }
    public static class TransformEx
    {

        public static T GetChildComponent<T>(this Transform transform, string name)
        {
            return transform.Find(name).GetComponent<T>();
        }
    }
}
