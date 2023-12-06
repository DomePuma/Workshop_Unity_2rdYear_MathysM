using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragNDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject itemTypeSource;

    private Image _image;

    private Transform _initialParent;

    private Inventory _inventory;

    public ItemData.ItemType itemType;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialParent = transform.parent;
        
        transform.SetParent(transform.root);
        
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> raycastResult = new List<RaycastResult>();
        
        EventSystem.current.RaycastAll(eventData, raycastResult);
        
        GameObject ItemLevelUp;
        
        foreach (RaycastResult objectInRay in raycastResult)
        {
            if (objectInRay.gameObject.TryGetComponent<DragNDrop>(out DragNDrop ItemInRay))
            {
                if (ItemInRay.itemType == itemType && itemType != ItemData.ItemType.Diamond)
                {
                    ItemLevelUp = Instantiate(itemTypeSource.GetComponent<ScriptableHolder>().itemData.prefabNextItemUI, ItemInRay.transform.parent);
                    
                    _inventory.itemList.Remove(ItemInRay.gameObject);
                    
                    Destroy(ItemInRay.gameObject);
                    
                    _inventory.itemList.Add(ItemLevelUp.GetComponent<ScriptableHolder>().itemData.prefabUI);
                    
                    _inventory.itemList.Remove(gameObject);
                    
                    Destroy(gameObject);

                    _inventory.ReEnableInventory();
                }
            }
        }
        _image.raycastTarget = true;
        
        transform.SetParent(_initialParent);
        
        transform.localPosition = Vector3.zero;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        
        _inventory = FindObjectOfType<Inventory>();
    }
}