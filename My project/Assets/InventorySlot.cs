using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectH
{
    public enum SlotTag { None, Head, Chest, Legs, Feet }

    public class InventorySlot : MonoBehaviour, IPointerClickHandler
    {
        public Inventory_Item myItem { get; set; }

        public SlotTag myTag;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                // Check if there's no carried item
                if (Inventory.carriedItem == null) return;

                // Check if the slot type matches
                if (myTag != SlotTag.None && Inventory.carriedItem.myItem.itemTag != myTag) return;

                // Check if the item in this slot is the same and stackable
                if (myItem != null && myItem.myItem == Inventory.carriedItem.myItem && myItem.myItem.isStackable)
                {
                    int totalQuantity = myItem.Quantity + Inventory.carriedItem.Quantity;

                    // If the total quantity is less than or equal to the max stack size, stack the items
                    if (totalQuantity <= myItem.myItem.maxStackSize)
                    {
                        myItem.AddQuantity(Inventory.carriedItem.Quantity);
                        Destroy(Inventory.carriedItem.gameObject); // Destroy the carried item
                        Inventory.carriedItem = null; // Reset carried item
                    }
                    else
                    {
                        // Otherwise, fill up the stack and leave the remainder
                        int remainingQuantity = totalQuantity - myItem.myItem.maxStackSize;
                        myItem.AddQuantity(myItem.myItem.maxStackSize - myItem.Quantity);
                        Inventory.carriedItem.Quantity = remainingQuantity;
                    }
                }
                else
                {
                    // Otherwise, set the item in the slot
                    SetItem(Inventory.carriedItem);
                }
            }
        }

        public void SetItem(Inventory_Item item)
        {
            Inventory.carriedItem = null;

            // Reset old slot
            item.activeSlot.myItem = null;

            // Set current slot
            myItem = item;
            myItem.activeSlot = this;
            myItem.transform.SetParent(transform);
            myItem.canvasGroup.blocksRaycasts = true;

            if (myTag != SlotTag.None)
            { Inventory.Singleton.EquipEquipment(myTag, myItem); }
        }
      }

    }
