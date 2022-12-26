using System;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance { get; private set; }
        public event Action<InventoryItem> ItemEquippedEvent;


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
            ItemEquippedEvent?.Invoke(item);
        }

    }
}
//EOF.