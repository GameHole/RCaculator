using UnityEngine;
namespace RCaculator
{
    public class UIDriver : MonoBehaviour
    {
        public UIRCaculator caculator { get;private set; }

        public void Start()
        {
            caculator = new UIRCaculator();
            caculator.LoadProperty(transform);
        }
    }
}
