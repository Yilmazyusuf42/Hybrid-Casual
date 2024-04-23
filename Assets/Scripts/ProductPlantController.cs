using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static AudioManager;

public class ProductPlantController : MonoBehaviour
{
    bool isReadytoPick;
    Vector3 originalScale;
    [SerializeField] 
    ProductDataScript caseType;
    BagController bagController;
    // Start is called before the first frame update
    void Start()
    {
        isReadytoPick = true;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && isReadytoPick)
        {
            bagController = other.GetComponent<BagController>();
            
            if (bagController.IsBagEmpty())
            {
                bagController.AddtotheBag(caseType);
                Debug.Log("girdim bury");
                isReadytoPick = false;
                StartCoroutine(PickingProducts());
            }
        }
    }

    IEnumerator PickingProducts()
    {
        Vector3 targetScale = transform.localScale /= 3;
        transform.LeanScale(targetScale,1f);
        yield return new WaitForSeconds(5f);
        transform.LeanScale(originalScale,1f);
        isReadytoPick = true;
    }
}
