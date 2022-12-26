using BGS.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BGS.Inventory
{
    public class InventorySlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _childInventoryItem;
        [SerializeField] private Image _childSpriteRenderer;
        private InventoryUIManager _inventoryUIManager;

        private InventoryItem _inventoryItem;
        public bool IsChildActive { get; private set; }

        private void Start()
        {
            IsChildActive = false;
        }

        public void SetInvetoryItem(InventoryItem item)
        {
            _inventoryItem = item;
            _childSpriteRenderer.sprite = item.Sprite;
            IsChildActive = true;
            _childInventoryItem.SetActive(IsChildActive);
        }

        public void UnsetInventoryItem()
        {
            _inventoryItem = null;
            IsChildActive = false;
            _childInventoryItem.SetActive(IsChildActive);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(_inventoryItem == null) { return; }
            _inventoryUIManager = FindObjectOfType<InventoryUIManager>();
            _inventoryUIManager.SetSelectedInventoryItem(_inventoryItem);
            Debug.Log("Setting inventory item as it was clicked");
        }

        // _inventoryUIManager = GetComponent<InventoryUIManager>();
    }

}
