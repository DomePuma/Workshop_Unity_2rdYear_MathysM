using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    
    private Camera _mainCamera;
    
    [SerializeField] private NavMeshAgent _agent;

    private bool canMove = true;
    
    private void OnEnable() 
    {
        InventoryEvent.SendIsInventoryOpen += CheckIsInventoryOpen;
    }
    private void OnDisable() 
    {
        InventoryEvent.SendIsInventoryOpen -= CheckIsInventoryOpen;
    }
    private void Awake() 
    { 
        _mainCamera = Camera.main;
    }
    private void CheckIsInventoryOpen(bool isInventoryOpen)
    {
        canMove = isInventoryOpen;
    }
    private void Update()
    {
        if(Input.GetMouseButton(0) && canMove)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);         
            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 1 << 3))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }
}
