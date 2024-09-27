using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectH
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Singleton;
        public static Inventory_Item carriedItem;

        [SerializeField] GameObject inventoryUI;
        public KeyCode openInv;

        [SerializeField] InventorySlot[] inventorySlots;
        [SerializeField] InventorySlot[] hotbarSlots;

        // 0=Head, 1=Chest, 2=Legs, 3=Feet
        [SerializeField] InventorySlot[] equipmentSlots;

        [SerializeField] Transform draggablesTransform;
        [SerializeField] Inventory_Item itemPrefab;

        [Header("Item List")]
        [SerializeField] Item[] items;

        [Header("Debug")]
        [SerializeField] Button giveItemBtn;

        void Awake()
        {
            Singleton = this;
            giveItemBtn.onClick.AddListener(delegate { SpawnInventoryItem(); });
        }

        void Start()
        {
            inventoryUI.SetActive(false);       
        }

        void Update()
        {
            if (Input.GetKeyDown(openInv))
            {
                ToggleInventory();
            }

            if (carriedItem == null) return;

            carriedItem.transform.position = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                // Check if the item was dropped over a valid slot, otherwise return to original slot
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    // No valid slot, return item to original slot
                    carriedItem.activeSlot.SetItem(carriedItem);
                }
            }
            

        }

        public void ToggleInventory()
        {
           
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Time.timeScale = inventoryUI.activeSelf ? 0f : 1f; // Pause game when inventory is open
        }

        public void SetCarriedItem(Inventory_Item item)
        {
            if (carriedItem != null)
            {
                if (item.activeSlot.myTag != SlotTag.None && item.activeSlot.myTag != carriedItem.myItem.itemTag) return;
                item.activeSlot.SetItem(carriedItem);
            }

            if (item.activeSlot.myTag != SlotTag.None)
            { EquipEquipment(item.activeSlot.myTag, null); }

            carriedItem = item;
            carriedItem.canvasGroup.blocksRaycasts = false;
            item.transform.SetParent(draggablesTransform);
        }

        public void EquipEquipment(SlotTag tag, Inventory_Item item = null)
        {
            switch (tag)
            {
                case SlotTag.Head:
                    if (item == null)
                    {
                        // Destroy item.equipmentPrefab on the Player Object;
                        Debug.Log("Unequipped helmet on " + tag);
                    }
                    else
                    {
                        // Instantiate item.equipmentPrefab on the Player Object;
                        Debug.Log("Equipped " + item.myItem.name + " on " + tag);
                    }
                    break;
                case SlotTag.Chest:
                    break;
                case SlotTag.Legs:
                    break;
                case SlotTag.Feet:
                    break;
            }
        }

         public void SpawnInventoryItem(Item item = null, int quantity = 1)
         {
             Item _item = item;
             if (_item == null)
             { 
                _item = PickRandomItem();
             }

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].myItem != null && inventorySlots[i].myItem.myItem == _item && _item.isStackable)
                {
                inventorySlots[i].myItem.AddQuantity(1);
                return;
                }
            }

        // If no existing stack, create a new slot
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].myItem == null)
                {
                Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
                break;
                }
            }
         }

        Item PickRandomItem()
        {
            int random = Random.Range(0, items.Length);
            return items[random];
        }
    }
}
