using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class CollectiblesObject : MonoBehaviour
{
    private Items item = new Items();
    
    private Items.ObjectType itemType;
    private Renderer objectRenderer;
    private void Awake()
    {
        item = new Items();
        itemType = item.ItemType;
        objectRenderer = this.gameObject.GetComponent<Renderer>();
    }
    private void Start() 
    {
        switch(itemType)
        {
            case Items.ObjectType.Iron :
                objectRenderer.material.SetColor("_BaseColor", Color.grey);
                break;
            case Items.ObjectType.Gold :
                objectRenderer.material.SetColor("_BaseColor", Color.yellow);
                break;
            case Items.ObjectType.Emerald :
                objectRenderer.material.SetColor("_BaseColor", Color.green);
                break;
            case Items.ObjectType.Ruby :
                objectRenderer.material.SetColor("_BaseColor", Color.red);
                break;
            case Items.ObjectType.Diamond :
                objectRenderer.material.SetColor("_BaseColor", Color.blue);
                break;
            default :
                objectRenderer.material.SetColor("_BaseColor", Color.black);
                break;
        }

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
    [SerializeField] internal ObjectType itemType;

    private bool hasAType = false;
    
    internal ObjectType ItemType
    {
        get => AssignType();
    }

    internal ObjectType AssignType()
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
