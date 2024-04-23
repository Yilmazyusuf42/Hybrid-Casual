using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using static AudioManager;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField]
    TextMeshProUGUI textMesh;
    private void Awake()
    {
        if (instance == null)
        instance = this;
        else
            Destroy(instance);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateCount(int i)
    {
        textMesh.text = i.ToString();
        CashManager.instance.SaveCoins();
    }

}
