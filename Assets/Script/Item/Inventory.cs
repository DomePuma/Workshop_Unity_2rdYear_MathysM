using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] itemInventoryParent;
    
    [SerializeField] private GameObject inventory;

    public static Action<bool> IsListFullAction;
    
    public static Action<bool> IsInventoryOpenAction;
    
    public List<GameObject> itemList;
    public int maxItemNumber;
    
    private bool _isInventoryOpen;
    
    private GameObject _parentItem;

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
    
    public void OpenInventory()
    {
        IsInventoryOpenAction.Invoke(_isInventoryOpen);
        _isInventoryOpen = !_isInventoryOpen;
        inventory.SetActive(_isInventoryOpen);
    }

    private void DisplayItem(GameObject _item)
    {
        foreach (GameObject parentObject in itemInventoryParent)
        {
            if (parentObject.transform.childCount < 2)
            {
                _parentItem = parentObject;
                break;
            }
        }
        GameObject newItem = Instantiate(_item);
        newItem.transform.SetParent(_parentItem.transform);
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenInventory();
        }    
    }

    private void OnEnable() 
    {
        ScriptableInventoryEvent.SendItemToInventoryAction += AddItemToInventory;
    }

    private void OnDisable() 
    {
        ScriptableInventoryEvent.SendItemToInventoryAction -= AddItemToInventory;
    }
}