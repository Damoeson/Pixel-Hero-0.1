using UnityEngine;

namespace Damoeson
{
    [CreateAssetMenu(fileName = "newItemData", menuName = "Data/Item Data/Basic Item Data", order = 0)]

    public class ItemData : ScriptableObject
    {
        public string Name;

        public Sprite Icon;

        public int Value;

        public string Use;

        public string Description;

        public AudioClip CollectedSound;
    }
}
