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
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
