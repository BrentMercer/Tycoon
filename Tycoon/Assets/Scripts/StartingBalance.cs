using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingBalance : MonoBehaviour
{
    public MoneySO money;

    void Start()
    {
        money.CurrentBalance = 5.00f;
    }
    
}
