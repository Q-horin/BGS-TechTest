using BGS.Inventory;
using System;
using UnityEngine;

namespace BGS.UI
{
    public class InventoryUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _uiContainer;
        [SerializeField] private InventoryItem _item;
        [SerializeField] private InventorySlot _slot;
        [SerializeField] private InventoryManager _inventoryManager;
        private InventoryItem _selectedInventoryItem;
        private void Start()
        {
            _slot.SetInvetoryItem(_item);
        }

        private void OnEnable()
        {
            _inventoryManager.ItemEquippedSuccessfully += OnItemEquippedSuccessfully;
        }

        private void OnItemEquippedSuccessfully()
        {
            Debug.Log("Closing UI Shit");
        }

        public void HandleEquipment()
        {
            if (_selectedInventoryItem == null) { return; }
            Debug.Log("handling equipment");
            InventoryManager.Instance.ItemEquipped(_selectedInventoryItem);
        }
    
        public void SetSelectedInventoryItem(InventoryItem inventoryItem)
        {
            _selectedInventoryItem = inventoryItem;
        }

        public void CloseUI()
        {
            _uiContainer.SetActive(false);
        }
    }
}
//EOF.