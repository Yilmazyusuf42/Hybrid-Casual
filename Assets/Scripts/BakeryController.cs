using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BakeryController : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI textMesh;
    [SerializeField]
    int willCount;
    int currentCount;
    [SerializeField]
    ProductDataScript  productType;
    [SerializeField]
    float waitingSecond = 3f;
    [SerializeField]
    CoinController coinInstance;
    float time;
    [SerializeField]
    ParticleSystem chimneyFlog;
    // Start is called before the first frame update
    void Start()
    {
        DisplayCurrentWill();
    }

    // Update is called once per frame
    void Update()
    {
        CanProductCoin();
        StartFlog();
    }

    void DisplayCurrentWill()
    {
        textMesh.text = currentCount.ToString() + "/" + willCount.ToString();
    }

    public ProductDataScript ReturnWillType()
    {
        return productType;
    }
    public bool CheckingStore(ProductDataScript other)
    {
        if (willCount == currentCount || other.objectType != productType.objectType)
            return false;
        currentCount++;
        DisplayCurrentWill();
        return true;
    }

    

    void CanProductCoin()
    {
        if (currentCount > 0)
        {
            time += Time.deltaTime;
            if(time > waitingSecond)
            {
                ProducingCoin();
                time = 0f;
            }
        }
    }

    void StartFlog()
    {
        if(currentCount == 0)
        {
            if(chimneyFlog.isPlaying)
            {
                chimneyFlog.Stop();
            }
        }else
        {
            if(chimneyFlog.isStopped)
            { chimneyFlog.Play();}
        }
    }

    void ProducingCoin()
    {
        coinInstance.CreateCoin(productType.objectPrice);
        currentCount--;
        DisplayCurrentWill();
    }
}
