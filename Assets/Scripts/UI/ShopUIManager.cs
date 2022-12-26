using System.Collections.Generic;
using UnityEngine;
using BGS.Inventory;
using BGS.Character;
using BGS.Core;

namespace BGS.UI
{
    public class ShopUIManager : UIManager
    {
        [SerializeField] private GameObject _uiContainer;
        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _inventorySlotPrefab;

        private List<InventorySlot> _currentItemsInShop = new List<InventorySlot>();
        private Shopper _shopper;
        private CurrencyController _player;
        private int _inventorySize;

        private void PopulateShopItems(List<InventoryItem> items)
        {
            if (items.Count > _inventorySize) { return; }
            foreach (var item in items )
            {
                GameObject go = Instantiate(_inventorySlotPrefab, _inventorySlotParent);
                InventorySlot slot = go.GetComponent<InventorySlot>();
                slot.SetInvetoryItem(item);
                slot.SetUIManager(this);
                _currentItemsInShop.Add(slot);
            }
        }

        private void UnpopulateShopItems()
        {
            foreach (Transform child in _inventorySlotParent)
            {
                Destroy(child.gameObject);
            }
        }

        public void UpdateShopItems(List<InventoryItem> items)
        {
            UnpopulateShopItems();
            PopulateShopItems(items);
        }
        public void OpenShop(List<InventoryItem> items, int inventorySize)
        {
            _inventorySize = inventorySize;
            PopulateShopItems(items);
            _uiContainer.SetActive(true);
            _shopper = FindObjectOfType<Shopper>();
            _player = FindObjectOfType<PlayerController>().GetComponent<CurrencyController>();
        }

        public void CloseShop()
        {
            UnpopulateShopItems();
            _uiContainer.SetActive(false);
            _currentItemsInShop.Clear();
            _shopper.ShopClosed();
        }
        public void HandlePurchase()
        {
            if (_selectedInventoryItem == null) { return; }

            
            if (!_player.CanAffordCost(_selectedInventoryItem.Value)) 
            {
                Debug.Log("Can't afford");
                return;
            }
            //On success try to equip
            if (!InventoryManager.Instance.AddItemToInventory(_selectedInventoryItem))
            {
                Debug.Log("Error purchasing");
                return;
            }
            //handle payment
            _player.SubstractFromFunds(_selectedInventoryItem.Value);
            //remove from shop
            RemoveFromShopInventory(_selectedInventoryItem);
            _shopper.OnItemSold(_selectedInventoryItem);
            UnSelectInventoryItem();
        }

        public void HandleSale()
        {
            var item = InventoryManager.Instance.GetSelectedItemInInventory();
            var slot = InventoryManager.Instance.GetSelectedSlotInInventory();

            if ( item == null)
            {
                Debug.Log("No object selected in inventory");
                return;
            }
            if (!_shopper.OnItemBought(item))
            {
                Debug.Log("Shopper could not buy");
            }
            InventoryManager.Instance.RemoveItemFromInventory(slot);
            _player.AddToFunds(item.Value);
        }
        public void RemoveFromShopInventory(InventoryItem item)
        {
            _selectedInventorySlot.UnsetInventoryItem();
        }
    }
}
//EOF.