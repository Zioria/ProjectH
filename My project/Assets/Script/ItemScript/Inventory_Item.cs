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
                // Regular left-click logic to carry the entire item
                Inventory.Singleton.SetCarriedItem(this);
            }
            else if (eventData.button == PointerEventData.InputButton.Right && Quantity > 1 && myItem.isStackable)
            {
                // Pick exactly 1 item from the stack
                PickOneItem();
                Debug.Log("isClick");
                Debug.Log(Quantity);
            }
        }

        private void PickOneItem()
        {
            RemoveQuantity(1);
            Inventory.Singleton.SpawnInventoryItem(myItem, 1);
        }

        public void RemoveQuantity(int amount)
        {
            Quantity -= amount;
            if (Quantity <= 0)
            {
                Destroy(gameObject); // Remove the item if quantity reaches 0
            }
            UpdateUI();
            Debug.Log("remove");
        }
    }
}
