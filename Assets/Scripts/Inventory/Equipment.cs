using System;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Inventory
{
    public class Equipment : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private InventoryManager inventory;
        private Dictionary<EquipLocation, GameObject> _equipLocationDict;

        private void OnEnable()
        {
            //InventoryManager.Instance.ItemEquippedEvent += OnItemEquipped;
            inventory.ItemEquippedEvent += OnItemEquipped;
        }

        private void Start()
        {
            //_equipLocationDict.Add(EquipLocation.Body, _player);
        }
        private bool OnItemEquipped(InventoryItem obj)
        {
            Debug.Log($"InvetoryItem: {obj.Name} was equipped");
            return true;
        }

        private void OnDisable()
        {
            InventoryManager.Instance.ItemEquippedEvent -= OnItemEquipped;
        }
    }
}
//EOF.