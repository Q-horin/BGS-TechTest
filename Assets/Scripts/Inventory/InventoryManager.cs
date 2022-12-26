using System;
using UnityEngine;
using BGS.UI;

namespace BGS.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance { get; private set; }
        //public event Action<InventoryItem> ItemEquippedEvent;
        public Func<InventoryItem, bool> ItemEquippedEvent;
        public event Action ItemEquippedSuccessfully;


        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void ItemEquipped(InventoryItem item)
        {
            //ItemEquippedEvent?.Invoke(item);
            if (ItemEquippedEvent == null) { return; }
            if (ItemEquippedEvent(item))
            {
                ItemEquippedSuccessfully?.Invoke();
            }
        }

    }
}
//EOF.