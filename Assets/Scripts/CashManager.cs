using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    int totalPrice;
    string keyword = "coins";
    private void Awake()
    {
        if (instance == null )
            instance = this;
        else
        {
            Destroy( instance );    
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadCoins();
        UiManager.instance.UpdateCount(totalPrice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SellingTheProducts(ProductDataScript other)
    {
        totalPrice += other.objectPrice;
        UiManager.instance.UpdateCount(totalPrice);
    }

    public bool CanBuySoil(int price)
    {
        if( totalPrice >= price ) 
        {
            return true;
        }
        return false;
    }

    public void BuyingtheSoil(int price)
    {
        totalPrice -= price;
        UiManager.instance.UpdateCount(totalPrice);
    }

    public void AddtheCoin(int price)
    {
        totalPrice += price;
        UiManager.instance.UpdateCount(totalPrice);
        SaveCoins();
    }

    void LoadCoins()
    {
        totalPrice = PlayerPrefs.GetInt(keyword, 0);
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt(keyword,totalPrice);
    }

}
