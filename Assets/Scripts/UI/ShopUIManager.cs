using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.Inventory;

namespace BGS.UI
{
    public class ShopUIManager : UIManager
    {
        [SerializeField] private GameObject _uiContainer;
        [Range(1,6)]
        [SerializeField] private int _inventorySize;
        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _inventorySlotPrefab;
        private List<InventorySlot> _currentItemsInShop = new List<InventorySlot>();
        private void PopulateShopItems(List<InventoryItem> items)
        {
            if (items.Count > _inventorySize) { return; }
            foreach (var item in items )
            {
                GameObject go = Instantiate(_inventorySlotPrefab, _inventorySlotParent);
                InventorySlot slot = go.GetComponent<InventorySlot>();
                slot.SetInvetoryItem(item);
                _currentItemsInShop.Add(slot);
            }
        }

        public void OpenShop(List<InventoryItem> items)
        {
            PopulateShopItems(items);
            _uiContainer.SetActive(true);
        }

        public void CloseShop()
        {
            //EmptyShop
            _uiContainer.SetActive(false);
        }
        public void HandlePurchase()
        {
            if (_selectedInventoryItem == null) { return; }

            //money checks

            //on success try to equip

            if (!InventoryManager.Instance.AddItemToInventory(_selectedInventoryItem))
            {
                Debug.Log("Error purchasing");
                return;
            }

            //handle payment
        }

    }
}
//EOF.