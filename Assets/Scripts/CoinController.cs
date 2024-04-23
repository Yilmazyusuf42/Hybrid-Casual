using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    Transform initiatePos;

    [SerializeField]
    GameObject createdCoin;

    private static int coinValue;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCoin(int price)
    {
        coinValue = price;
        GameObject coin = Instantiate(createdCoin);
        coin.transform.rotation = Quaternion.identity;
        coin.transform.position = initiatePos.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            AudioManager.instance.PlaySound(AudioManager.AudioClipType.shopAudio);
            CashManager.instance.AddtheCoin(coinValue);
        }
    }

}
