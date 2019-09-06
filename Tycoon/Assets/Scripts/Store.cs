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
    public Slider ProgressSlider;

    private float StoreTimer = 4f;
    private float CurrentTimer = 0;
    private float BaseStoreProfit;

    private bool StartTimer;

    void Start () {
        StoreCount = 1;
        CurrentBalance = 5.00f;
        CurrentBalanceText.text = CurrentBalance.ToString("C2");
        BaseStoreCost = 1.50f;
        BaseStoreProfit = .5f;
        StartTimer = false;
    }
	
	void Update () {
        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
            if (CurrentTimer > StoreTimer)
            {
                Debug.Log("Reset start timer.");
                StartTimer = false;
                CurrentTimer = 0f;
                CurrentBalance += BaseStoreProfit * StoreCount;
                CurrentBalanceText.text = CurrentBalance.ToString("C2");
            }
        }
        ProgressSlider.value = CurrentTimer / StoreTimer;

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

    public void StoreOnClick()
    {
        Debug.Log("Clicked the store.");
        if (!StartTimer)
        {
            StartTimer = true;
        }
        
    }

}
