using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public MoneySO money;
    public GameObject buyStoreButton;
    public GameObject store;
    public Text currentBalanceText;
    public float cost;
    public bool isActive;

    private void Update()
    {
        CanBuyUpgrade(buyStoreButton);
    }

    public void CanBuyUpgrade(GameObject buyStoreButton)
    {
        if (money.CurrentBalance >= cost && isActive == false)
        {
            isActive = true;
            buyStoreButton.SetActive(true);
        }
    }

    public void UnlockStore(GameObject store)
    {
        if (money.CurrentBalance >= cost)
        {
            money.CurrentBalance -= cost;
            store.SetActive(true);
            buyStoreButton.SetActive(false);
        }
        
    }
}
