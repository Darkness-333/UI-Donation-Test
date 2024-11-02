using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject Store;
    [SerializeField] private GameObject StoreButton;

    public void OpenStore() {
        Store.SetActive(true);
        StoreButton.SetActive(false);
    }

    public void CloseStore() { 
        Store.SetActive(false);
        StoreButton.SetActive(true);

    }

}
