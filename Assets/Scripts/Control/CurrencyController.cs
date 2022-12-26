using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Core
{
    public class CurrencyController : MonoBehaviour
    {
        [SerializeField] private int _fund;

        public bool CanAffordCost(int cost)
        {
            if (_fund >= cost) { return true; }
            else { return false; }
        }

        public void SubstractFromFunds(int amount)
        {
            _fund -= amount;
        }

        public void AddToFunds(int amount)
        {
            _fund += amount;
        }
    }
}
