using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    public MoneySO money;

    public Text storeCountText;
    public Text currentBalanceText;
    public Text buyNowButtonPrice;
    public Slider progressSlider;
    public Button buyButton;

    public int storeCount;
    private float storeCost;
    public float baseStoreCost;
    public float storeMultiplier;
    public float baseStoreProfit;

    public float storeTimer;
    private float currentTimer = 0;


    private bool startTimer;
    public bool storeManager;

    void Start () {
        startTimer = false;
        money.CurrentBalance = 5.00f;
        currentBalanceText.text = money.CurrentBalance.ToString("C2");
        storeCost = baseStoreCost;
        buyNowButtonPrice.text = "Buy " + storeCost.ToString("C2");
    }

    void Update()
    {
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

        if (storeCost < money.CurrentBalance)
        {
            buyButton.GetComponent<Image>().color = Color.green;
        }
        else
        {
            buyButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void BuyStoreOnClick()
    {
        if (storeCost > money.CurrentBalance)
        {
            return;
        }
        else
        {
            storeCount++;
            storeCountText.text = storeCount.ToString();
            money.CurrentBalance -= storeCost;
            currentBalanceText.text = money.CurrentBalance.ToString("C2");
            storeCost = baseStoreCost * Mathf.Pow(storeMultiplier, storeCount);
            buyNowButtonPrice.text = "Buy " + storeCost.ToString("C2");
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
