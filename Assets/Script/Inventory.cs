using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Project/Inventory")]

public class Inventory : ScriptableObject
{
    [SerializeField] private Items[] items = new Items[20];
    

    private void Awake() 
    {
        for(int i = 0; i < items.Length; i++)
        {
            items[i] = null;
        }  
    }
}