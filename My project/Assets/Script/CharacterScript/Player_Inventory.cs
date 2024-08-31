using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH
{
    public class Player_Inventory : MonoBehaviour
    {
        [Header("General")]

        public List<ItemType> inventoryList;
        public int selectedItem;

        
        [Space(20)]
        [Header("Item Gameobject")]
        [SerializeField] GameObject Seed_A_item;
        [SerializeField] GameObject Seed_B_item;

        private Dictionary<ItemType, GameObject> itemSetActive = new Dictionary<ItemType, GameObject>() { };

        void Start()
        {
            itemSetActive.Add(ItemType.Seed, Seed_A_item);
            itemSetActive.Add(ItemType.Seed, Seed_B_item);

            NewItemSelected();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryList.Count > 0)
            {
                selectedItem = 0;
                NewItemSelected();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryList.Count > 0)
            {
                selectedItem = 0;
                NewItemSelected();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryList.Count > 0)
            {
                selectedItem = 0;
                NewItemSelected();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 0)
            {
                selectedItem = 0;
                NewItemSelected();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && inventoryList.Count > 0)
            {
                selectedItem = 0;
                NewItemSelected();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6) && inventoryList.Count > 0)
            {
                selectedItem = 0;
                NewItemSelected();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7) && inventoryList.Count > 0)
            {
                selectedItem = 0;
                NewItemSelected();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8) && inventoryList.Count > 0)
            {
                selectedItem = 0;
                NewItemSelected();
            }
        }

        private void NewItemSelected()
        {
            Seed_A_item.SetActive(false);
            Seed_B_item.SetActive(false);

            GameObject selectedItemGameobject = itemSetActive[inventoryList[selectedItem]];
            selectedItemGameobject.SetActive(false);
        }
    }
}
