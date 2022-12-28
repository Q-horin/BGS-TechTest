using BGS.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BGS.UI
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private CurrencyController _currencyController;
        [SerializeField] private TextMeshProUGUI _fundsText;

        // Start is called before the first frame update
        void Start()
        {
            SetFunds(_currencyController.Funds);
        }
        
        public void SetFunds(int funds)
        {
            string str = "$" + funds.ToString();
            _fundsText.text = str;
        }
    }
}
//EOF.
