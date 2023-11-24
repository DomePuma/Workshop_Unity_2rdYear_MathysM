using System.Collections;
using TMPro;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class GenerateItems : MonoBehaviour
{   
    [SerializeField] private NavMeshSurface navMeshSurface;
    
    private NavMeshData _navSurfaceData;
    
    private Vector3 _randomPointPosition;

    [SerializeField] private float _waitTimeMin;
    
    [SerializeField] private float _waitTimeMax;

    [SerializeField] private ItemData[] _harvestableObjects;

    GameObject LastInstantiateObject;

    private bool test = true;


    private void OnEnable() 
    {
        InventoryEvent.SendIsInventoryOpen += CheckGenerationItems;
    }
    private void OnDisable() 
    {
        InventoryEvent.SendIsInventoryOpen -= CheckGenerationItems;
    }

    private void CheckGenerationItems(bool isInventoryOpen)
    {
        if(isInventoryOpen)
        {
            test = true;
            StartCoroutine(SpawnObjects());
        }
        else
        {
            test = false;
        }
    }
    private Vector3 RandomPoint(Bounds bounds)
    {
       float meshSurfaceX = Random.Range(bounds.min.x, bounds.max.x);
       float meshSurfaceZ = Random.Range(bounds.min.z, bounds.max.z);
        
       if (Physics.Raycast(new Vector3(meshSurfaceX, transform.position.y + 1, meshSurfaceZ), Vector3.down, out RaycastHit hit, Mathf.Infinity))
       {
           if (hit.collider.TryGetComponent(out NavMeshObstacle navMeshObstacle))
           {
               return RandomPoint(bounds);
           }
       }
       return new Vector3(meshSurfaceX, transform.position.y ,meshSurfaceZ);
    }

    private IEnumerator SpawnObjects()
    {
        while (enabled && test)
        {
            yield return new WaitForSeconds(Random.Range(_waitTimeMin, _waitTimeMax));
            _randomPointPosition = RandomPoint(_navSurfaceData.sourceBounds);
            
            int choseWhichItem = Random.Range(0, _harvestableObjects.Length);
            GameObject harvestableObjectPrefab = _harvestableObjects[choseWhichItem].prefabItem;
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            
            LastInstantiateObject = Instantiate(harvestableObjectPrefab, _randomPointPosition, randomRotation);
            LastInstantiateObject.GetComponent<CollectiblesObject>().itemData = _harvestableObjects[choseWhichItem];
        }
    }

    private void Start()
    {
        _navSurfaceData = navMeshSurface.navMeshData;
        
        StartCoroutine(SpawnObjects());
    }
}
