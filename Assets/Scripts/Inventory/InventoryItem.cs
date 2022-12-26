using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory Item", menuName = "BGS/Inventory Item")]
    public class InventoryItem : ScriptableObject, IEquipable
    {
        [SerializeField] public Sprite Sprite;
        [SerializeField] public string Name;
        [SerializeField] public EquipLocation EquipLocation;

        public void OnEquip()
        {
            throw new System.NotImplementedException();
        }
    }
}
//EOF.