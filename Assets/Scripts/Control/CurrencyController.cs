using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BGS.Core
{
    public class CurrencyController : MonoBehaviour
    {
        [SerializeField] private int _funds;

        public UnityEvent<int> FundsUpdatedEvent;
        public int Funds => _funds;
        public bool CanAffordCost(int cost)
        {
            if (_funds >= cost) { return true; }
            else { return false; }
        }

        public void SubstractFromFunds(int amount)
        {
            _funds -= amount;
            FundsUpdatedEvent?.Invoke(Funds);
        }

        public void AddToFunds(int amount)
        {
            _funds += amount;
            FundsUpdatedEvent?.Invoke(Funds);
        }
    }
}
