using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace ProjectH
{
    public class Inventory_Item : MonoBehaviour, IPointerClickHandler
    {
        

        Image itemIcon;
        public CanvasGroup canvasGroup { get; private set; }

        public Item myItem { get; set; }
        public int Quantity { get;  set; } = 1; // Default quantity is 1
        public InventorySlot activeSlot { get; set; }

        public TextMeshProUGUI quantityText;


        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            itemIcon = GetComponent<Image>();
            quantityText = GetComponentInChildren<TextMeshProUGUI>();

            // Set the quantity display to be hidden by default
            if (quantityText != null)
            {
                quantityText.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on Inventory_Item!");
            }


        }

        public void Initialize(Item item, InventorySlot parent, int quantity = 1)
        {
            activeSlot = parent;
            activeSlot.myItem = this;
            myItem = item;
            itemIcon.sprite = item.sprite;
            Quantity = quantity;
            UpdateUI();
        }

        public void AddQuantity(int amount)
        {
            Quantity += amount;
            UpdateUI();
        }

        public void RemoveQuantity(int amount)
        {
            Quantity -= amount;
            if (Quantity <= 0)
            {
                Destroy(gameObject); // Remove the item if quantity reaches 0
            }
            UpdateUI();
        }

        void UpdateUI()
        {
            if (quantityText != null)
            {
                if (Quantity > 1) // Show quantity only if more than 1
                {
                    quantityText.text = Quantity.ToString();
                    quantityText.gameObject.SetActive(true); // Show the text
                }
                else
                {
                    quantityText.gameObject.SetActive(false); // Hide if only 1 item
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Inventory.Singleton.SetCarriedItem(this);  // Regular left-click logic
            }
            else if (eventData.button == PointerEventData.InputButton.Right && Quantity > 1 && myItem.isStackable)
            {
                SplitItem();  // Right-click splits the item
            }
        }

        private void SplitItem()
        {
            int splitAmount = Quantity / 2;  // Split half of the stack
            if (splitAmount > 0)
            {
                RemoveQuantity(splitAmount);  // Reduce the quantity of the current item

                // Create a new item with the split amount
                Inventory.Singleton.SpawnInventoryItem(myItem, splitAmount);
            }
        }
    }
}
