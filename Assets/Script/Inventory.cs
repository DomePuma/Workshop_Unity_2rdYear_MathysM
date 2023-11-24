using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> itemList;
    
    private GameObject[] itemInInventory = new GameObject[8];
    [SerializeField] GameObject[] itemInventoryParent;

    public static Action<bool> IsListFullAction;
    
    public static Action<bool> IsInventoryOpenAction;
    
    private bool isInventoryOpen;
    
    [SerializeField] private GameObject inventory;
    GameObject _parentItem;

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
            itemList.Add(itemData.prefabUI);
            DisplayItem(itemData.prefabUI);
            IsListFullAction.Invoke(false);

        }
        else if(itemList.Count == maxItemNumber - 1)
        {
            itemList.Add(itemData.prefabUI);
            DisplayItem(itemData.prefabUI);
            IsListFullAction.Invoke(true);
        }
        else
        {
            IsListFullAction.Invoke(true);
        }
    }
    public void ReEnableInventory()
    {
        IsListFullAction.Invoke(false);
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
    
    private void DisplayItem(GameObject item)
    {
        
        foreach (GameObject parentObject in itemInventoryParent)
        {
            if (parentObject.transform.childCount < 2)
            {
                _parentItem = parentObject;
                break;
            }
        }
        GameObject newItem = Instantiate(item);
        newItem.transform.SetParent(_parentItem.transform);
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localScale = new Vector3(2f, 2f, 2f);
    }
}