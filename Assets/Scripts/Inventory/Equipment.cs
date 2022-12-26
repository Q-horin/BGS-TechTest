using System;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Inventory
{
    public class Equipment : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        private Dictionary<EquipLocation, GameObject> _equipLocationDict;

        private void OnEnable()
        {
            InventoryManager.Instance.ItemEquippedEvent += OnItemEquipped;
        }

        private void Start()
        {
            _equipLocationDict.Add(EquipLocation.Body, _player);
        }
        private void OnItemEquipped(InventoryItem obj)
        {
            Debug.Log($"InvetoryItem: {obj.Name} was equipped");
        }

        private void OnDisable()
        {
            InventoryManager.Instance.ItemEquippedEvent -= OnItemEquipped;
        }
    }
}
//EOF.