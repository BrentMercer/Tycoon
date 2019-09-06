using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    public MoneySO money;

    public Text storeCountText;
    public Slider progressSlider;
    public Text currentBalanceText;

    public int storeCount;
    public float storeTimer;
    private float currentTimer = 0;
    public float baseStoreCost;
    public float baseStoreProfit;

    private bool startTimer;
    public bool storeManager;

    void Start () {
        startTimer = false;
        money.CurrentBalance = 5.00f;
        currentBalanceText.text = money.CurrentBalance.ToString("C2");
    }
	
	void Update () {
        if (startTimer)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer > storeTimer)
            {
                if (!storeManager)
                {
                    startTimer = false;
                }
                currentTimer = 0f;
                money.CurrentBalance += baseStoreProfit * storeCount;
                currentBalanceText.text = money.CurrentBalance.ToString("C2");
            }
        }
        progressSlider.value = currentTimer / storeTimer;
    } 

    public void BuyStoreOnClick()
    {
        if (baseStoreCost > money.CurrentBalance)
        {
            return;
        }
        else
        {
            storeCount++;
            storeCountText.text = storeCount.ToString();
            Debug.Log(baseStoreCost);
            money.CurrentBalance -= baseStoreCost;
            currentBalanceText.text = money.CurrentBalance.ToString("C2");
        }
    }

    public void StoreOnClick()
    {
        if (!startTimer && storeCount > 0)
        {
            startTimer = true;
        }
    }

}
