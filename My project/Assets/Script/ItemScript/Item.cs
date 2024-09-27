using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    [CreateAssetMenu(menuName = "Scripttabla Object/ITEM")]
    public class Item : ScriptableObject
    {
        public Sprite sprite;
        public SlotTag itemTag;

        public bool isStackable;
        public int maxStackSize;

        [Header("equipment")]
        public GameObject equipmentITEM;
    }
}
