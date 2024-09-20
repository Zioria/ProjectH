using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace ProjectH
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        //===ITEM DATA===//
        public string itemName;
        public int quantity;
        public Sprite itemSprite;
        public bool isFull;
        public Sprite emptySprite;

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
            if (thisItemSelected)
            {
                bool usable = inventoryManager.UseItem(itemName);
                if (usable)
                {


                    this.quantity -= 1;
                    quantityText.text = this.quantity.ToString();

                    if (this.quantity <= 0)
                    {
                        EmtySlot();
                    }
                }
            }
            else
            {


                inventoryManager.DeselectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;
            }
        }

        private void EmtySlot()
        {
            quantityText.enabled = false;
            itemImage.sprite = emptySprite;
        }

        public void OnRightClick()
        {

        }
    }
}
