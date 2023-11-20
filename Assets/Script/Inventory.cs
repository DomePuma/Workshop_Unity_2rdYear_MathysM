using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Items[] items = new Items[20];
    private Items newestItem = null;

    public Items NewestItem
    {
        set => newestItem = value;
    }
    private void Start() 
    {
        for(int i = 0; i < items.Length; i++)
        {
            items[i] = null;
        }  
    }
    private void Update()
    {
        if(newestItem != null)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if(items[i] != null)
                {
                    items[i] = newestItem;
                    newestItem = null;
                    Debug.Log(items[i].itemType);
                    break;
                }
            }
        }
    }    
}