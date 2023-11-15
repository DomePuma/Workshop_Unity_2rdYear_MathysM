using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItems : MonoBehaviour
{
    [SerializeField] private GameObject prefab_Object;
    void Start()
    {
        Instantiate(prefab_Object);
    }
}
