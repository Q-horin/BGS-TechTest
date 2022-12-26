using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.UI
{
    public class ActivateUI : MonoBehaviour
    {
        [SerializeField] private KeyCode _toggleKey;
        [SerializeField] private GameObject _uiContainer;

        // Start is called before the first frame update
        void Start()
        {
            _uiContainer.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(_toggleKey))
            {
                _uiContainer.SetActive(!_uiContainer.activeInHierarchy);
            }
        }
    }
}
//EOF.