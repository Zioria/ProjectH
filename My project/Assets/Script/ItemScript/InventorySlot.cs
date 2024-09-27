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
                if (myItem != null)
                {
                    // Swap the items
                    Inventory_Item tempItem = myItem;
                    SetItem(Inventory.carriedItem);  // Place carried item in this slot
                    Inventory.Singleton.SetCarriedItem(tempItem);  // Now carry the item that was in this slot
                }
                else
                {
                    SetItem(Inventory.carriedItem);  // Just place the carried item in this slot
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
