using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ProjectH
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        //===ITEM DATA===//
        public string itemName;
        public int quantity;
        public Sprite itemSprite;
        public bool isFull;

        [SerializeField]
        private int maxNumberOfItem;


        //===ITEM SLOT===//
        [SerializeField]
        private TMP_Text quantityText;

        [SerializeField]
        private Image itemImage;

        public GameObject selectedShader;
        public bool thisItemSelected;

        private InventoryManager inventoryManager;

        private void Start()
        {
            inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        }

        public int AddItem(string itemName, int quantity, Sprite itemSprite)
        {
            //Check itemslot is full
            if (isFull)
                return quantity;

            this.itemName = itemName;

            this.itemSprite = itemSprite;
            itemImage.sprite = itemSprite;

            this.quantity += quantity;
            
            if (this.quantity >= maxNumberOfItem)
            {

                quantityText.text = maxNumberOfItem.ToString();
                quantityText.enabled = true;
                isFull = true;

                int extraItem = this.quantity - maxNumberOfItem;
                this.quantity = maxNumberOfItem;
                return extraItem;

            }

            //Update quantity text
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;

            return 0;


        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                OnLeftClick();
            }
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnRightClick();
            }
        }

        public void OnLeftClick()
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }

        public void OnRightClick()
        {

        }
    }
}
