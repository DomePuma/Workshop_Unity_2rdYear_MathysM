using System;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public static Action<ItemData> SendItemToScriptableObjectAction;
    
    private bool isListFull;
    
    private void OnEnable() 
    {
        InventoryEvent.SendIsListFullAction += CheckIsListFull;
    }

    private void OnDisable() 
    {
        InventoryEvent.SendIsListFullAction -= CheckIsListFull;
    }

    private void CheckIsListFull(bool isInventoryFull)
    {
        isListFull = isInventoryFull;
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.layer == 6 && !isListFull)
        {
            SendItemToScriptableObjectAction.Invoke(other.gameObject.GetComponent<CollectiblesObject>().itemData);
            Destroy(other.gameObject);
        }
    }
}
