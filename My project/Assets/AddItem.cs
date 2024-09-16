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

       

        public void Additem_New()
        {

            int leftOverItem = inventoryManager.AddItem(itemName, quantity, sprite);
            if (leftOverItem <= 0)
            {
                //do something;
            }
            else
            {
                quantity = leftOverItem;
            }
               

        }
    }
}
