using UnityEngine;

namespace UnitTest
{
    class PrefabHelper
    {
        public static Transform New(string path)
        {
            return Object.Instantiate(Resources.Load<Transform>(path));
        }
    }
}
