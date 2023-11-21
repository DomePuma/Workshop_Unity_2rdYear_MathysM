using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Items[] items;
    private Items newestItem;

    public Items NewestItem
    {
        set => newestItem = value;
    }
    private void Start() 
    {
        items = new Items[20];
        for(int i = 0; i < items.Length; i++)
        {
            items[i] = null;
        }  
    }
    private void Update()
    {
        if(newestItem.itemType != Items.ObjectType.NullType)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if(items[i].itemType == Items.ObjectType.NullType)
                {
                    items[i] = newestItem;
                    Debug.Log(items[i].itemType); 
                    newestItem.itemType = Items.ObjectType.NullType;
                    break;
                }
            }
        }
    }    
}