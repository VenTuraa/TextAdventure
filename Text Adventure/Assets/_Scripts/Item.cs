using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu(menuName = "ItemObject")]
    public class Item : ScriptableObject
    {
        public string Name;
        public string Description;
        public string UsingResult;
    }
}