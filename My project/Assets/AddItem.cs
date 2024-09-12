using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    public class AddItem : MonoBehaviour
    {
        public Inventory_Player inventory; 
        [SerializeField] GameObject Seeds;

        [SerializeField]
        private string itemName;

        [SerializeField]
        private int quantity;

        [SerializeField]
        private Sprite sprite;

        private InventoryManager inventoryManager;

        public void Start()
        {
                inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

        }

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

        public void Additem_New()
        {

            inventoryManager.AddItem(itemName, quantity, sprite);

        }
    }
}
