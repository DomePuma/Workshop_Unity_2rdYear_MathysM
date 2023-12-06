using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new_" + nameof(ScriptableInventoryEvent), menuName = "Events/Scriptable Event")]
public class ScriptableInventoryEvent : ScriptableObject
{
    public static Action<ItemData> SendItemToInventoryAction;
    
    public static Action<bool> SendIsListFullAction;
    
    public static Action<bool> SendIsInventoryOpen;
    
    private void AddItemInventory(ItemData itemData)
    {
        SendItemToInventoryAction.Invoke(itemData);
    }
    
    private void IsListIsFull(bool isListFull)
    {
        SendIsListFullAction.Invoke(isListFull);
    }
    
    private void IsInventoryOpen(bool isInventoryOpen)
    {
        SendIsInventoryOpen.Invoke(isInventoryOpen);
    }

    void OnEnable()
    {
        Inventory.IsListFullAction += IsListIsFull;
        
        Inventory.IsInventoryOpenAction += IsInventoryOpen;
        
        GetItem.SendItemToScriptableObjectAction += AddItemInventory;
    }

    void OnDisable()
    {
        Inventory.IsListFullAction -= IsListIsFull;
        
        Inventory.IsInventoryOpenAction -= IsInventoryOpen;
        
        GetItem.SendItemToScriptableObjectAction -= AddItemInventory;
    }
}