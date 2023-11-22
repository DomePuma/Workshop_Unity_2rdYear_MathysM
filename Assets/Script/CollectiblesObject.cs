using UnityEngine;

public class CollectiblesObject : MonoBehaviour
{

    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Inventory>().NewestItem = item;
            Destroy(gameObject);
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
            case 1:
                itemType = ObjectType.Iron;
                return ObjectType.Iron;
            case 2:
                itemType = ObjectType.Gold;
                return ObjectType.Gold;
            case 3:
                itemType = ObjectType.Emerald;
                return ObjectType.Emerald;
            case 4:
                itemType = ObjectType.Ruby;
                return ObjectType.Ruby;
            case 5:
                itemType = ObjectType.Diamond;
                return ObjectType.Diamond;
            default :
                itemType = ObjectType.Coal;
                return ObjectType.Coal;
        }
    }
    public enum ObjectType
    {
        Coal,
        Iron,
        Gold,
        Emerald,
        Ruby,
        Diamond,
    }
}
