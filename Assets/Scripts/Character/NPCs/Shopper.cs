
using System.Collections.Generic;
using UnityEngine;
using BGS.UI;
using BGS.Inventory;
using BGS.DialogueSystem;
using BGS.Core;

namespace BGS.Character
{
    public class Shopper : NPC
    {
        private ShopUIManager _shopUIManager;
        [Range(1, 6)]
        [SerializeField] private int _inventorySize;
        [SerializeField] private List<InventoryItem> _shopItems;
        [SerializeField] private CurrencyController _currencyController;
        [SerializeField] private GameObject _hud;
        private bool _shopping;
        public override void Interact()
        {
            if (_shopping) { return; }
            base.Interact();
            _hud.SetActive(false);
        }

        public override void ExitInteraction()
        {
            base.ExitInteraction();
            _hud.SetActive(false);
        }

        public override void PreInteraction()
        {
            _hud.SetActive(true);
        }

        public override void HandleResponse(DialogueAction action)
        {
            if (!action.NeedsResponse) { return; }
            _shopUIManager = FindObjectOfType<ShopUIManager>();

            _shopUIManager.OpenShop(_shopItems, _inventorySize);
            _shopping = true;
        }

        public void OnItemSold(InventoryItem item)
        {
            var soldItem = _shopItems.Find(x => x.Name.Equals(item.Name));
            _currencyController.AddToFunds(item.Value);
            _shopItems.Remove(soldItem);
        }

        public bool OnItemBought(InventoryItem item)
        {
            if (_inventorySize < _shopItems.Count) { return false; }
            if (!_currencyController.CanAffordCost(item.Value)) { return false; }

            _currencyController.SubstractFromFunds(item.Value);
            _shopItems.Add(item);
            _shopUIManager.UpdateShopItems(_shopItems);
            return true;
        }

        public void ShopClosed()
        {
            _shopping = false;
        }
    }
}
