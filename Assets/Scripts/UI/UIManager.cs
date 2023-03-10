using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.Inventory;
using TMPro;

namespace BGS.UI
{
    public abstract class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;

        protected InventoryItem _selectedInventoryItem;
        protected InventorySlot _selectedInventorySlot;
        public InventoryItem SelectedItem => _selectedInventoryItem;
        public InventorySlot SelectedSlot => _selectedInventorySlot;
        public void SetSelectedInventoryItem(InventoryItem inventoryItem, InventorySlot invetorySlot)
        {
            _selectedInventoryItem = inventoryItem;
            _selectedInventorySlot = invetorySlot;
        }

        public void UnSelectInventoryItem()
        {
            _selectedInventoryItem = null;
            _selectedInventorySlot = null;
            RemoveDescriptionText();
        }
        public void SetDescriptionText(InventoryItem item)
        {
            string l1 = "COST: " + item.Value.ToString();
            string l2 = item.Description;

            _descriptionText.text = l1 + l2;
        }

        public void RemoveDescriptionText()
        {
            _descriptionText.text = string.Empty;
        }
    }
}
//EOF.