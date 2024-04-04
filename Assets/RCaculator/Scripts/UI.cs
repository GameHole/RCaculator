using UnityEngine;

namespace RCaculator
{
    public class UI
    {
        public Transform transform { get; private set; }
        public virtual void LoadProperty(Transform transform)
        {
            this.transform = transform;
        }
    }
}
