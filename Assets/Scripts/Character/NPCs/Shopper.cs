using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.UI;
using BGS.Inventory;
using BGS.DialogueSystem;

namespace BGS.Character
{
    public class Shopper : NPC
    {
        private ShopUIManager _shopUIManager;
        [SerializeField] private List<InventoryItem> _shopItems;
        public override void Interact()
        {
            base.Interact();
        }

        public override void HandleResponse(DialogueAction action)
        {
            if (!action.NeedsResponse) { return; }
            _shopUIManager = FindObjectOfType<ShopUIManager>();
            _shopUIManager.OpenShop(_shopItems);
        }
    }
}
