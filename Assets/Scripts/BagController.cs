using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static AudioManager;

public class BagController : MonoBehaviour

{
    [SerializeField]
    Transform bagPos;
    public List<ProductDataScript> cases;
    float scaleY;
    int maxCapacity = 5;
    [SerializeField]
    TextMeshPro maxText;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Store"))
        {
            PlayShoppingSound();
            for (int i = cases.Count-1 ; i >= 0; i--)
            {
                Destroy(bagPos.transform.GetChild(i).gameObject);
                CashManager.instance.SellingTheProducts(cases[i]);
                cases.RemoveAt(i);
            }
            DisableMaxText();
        }

        SellToBakery(other);
    }
    public void AddtotheBag(ProductDataScript other)
    {
        GameObject boxType = Instantiate(other.objectPreb);
        CalculateSizeoftheCase(boxType);
        float posY = cases.Count * scaleY;
        boxType.transform.SetParent(bagPos, false);
        boxType.transform.localPosition = new Vector3(0,posY,0);
        boxType.transform.localRotation = Quaternion.identity;
        cases.Add(other);
        if(maxCapacity == cases.Count)
            ActiveMaxText();
        AudioManager.instance.PlaySound(AudioClipType.grapAudio);
    }

    void CalculateSizeoftheCase(GameObject other)
    {
        if(cases != null) 
        { 
            MeshRenderer mesh = other.GetComponent<MeshRenderer>();
            scaleY = mesh.bounds.size.y;
        }
    }

    void ActiveMaxText()
    {
        maxText.gameObject.SetActive(true);
    }
    void DisableMaxText()
    {
        maxText.gameObject.SetActive(false);

    }


    public bool IsBagEmpty()
    {
        if (cases.Count  < maxCapacity)
            return true;
        else
        {
            return false;
        }
    }

    void SellToBakery(Collider other)
    {
        bool bakeryStatus = other.GetComponent<UnlockingUnits>().isUnlocked;
        if (other.CompareTag("Bakery") && bakeryStatus)
        {
            if (cases.Count > 0)
                PlayShoppingSound();

            BakeryController bakery = other.GetComponent<BakeryController>();
            ProductDataScript willType = bakery.ReturnWillType();
            for (int i = cases.Count - 1; i >= 0; i--)
            {
                if (bakery.CheckingStore(cases[i]))
                {
                    if (willType == cases[i])
                    {
                        Destroy(bagPos.transform.GetChild(i).gameObject);
                        cases.RemoveAt(i);
                    }
                }
            }
            StartCoroutine(ReorderTheCases());
        }
    }

    IEnumerator ReorderTheCases()
    {

        yield return new WaitForSeconds(0.15f);
         Debug.Log("i cam bakery");

        float yPos;
        for (int i = 0; i < cases.Count; i++)
        {
            yPos = scaleY * i;
            bagPos.GetChild(i).transform.localPosition = new Vector3(0, yPos, 0);
        }

    }

    void PlayShoppingSound()
    {
        AudioManager.instance.PlaySound(AudioClipType.shopAudio);
    }
}
