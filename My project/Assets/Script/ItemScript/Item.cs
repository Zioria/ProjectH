using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectH
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable objects/Item")]
    public class Item : ScriptableObject
    {
        [Header("Properties")]
        public ItemType item_type;
        public Sprite item_sprite;
        public int pricc;
        
 
    }

    public enum ItemType { Seed, Tool };
}
