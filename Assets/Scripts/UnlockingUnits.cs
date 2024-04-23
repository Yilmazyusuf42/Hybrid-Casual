using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockingUnits : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private int price;
    static int totalUnit;
    string Id;
    string keywords = "UnlockedFields";
    [Header("Objects")]
    [SerializeField]
    private GameObject unlockedObject;

    [SerializeField]
    private GameObject lockedObject;
    [SerializeField]
    TextMeshPro textMesh;

    

    public bool isUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        totalUnit++;
        Id = keywords + totalUnit.ToString();
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isUnlocked)
        {
            if(TryToBuySoil())
            {
                BuyingtheSoil();
            }
        }
    }

    bool TryToBuySoil()
    {
        if(CashManager.instance.CanBuySoil(price))
        {
            return true;
        }
        return false;
    }

    void BuyingtheSoil()
    {
        isUnlocked = true;
        CashManager.instance.BuyingtheSoil(price);
        lockedObject.SetActive(false);
        unlockedObject.SetActive(true);
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetString(Id,"saved");
    }

    void Load()
    {
        string status = PlayerPrefs.GetString(Id);
        if(status.Equals("saved"))
        {
            lockedObject.SetActive(false);
            unlockedObject.SetActive(true);
        }
    }
}
