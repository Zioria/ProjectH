using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    public class AddItem : MonoBehaviour
    {
        public Inventory_Player inventory; 
        [SerializeField] GameObject Seeds;
        

       

        public void Additem()
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Instantiate(Seeds, inventory.slots[i].transform, false);
                    inventory.isFull[i] = true;
                    break;
                }
            }
        }
    }
}
