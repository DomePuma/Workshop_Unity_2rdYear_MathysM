using System.ComponentModel;
using Unity.Collections;
using UnityEngine;

public class CollectiblesObject : MonoBehaviour
{
    private Items item = new Items();
    private Items.ObjectType itemType;
    private void Start() 
    {
        item = new Items();
        itemType = item.ItemType;
        Debug.Log(item.ItemType);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            
        }
    }
}

[System.Serializable]
public class Items
{   
    public ObjectType ItemType
    {
        get => Main();
    }
    internal ObjectType Main()
    {
        int i = UnityEngine.Random.Range(0,6);
        switch(i)
        {
            case 0:
            return ObjectType.Wheat;
            case 1:
            return ObjectType.Wood;
            case 2:
            return ObjectType.Rock;
            case 3:
            return ObjectType.Iron;
            case 4:
            return ObjectType.Gold;
            case 5:
            return ObjectType.Diamond;
            default :
            return ObjectType.Wheat;
        }
    }
    public enum ObjectType
    {
        Wheat,
        Wood,
        Rock,
        Iron,
        Gold,
        Diamond,
    }
}
