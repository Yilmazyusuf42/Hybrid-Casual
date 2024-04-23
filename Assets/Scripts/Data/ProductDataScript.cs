using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType { domato, cabbage };
[CreateAssetMenu(fileName ="product Menu",menuName ="Product Features",order =0)]
public class ProductDataScript : ScriptableObject
{
    public GameObject objectPreb;
    public ObjectType objectType;
    public int objectPrice;
}
