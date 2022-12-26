using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        private GameObject _inventoryItem;
        private SpriteRenderer _childSpriteRenderer;
        public bool IsChildActive { get; private set; }

        private void Start()
        {
            _inventoryItem = transform.GetChild(0).gameObject;
            _childSpriteRenderer = _inventoryItem.GetComponent<SpriteRenderer>();
            IsChildActive = false;
        }

        public void SetInvetoryItem(InventoryItem item)
        {
            _childSpriteRenderer.sprite = item.Sprite;
            IsChildActive = true;
            _inventoryItem.SetActive(IsChildActive);
        }

        public void UnsetInventoryItem()
        {
            IsChildActive = false;
            _inventoryItem.SetActive(IsChildActive);
        }
    }

}
