using UnityEngine;

[CreateAssetMenu(fileName = "new_ItemData", menuName = "Project/ItemData")]
public class ItemData : ScriptableObject
{
    public GameObject prefabItem;
    
    public GameObject prefabUI;
    
    public GameObject prefabNextItemUI;
    
    public enum ItemType
    {
        Coal,
        Iron,
        Gold,
        Ruby,
        Emerald,
        Diamond,
    }
}
