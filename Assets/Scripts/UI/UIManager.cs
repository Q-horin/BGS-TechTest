using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.Inventory;

namespace BGS.UI
{
    public abstract class UIManager : MonoBehaviour
    {
        protected InventoryItem _selectedInventoryItem;
        public virtual void SetSelectedInventoryItem(InventoryItem inventoryItem)
        {
            _selectedInventoryItem = inventoryItem;
        }
    }
}
//EOF.