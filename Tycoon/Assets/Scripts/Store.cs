using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    private int StoreCount;
    
    private float CurrentBalance;
    private float BaseStoreCost;

    public Text StoreCountText;
    public Text CurrentBalanceText;

    void Start () {
        StoreCount = 1;
        CurrentBalance = 5.00f;
        CurrentBalanceText.text = CurrentBalance.ToString("C2");
        BaseStoreCost = 1.50f;
    }
	
	void Update () {

	} 

    public void BuyStoreOnClick()
    {
        if (BaseStoreCost > CurrentBalance)
        {
            return;
        }
        else
        {
            CurrentBalance -= BaseStoreCost;
            StoreCount++;
            StoreCountText.text = StoreCount.ToString();
            CurrentBalanceText.text = CurrentBalance.ToString("C2");
        }
        
        
    }

}
