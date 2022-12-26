using BGS.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.UI
{
    public class InventoryUIManager : UIManager
    {
        [SerializeField] private GameObject _uiContainer;
        [SerializeField] private Transform _inventorySlotParent;
        [SerializeField] private GameObject _inventorySlotPrefab;
        [Range(1,6)]
        [SerializeField] private int _inventorySize;
        [SerializeField] private InventoryItem _item;

        private List<InventorySlot> _inventorySlots = new List<InventorySlot>();
        public List<InventorySlot> CurrentInventory => _inventorySlots;

        private void OnEnable()
        {
            InventoryManager.Instance.ItemEquippedSuccessfully += OnItemEquippedSuccessfully;
        }

        private void Start()
        {
            UpdateCurrentInventory(InventoryManager.Instance.InventorySize);
        }

        private void UpdateCurrentInventory(int inventorySize)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                GameObject slot = Instantiate(_inventorySlotPrefab, _inventorySlotParent);
                _inventorySlots.Add(slot.GetComponent<InventorySlot>());
            }
        }

        public void AddItemToInventory(InventoryItem item)
        {
            foreach (var slot in _inventorySlots)
            {
                if (slot.IsChildActive) { continue; }

                slot.SetInvetoryItem(item);
                break;
            }
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
    
        public override void SetSelectedInventoryItem(InventoryItem inventoryItem)
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