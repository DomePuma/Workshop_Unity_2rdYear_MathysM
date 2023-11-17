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
    internal ObjectType itemType;

    private bool hasAType = false;
    internal ObjectType ItemType
    {
        get => Main();
    }
    internal ObjectType Main()
    {
        if (hasAType)
        {
            return itemType;
        }

        hasAType = true;
        int i = UnityEngine.Random.Range(0,6);
        switch(i)
        {
            case 0:
                itemType = ObjectType.Wheat;
                return ObjectType.Wheat;
            case 1:
                itemType = ObjectType.Wood;
                return ObjectType.Wood;
            case 2:
                itemType = ObjectType.Rock;
                return ObjectType.Rock;
            case 3:
                itemType = ObjectType.Iron;
                return ObjectType.Iron;
            case 4:
                itemType = ObjectType.Gold;
                return ObjectType.Gold;
            case 5:
                itemType = ObjectType.Diamond;
                return ObjectType.Diamond;
            default :
                itemType = ObjectType.Wheat;
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
