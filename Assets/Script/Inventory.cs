using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> itemList;

    [SerializeField] GameObject[] itemInventoryParent;

    public static Action<bool> IsListFullAction;
    
    public static Action<bool> IsInventoryOpenAction;
    
    private bool isInventoryOpen;
    
    [SerializeField] private GameObject inventory;

    public int maxItemNumber;

    private void OnEnable() 
    {
        InventoryEvent.SendItemToInventoryAction += AddItemToInventory;
    }

    private void OnDisable() 
    {
        InventoryEvent.SendItemToInventoryAction -= AddItemToInventory;
    }

    private void AddItemToInventory(ItemData itemData)
    {
        if(itemList.Count < maxItemNumber - 1)
        {
            itemList.Add(itemData);
            DisplayItem(itemData);
            IsListFullAction.Invoke(false);

        }
        else if(itemList.Count == maxItemNumber - 1)
        {
            itemList.Add(itemData);
            DisplayItem(itemData);
            IsListFullAction.Invoke(true);
        }
        else
        {
            IsListFullAction.Invoke(true);
        }
    }
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenInventory();
        }    
    }
    
    public void OpenInventory()
    {
        IsInventoryOpenAction.Invoke(isInventoryOpen);
        isInventoryOpen = !isInventoryOpen;
        inventory.SetActive(isInventoryOpen);
    }

    private void DisplayItem(ItemData item)
    {
        GameObject newItem = Instantiate(item.prefabUI);
        newItem.GetComponent<ScriptableHolder>().itemData = item;
        newItem.transform.SetParent(itemInventoryParent[itemList.LastIndexOf(item)].transform);
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localScale = new Vector3(.7f, .7f, .7f);
    }
}