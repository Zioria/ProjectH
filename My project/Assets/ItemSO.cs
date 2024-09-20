using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectH
{
    [CreateAssetMenu]
    public class ItemSO : ScriptableObject
    {
        public string itemname;
        public StatToChange statToChange = new StatToChange();
        public int amountToChangeStat;

        public AttributeToChange attributeToChange = new AttributeToChange();
        public int amountToChangeAttribute;

        public bool UseItem()
        {
            if (statToChange == StatToChange.Farm)
            {
                Debug.Log("Seed is plant");
            }
            return false;
        }


        public enum StatToChange
        {
            none,
            Farm,
            Tool,
            Charm,

        };

        public enum AttributeToChange
        {
            none,
            Normal,
            Rare,

        }
    }
}
