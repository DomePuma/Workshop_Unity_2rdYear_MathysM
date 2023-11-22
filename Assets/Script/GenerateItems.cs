using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class GenerateItems : MonoBehaviour
{
    [SerializeField] private GameObject prefab_Object;
    
    [SerializeField] private NavMeshSurface navMeshSurface;
    
    private NavMeshData _navSurfaceData;
    
    private Vector3 _randomPointPosition;

    [SerializeField] private float _waitTimeMin;
    
    [SerializeField] private float _waitTimeMax;

    [SerializeField] private GameObject[] _harvestableObjects;

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
        while (enabled)
        {
            yield return new WaitForSeconds(Random.Range(_waitTimeMin, _waitTimeMax));
            _randomPointPosition = RandomPoint(_navSurfaceData.sourceBounds);
            
            GameObject harvestableObjectPrefab = _harvestableObjects[Random.Range(0, _harvestableObjects.Length)];
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            
            Instantiate(harvestableObjectPrefab, _randomPointPosition, randomRotation);
        }
    }

    private void Start()
    {
        _navSurfaceData = navMeshSurface.navMeshData;
        
        StartCoroutine(SpawnObjects());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab_Object);
            Debug.Log(navMeshSurface.defaultArea);
        }
    }
}
